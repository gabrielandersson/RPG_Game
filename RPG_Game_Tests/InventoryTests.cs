using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using RPG_Game.Enums;
using RPG_Game.Items;
using RPG_Game.Shared;
using Xunit;
using Xunit.Sdk;

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
            Assert.Null(actual);
        }

        #endregion

        #region DeleteItemShouldRemoveItem
        [Fact]
        public void DeleteItemFromInventory_NewInventoryTwoWeapons_ShouldOnlyHaveOneLeft()
        {
            // Arrange
            var newInventory = new Inventory();
            var newWeapon = new Weapon("common axe", 1, WeaponCat.Axes, 7, 1.1);
            var newWeapon2 = new Weapon("common bow", 1, WeaponCat.Bows, 4, 5.5);
            newInventory.AddItemToInventory(newWeapon);
            newInventory.AddItemToInventory(newWeapon2);
            var expected = 1;

            //Act
            newInventory.DeleteItemFromInventory("common bow");
            var actual = newInventory.GetCount();
            // Assert 

            Assert.Equal(expected, actual);
        }
        #endregion
        #region DeleteItemFailure
        [Fact]
        public void DeleteItemFromInventory_NewInventoryWithoutItems_ShouldReturnExceptionMsg()
        {
            //Arrange
            var newInventory = new Inventory();
            //Act
            var exception = Record.Exception(() => newInventory.DeleteItemFromInventory("non existent bow"));
            //Assert
            Assert.IsType<NullReferenceException>(exception);
        }
        #endregion

    }
}

