using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RPG_Game;
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
            var actual = newWarrior.EquipItem(newWeapon.Name);

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
            var actual = newWarrior.EquipItem(newArmor.Name);

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
            var actual = newWarrior.EquipItem(newArmor.Name);

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
            var actual = newWarrior.EquipItem(newArmor.Name);

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
            var actual = newWarrior.EquipItem(newWeapon.Name);

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
            var actual = newWarrior.EquipItem(newArmor.Name);

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

            newWarrior.EquipItem(newWeapon.Name);
            var expected = "Axe of Gimli";
            // Act
            newWarrior.EquipItem(newWeapon2.Name);
            var actual = newWarrior.EquippedItems[Slot.Weapon].Name;

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion


        [Fact]
        public void EquipItem_newWarriorOneEquippedArmorChangeSameSlotToAnotherFromInventory_ShouldBeRightTotal()
        {
            var newWarrior = new Warrior("gabriel");
            var armorOne = new Armor("Chestplate of UwU", 1, Slot.Body, ArmorCat.Plate,
                 new PrimaryAttribute(5, 2, 2));
            var armorTwo = new Armor("Chainmail Of Gimli", 1, Slot.Body, ArmorCat.Mail,
                new PrimaryAttribute(7, 1, 5));

            newWarrior.Inventory.AddItemToInventory(armorOne);
            newWarrior.Inventory.AddItemToInventory(armorTwo);

            newWarrior.EquipItem(armorOne.Name);
            TotalAttribute expected = new TotalAttribute();
            expected.Strength = 12.0;
            expected.Dexterity = 3.0;
            expected.Intelligence = 6.0;          // base: str:5, dex:2 , int: 1  //after: 9, 5, 4 // 
            
            // Act
            newWarrior.EquipItem(armorTwo.Name);
            TotalAttribute actual = newWarrior.TotalAttribute;
            var expectedStr = JsonConvert.SerializeObject(expected);
            var actualStr = JsonConvert.SerializeObject(actual);

            // Assert
            Assert.Equal(expectedStr, actualStr);
        }


    }
}
