using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

     
    }
}
