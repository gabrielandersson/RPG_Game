using RPG_Game;
using System.Collections.Generic;
using Xunit;

namespace RPG_Game_Tests
{
    public class InventoryTests
    {
        #region AddItem
        [Fact]
        public void AddItemToInventory_NewInventoryAddNewWeapon_ShouldReturnTrue()
        {
            // Arrange 
            var newInventory = new Inventory();
            var newWeapon = new Weapon("common axe", 1, WeaponCat.Axes, 7, 1.1);
            bool expected = true;
            // Act 
            var actual = newInventory.AddItemToInventory(newWeapon);
            //Assert
            Assert.Equal(expected, actual);
        }
        #endregion
        #region AddingTooMuchShouldFail
        [Fact]
        public void AddItemToInventory_InventoryWithTenWeaponsAddWeaponEleven_ShouldReturnFalse()
        {
            // Arrange
            var newWeapon = new Weapon("common axe", 1, WeaponCat.Axes, 7, 1.1);
            var newInventory = new Inventory();
            newInventory.AddItemToInventory(newWeapon);
            newInventory.AddItemToInventory(newWeapon);
            newInventory.AddItemToInventory(newWeapon);
            newInventory.AddItemToInventory(newWeapon);
            newInventory.AddItemToInventory(newWeapon);
            newInventory.AddItemToInventory(newWeapon);
            newInventory.AddItemToInventory(newWeapon);
            newInventory.AddItemToInventory(newWeapon);
            newInventory.AddItemToInventory(newWeapon);
            newInventory.AddItemToInventory(newWeapon);
            bool expected = false;
            // Act 
            var actual = newInventory.AddItemToInventory(newWeapon);
            // Arrange
            Assert.Equal(expected, actual);
        }
        #endregion
        #region GetInventory
        [Fact]
        public void GetInventory_NewInventoryWithOneNewWeapon_ShouldReturnListWithOneWeapon()
        {
            // Arrange 
            var newInventory = new Inventory();
            var newWeapon = new Weapon("common axe", 1, WeaponCat.Axes, 7, 1.1);
            newInventory.AddItemToInventory(newWeapon);
            var expected = new List<Item>() { newWeapon };
            // Act
            var actual = newInventory.GetInventory();
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region GetItemFromInventoryGetsRightItem
        [Fact]
        public void GetItemFromInventory_newInventoryWithOneWeaponSuppliedWithRightName_ShouldReturnItemWithRightName()
        {
            // Arrange
            var newInventory = new Inventory();
            var newWeapon = new Weapon("common axe", 1, WeaponCat.Axes, 7, 1.1);
            newInventory.AddItemToInventory(newWeapon);
            var expected = newWeapon;
            // Act
            var actual = newInventory.GetItemFromInventory("common axe");
            // Assert
            Assert.Equal(expected.Name, actual.Name);
        }
        #endregion
        #region GetItemFromInventoryGetsRightType
        [Fact]
        public void GetItemFromInventory_newInventoryWithOneWeaponSuppliedWithRightName_ShouldReturnItemOfRightType()
        {
            // Arrange
            var newInventory = new Inventory();
            var newWeapon = new Weapon("common axe", 1, WeaponCat.Axes, 7, 1.1);
            newInventory.AddItemToInventory(newWeapon);
            var expected = newWeapon.GetType();
            // Act
            var actual = newInventory.GetItemFromInventory("common axe").GetType();
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion
        #region GetItemFromInventoryReturnsNullAtFailure
        [Fact]
        public void GetItemFromInventory_newInventoryWithOneWeaponWrongName_ShouldReturnNull()
        {
            // Arrange
            var newInventory = new Inventory();
            var newWeapon = new Weapon("common axe", 1, WeaponCat.Axes, 7, 1.1);
            newInventory.AddItemToInventory(newWeapon);
            // Act
            var actual = newInventory.GetItemFromInventory("not a common axe");
            // Assert
            Assert.Equal(actual, null);
        }
        #endregion
    }
}
