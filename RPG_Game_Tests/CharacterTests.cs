using RPG_Game;
using System;
using System.Net.WebSockets;
using System.Reflection;
using Xunit;

namespace RPG_Game_Tests
{
    public class CharacterTests
    {
        #region CreateWarrior
        [Fact]
        public void Constructor_InitalizedWarrior_ShouldCreateACharacterWithDefaultStats()
        {
            // Arrange
            string name = "gabriel";
            int expectedLvl = 1;
            double expectedStrength = 5;
            double expectedDexterity = 2;
            double expectedIntelligence = 1;
            // Act
            Warrior actual = new Warrior(name);
            // Assert
            Assert.True(expectedLvl == actual.Level && expectedStrength == actual.PrimaryAttribute.Strength
                         && expectedDexterity == actual.PrimaryAttribute.Dexterity
                         && expectedIntelligence == actual.PrimaryAttribute.Intelligence);
        }
        #endregion
        #region CreateRogue
        [Fact]
        public void Constructor_InitializedRogue_ShouldCreateACharacterWithDefaultStats()
        {
            // Arrange
            string name = "gabriel";
            int expectedLvl = 1;
            double expectedStrength = 2;
            double expectedDexterity = 6;
            double expectedIntelligence = 1;
            // Act
            Rogue actual = new Rogue(name);
            // Assert
            Assert.True(expectedLvl == actual.Level && expectedStrength == actual.PrimaryAttribute.Strength
                         && expectedDexterity == actual.PrimaryAttribute.Dexterity
                         && expectedIntelligence == actual.PrimaryAttribute.Intelligence);
        }
        #endregion
        #region CreateMage
        [Fact]
        public void Constructor_InitializedMage_ShouldCreateACharacterWithDefaultStats()
        {
            // Arrange
            string name = "gabriel";
            int expectedLvl = 1;
            double expectedStrength = 1;
            double expectedDexterity = 1;
            double expectedIntelligence = 8;
            // Act
            Mage actual = new Mage(name);
            // Assert
            Assert.True(expectedLvl == actual.Level && expectedStrength == actual.PrimaryAttribute.Strength
                         && expectedDexterity == actual.PrimaryAttribute.Dexterity
                         && expectedIntelligence == actual.PrimaryAttribute.Intelligence);
        }
        #endregion
        #region CreateRanger
        [Fact]
        public void Constructor_InitializedRanger_ShouldCreateACharacterWithDefaultStats()
        {
            // Arrange
            string name = "gabriel";
            int expectedLvl = 1;
            double expectedStrength = 1;
            double expectedDexterity = 7;
            double expectedIntelligence = 1;
            // Act
            Ranger actual = new Ranger(name);
            // Assert
            Assert.True(expectedLvl == actual.Level && expectedStrength == actual.PrimaryAttribute.Strength
                         && expectedDexterity == actual.PrimaryAttribute.Dexterity
                         && expectedIntelligence == actual.PrimaryAttribute.Intelligence);
        }
        #endregion

        #region WarriorLevelUp

        [Fact]
        public void LevelUp_NewWarrior_ShouldHaveRightStats()
        {
            // Arrange 
            string name = "gabriel";
            int expectedLvl = 2;
            double expectedStrength = 8;
            double expectedDexterity = 4;
            double expectedIntelligence = 2;
            Warrior actual = new Warrior(name);
            // Act
            actual.LevelUp();
            // Assert
            Assert.True(expectedLvl == actual.Level && expectedStrength == actual.PrimaryAttribute.Strength
                        && expectedDexterity == actual.PrimaryAttribute.Dexterity
                        && expectedIntelligence == actual.PrimaryAttribute.Intelligence);
        }
        #endregion

        #region RogueLevelUp
        [Fact]
        public void LevelUp_NewRogue_ShouldHaveRightStats()
        {
            // Arrange 
            string name = "gabriel";
            int expectedLvl = 2;
            double expectedStrength = 3;
            double expectedDexterity = 10;
            double expectedIntelligence = 2;
            Rogue actual = new Rogue(name);
            // Act
            actual.LevelUp();
            // Assert
            Assert.True(expectedLvl == actual.Level && expectedStrength == actual.PrimaryAttribute.Strength
                        && expectedDexterity == actual.PrimaryAttribute.Dexterity
                        && expectedIntelligence == actual.PrimaryAttribute.Intelligence);
        }
        #endregion

        #region MageLevelUp
        [Fact]
        public void LevelUp_NewMage_ShouldHaveRightStats()
        {
            // Arrange 
            string name = "gabriel";
            int expectedLvl = 2;
            double expectedStrength = 2;
            double expectedDexterity = 2;
            double expectedIntelligence = 13;
            Mage actual = new Mage(name);
            // Act
            actual.LevelUp();
            // Assert
            Assert.True(expectedLvl == actual.Level && expectedStrength == actual.PrimaryAttribute.Strength
                        && expectedDexterity == actual.PrimaryAttribute.Dexterity
                        && expectedIntelligence == actual.PrimaryAttribute.Intelligence);
        }
        #endregion
        #region RangerLevelUp
        [Fact]
        public void LevelUp_NewRanger_ShouldHaveRightStats()
        {
            // Arrange 
            string name = "gabriel";
            int expectedLvl = 2;
            double expectedStrength = 2;
            double expectedDexterity = 12;
            double expectedIntelligence = 2;
            Ranger actual = new Ranger(name);
            // Act
            actual.LevelUp();
            // Assert
            Assert.True(expectedLvl == actual.Level && expectedStrength == actual.PrimaryAttribute.Strength
                        && expectedDexterity == actual.PrimaryAttribute.Dexterity
                        && expectedIntelligence == actual.PrimaryAttribute.Intelligence);
        }
        #endregion

        #region WarriorHaveCorrectDamage
        [Fact]
        public void Constructor_NewWarriorNoWeaponEquipped_ShouldGiveCorrectDamage()
        {
            //Arrange
            var newWarrior = new Warrior("gabriel");
            double expected = 1.0 * (1 + (5.0 / 100)); // 1*(1+(5/100))
            //Act 
            var actual = newWarrior.Damage;
            //Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region WarriorWithWeaponDealCorrectDamage
        [Fact]
        public void Constructor_NewWarriorValidWeaponEquipped_ShouldGiveCorrectDamage()
        {
            // Arrange 
            var newWarrior = new Warrior("gabriel");
            var newWeapon = new Weapon("NerfSword", 1, WeaponCat.Swords, 1, 2);
            newWarrior.Inventory.AddItemToInventory(newWeapon);
            newWarrior.EquipItem(newWeapon.Name);
            double expected = 2.0 * (1.0 + (5.0 / 100));
            // Act 
            var actual = newWarrior.Damage;
            //Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region WarriorWithWeaponAndArmorHaveCorrectDamage
        [Fact]
        public void Constructor_NewWarriorWithValidWeaponAndArmorEquipped_ShouldGiveCorrectDamage()
        {
            // Arrange
            var newWarrior = new Warrior("gabriel");
            var newWeapon = new Weapon("NerfSword", 1, WeaponCat.Swords, 1, 2);
            var newArmor = new Armor("Sweaty Chainmail Pants", 1, Slot.Legs, ArmorCat.Mail,
                new PrimaryAttribute(4, 3, 3));

            newWarrior.Inventory.AddItemToInventory(newWeapon);
            newWarrior.Inventory.AddItemToInventory(newArmor);
            newWarrior.EquipItem(newWeapon.Name);
            newWarrior.EquipItem(newArmor.Name);
            double expected = 2.1;
            // Act
            double actual = newWarrior.Damage;
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region WarriorWithArmorShouldHaveCorrectTotalAttribute
        [Fact]
        public void Constructor_NewWarriorWithValidArmorEquipped_ShouldHaveCorrectTotalAttributeStrength()
        {
            var newWarrior = new Warrior("gabriel");
            var newArmor = new Armor("Sweaty Chainmail Pants", 1, Slot.Legs, ArmorCat.Mail,
               new PrimaryAttribute(4, 3, 3));

            newWarrior.Inventory.AddItemToInventory(newArmor);
            newWarrior.EquipItem(newArmor.Name);
            TotalAttribute expected = new TotalAttribute();
            expected.Strength = 9;
            expected.Dexterity = 5;
            expected.Intelligence = 4;
            // Act
            TotalAttribute actual = newWarrior.TotalAttribute;
            // Assert
            Assert.Equal(expected.Strength, actual.Strength);
        }
        #endregion
    }
}

