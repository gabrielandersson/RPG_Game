using Newtonsoft.Json;
using RPG_Game.Enums;
using RPG_Game.Exceptions;
using RPG_Game.HeroClasses;
using RPG_Game.Items;
using RPG_Game.Shared;
using Xunit;
namespace RPG_Game_Tests
{
    public class EquipTests
    {
        #region EquipAnAxeTooGoodForYou
        [Fact]
        public void EquipItem_NewWarriorWithHigherLvlWeaponInInventoryWeaponNameAsInput_ShouldThrowInvalidWeaponExceptionAndReturnMessage()
        {
            // Arrange
            var newWarrior = new Warrior("gabriel");
            var newWeapon = new Weapon("Sword of UwU", 3, WeaponCat.Swords, 4, 10);
            newWarrior.Inventory.AddItemToInventory(newWeapon);
            var expected = new InvalidWeaponException("Too low lvl for this weapon");
            //Act
            var actual = newWarrior.EquipHandler.EquipItem(newWeapon.Name, newWarrior);

            //Assert
            Assert.Equal(expected.Message, actual);
        }
        #endregion
        #region EquipAnArmorTooGoodForYou
        [Fact]
        public void EquipItem_NewWarriorWithHigherLvlArmorInInventory_ShouldThrowInvalidArmorExceptionAndReturnMessage()
        {
            var newWarrior = new Warrior("gabriel");
            var newArmor = new Armor("Plate Leg Armor of UwU", 4, Slot.Legs, ArmorCat.Plate,
                new PrimaryAttribute(4, 1, 1));
            newWarrior.Inventory.AddItemToInventory(newArmor);
            var expected = new InvalidArmorException("Too low lvl for this armor");
            //Act
            var actual = newWarrior.EquipHandler.EquipItem(newArmor.Name, newWarrior);

            //Assert
            Assert.Equal(expected.Message, actual);
        }
        #endregion
        #region EquipArmorWrongCategory
        [Fact]
        public void EquipItem_NewWarriorWithArmorOfWrongCategoryInInventory_ShouldThrowInvalidArmorExceptionAndReturnMessage()
        {
            var newWarrior = new Warrior("gabriel");
            var newArmor = new Armor("Plate Leg Armor of UwU", 1, Slot.Legs, ArmorCat.Cloth,
                new PrimaryAttribute(4, 1, 1));
            newWarrior.Inventory.AddItemToInventory(newArmor);
            var expected = new InvalidArmorException("You can't equip armor of this category!");
            //Act
            var actual = newWarrior.EquipHandler.EquipItem(newArmor.Name, newWarrior);

            //Assert
            Assert.Equal(expected.Message, actual);

        }
        #endregion

        #region EquipItemWeaponWrongCategory
        [Fact]
        public void EquipItem_NewWarriorWithWeaponOfWrongCategoryInInventory_ShouldThrowInvalidWeaponExceptionAndReturnMessage()
        {
            //Arrange
            var newWarrior = new Warrior("gabriel");
            var newArmor = new Weapon("Legolas Bow", 1, WeaponCat.Bows, 2, 6);
            newWarrior.Inventory.AddItemToInventory(newArmor);
            var expected = new InvalidArmorException("You can't equip a weapon of this category!");
            //Act
            var actual = newWarrior.EquipHandler.EquipItem(newArmor.Name, newWarrior);
            //Assert
            Assert.Equal(expected.Message, actual);
        }
        #endregion

        #region EquipItemValidWeapon
        [Fact]
        public void EquipItem_NewWarriorWithASuitableWeaponInInventory_ShouldReturnSuccessMessage()
        {
            var newWarrior = new Warrior("gabriel");
            var newWeapon = new Weapon("NerfSword", 1, WeaponCat.Swords, 0, 0);
            newWarrior.Inventory.AddItemToInventory(newWeapon);
            var expected = "New weapon equipped!";
            //Act
            var actual = newWarrior.EquipHandler.EquipItem(newWeapon.Name, newWarrior);

            //Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region EquipValidArmor
        [Fact]
        public void EquipItem_NewWarriorWithASuitableArmorInInventory_ShouldReturnSuccessMessage()
        {
            var newWarrior = new Warrior("gabriel");

            var newArmor = new Armor("Chainmail Of Gimli", 1, Slot.Body, ArmorCat.Mail,
                 new PrimaryAttribute(7, 1, 5));
            newWarrior.Inventory.AddItemToInventory(newArmor);
            var expected = "New armour equipped!";
            //Act
            var actual = newWarrior.EquipHandler.EquipItem(newArmor.Name, newWarrior);

            //Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region ChangeEquippedWeaponReturnsOldToInventory
        [Fact]
        public void EquipItem_newWarriorOneEquippedWeaponChangeToAnotherFromInventory_ShouldSwitchPlaces()
        {
            var newWarrior = new Warrior("gabriel");
            var newWeapon = new Weapon("NerfSword", 1, WeaponCat.Swords, 0, 0);
            var newWeapon2 = new Weapon("Axe of Gimli", 1, WeaponCat.Swords, 6, 3);

            newWarrior.Inventory.AddItemToInventory(newWeapon);
            newWarrior.Inventory.AddItemToInventory(newWeapon2);

            newWarrior.EquipHandler.EquipItem(newWeapon.Name, newWarrior);
            var expected = "Axe of Gimli";
            // Act
            newWarrior.EquipHandler.EquipItem(newWeapon2.Name, newWarrior);
            var actual = newWarrior.EquippedItems[Slot.Weapon].Name;

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region EquipNewArmor/ChangeSameArmorSlot
        [Fact]
        public void EquipItem_NewWarriorOneEquippedArmorChangeSameSlotToAnotherFromInventory_ShouldBeRightTotal()
        {
            var newWarrior = new Warrior("gabriel");
            var armorOne = new Armor("Chestplate of UwU", 1, Slot.Body, ArmorCat.Plate,
                 new PrimaryAttribute(5, 2, 2));
            var armorTwo = new Armor("Chainmail Of Gimli", 1, Slot.Body, ArmorCat.Mail,
                new PrimaryAttribute(7, 1, 5));

            newWarrior.Inventory.AddItemToInventory(armorOne);
            newWarrior.Inventory.AddItemToInventory(armorTwo);

            newWarrior.EquipHandler.EquipItem(armorOne.Name, newWarrior);
            TotalAttribute expected = new TotalAttribute();
            expected.Strength = 12.0;
            expected.Dexterity = 3.0;
            expected.Intelligence = 6.0;          // base: str:5, dex:2 , int: 1  //after: 9, 5, 4 // 

            // Act
            newWarrior.EquipHandler.EquipItem(armorTwo.Name, newWarrior);
            TotalAttribute actual = newWarrior.TotalAttribute;
            var expectedStr = JsonConvert.SerializeObject(expected);
            var actualStr = JsonConvert.SerializeObject(actual);

            // Assert
            Assert.Equal(expectedStr, actualStr);
        }
        #endregion

        #region EquipTwoDifferentTypesOfArmor
        [Fact]
        public void EquipItem_NewWarriorOneEquippedArmorAddAnotherArmor_ShouldBeRightTotal()
        {
            var newWarrior = new Warrior("gabriel");
            var armorOne = new Armor("Chestplate of UwU", 1, Slot.Body, ArmorCat.Plate,
                new PrimaryAttribute(5, 2, 2));
            var armorTwo = new Armor("Chainmail Helmet", 1, Slot.Head, ArmorCat.Mail,
                 new PrimaryAttribute(2, 2, 4));

            newWarrior.Inventory.AddItemToInventory(armorOne);
            newWarrior.Inventory.AddItemToInventory(armorTwo);

            newWarrior.EquipHandler.EquipItem(armorOne.Name, newWarrior);
            TotalAttribute expected = new TotalAttribute();
            expected.Strength = 12.0;
            expected.Dexterity = 6.0;
            expected.Intelligence = 7.0;          // base:5 str:5, dex:2 , int: 1  //after: 12, 6, 7  // 

            // Act
            newWarrior.EquipHandler.EquipItem(armorTwo.Name, newWarrior);
            TotalAttribute actual = newWarrior.TotalAttribute;
            var expectedStr = JsonConvert.SerializeObject(expected);
            var actualStr = JsonConvert.SerializeObject(actual);

            // Assert
            Assert.Equal(expectedStr, actualStr);
        }
        #endregion
    }
}
