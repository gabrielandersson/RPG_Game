using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using RPG_Game.Enums;
using RPG_Game.Exceptions;
using RPG_Game.HeroClasses;
using RPG_Game.Items;

namespace RPG_Game.Shared
{
    public class EquipHandler
    {
        /// <summary>
        ///  This method checks if the item passed the specific requirements for the Mage class.
        ///  Its primarily used by the EquipItem() and is thus not made accessible to anyone else.
        ///  Might throw InvalidArmorException/InvalidWeaponException or NullReferenceException
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="hero"></param>
        /// <returns></returns>
        private string IsValidForMage(string itemName, Hero hero)
        {
            try
            {
                var requestedItem = hero.Inventory.GetItemFromInventory(itemName);
                return requestedItem switch
                {
                    Armor when requestedItem.RequiredLevel > hero.Level => throw new InvalidArmorException(
                        "Too low lvl for this armor"),
                    Armor { Category: ArmorCat.Cloth } => "true",
                    Armor => throw new InvalidArmorException("You can't equip armor of this category!"),
                    Weapon when requestedItem.RequiredLevel > hero.Level => throw new InvalidWeaponException(
                        "Too low lvl for this weapon"),
                    Weapon { Category: WeaponCat.Staffs or WeaponCat.Wands } =>
                        "true",
                    Weapon => throw new InvalidWeaponException("You can't equip a weapon of this category!"),
                    _ => "false"
                };
            }
            catch (InvalidArmorException ex)
            {
                return ex.Message;
            }
            catch (InvalidWeaponException ex)
            {
                return ex.Message;
            }
            catch (NullReferenceException ex)
            {
                return ex.Message;
            }

        }

        /// <summary>
        ///  This method checks if the item passed the specific requirements for the Warrior class.
        ///  Its primarily used by the EquipItem() and is thus not made accessible to anyone else.
        ///  Might throw InvalidArmorException/InvalidWeaponException or NullReferenceException
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="hero"></param>
        /// <returns></returns>
        private string IsValidForWarrior(string itemName, Hero hero)
        {
            try
            {
                var requestedItem = hero.Inventory.GetItemFromInventory(itemName);
                return requestedItem switch
                {
                    Armor armor when armor.RequiredLevel > hero.Level => throw new InvalidArmorException(
                        "Too low lvl for this armor"),
                    Armor { Category: ArmorCat.Plate or ArmorCat.Mail } => "true",
                    Armor => throw new InvalidArmorException("You can't equip armor of this category!"),
                    Weapon weapon when weapon.RequiredLevel > hero.Level => throw new InvalidWeaponException(
                        "Too low lvl for this weapon"),
                    Weapon { Category: WeaponCat.Axes or WeaponCat.Swords or WeaponCat.Hammers } =>
                        "true",
                    Weapon => throw new InvalidWeaponException("You can't equip a weapon of this category!"),
                    _ => "false"
                };
            }
            catch (InvalidArmorException ex)
            {
                return ex.Message;
            }
            catch (InvalidWeaponException ex)
            {
                return ex.Message;
            }
            catch (NullReferenceException ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        ///  This method checks if the item passed the specific requirements for the Ranger class.
        ///  Its primarily used by the EquipItem() and is thus not made accessible to anyone else
        ///  Might throw InvalidArmorException/InvalidWeaponException or NullReferenceException
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="hero"></param>
        /// <returns></returns>
        private string IsValidForRanger(string itemName, Hero hero)
        {
            try
            {
                var requestedItem = hero.Inventory.GetItemFromInventory(itemName);
                if (requestedItem is Armor armor)
                {
                    if (armor.RequiredLevel > hero.Level)
                        throw new InvalidArmorException("Too low lvl for this armor");
                    if (armor.Category is ArmorCat.Leather or ArmorCat.Mail)
                    {
                        return "true";
                    }
                    throw new InvalidArmorException("You can't equip armor of this category!");
                }

                if (requestedItem is not Weapon weapon) return "false";
                if (weapon.RequiredLevel > hero.Level)
                    throw new InvalidWeaponException("Too low lvl for this weapon");
                if (weapon.Category == WeaponCat.Bows)
                {
                    return "true";
                }

                throw new InvalidWeaponException("You can't equip a weapon of this category!");
            }
            catch (InvalidArmorException ex)
            {
                return ex.Message;
            }
            catch (InvalidWeaponException ex)
            {
                return ex.Message;
            }
            catch (NullReferenceException ex)
            {
                return ex.Message;
            }

        }
        /// <summary>
        ///  This method checks if the item passed the specific requirements for the Rogue class.
        ///  Its primarily used by the EquipItem() and is thus not made accessible to anyone else.
        ///  Might throw InvalidArmorException/InvalidWeaponException or NullReferenceException
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="hero"></param>
        /// <returns></returns>
        private string IsValidForRogue(string itemName, Hero hero)
        {
            try
            {
                var requestedItem = hero.Inventory.GetItemFromInventory(itemName);
                if (requestedItem is Armor armor)
                {
                    if (armor.RequiredLevel > hero.Level)
                        throw new InvalidArmorException("Too low lvl for this armor");
                    if (armor.Category == ArmorCat.Leather ||
                        armor.Category == ArmorCat.Mail)
                    {
                        return "true";
                    }

                    throw new InvalidArmorException("You can't equip armor of this category!");
                }

                if (requestedItem is Weapon weapon)
                {
                    if (weapon.RequiredLevel > hero.Level)
                        throw new InvalidWeaponException("Too low lvl for this weapon");
                    if (weapon.Category == WeaponCat.Daggers ||
                        weapon.Category == WeaponCat.Swords)
                    {
                        return "true";
                    }

                    throw new InvalidWeaponException("You can't equip a weapon of this category!");
                }

                return "false";

            }
            catch (InvalidArmorException ex)
            {
                return ex.Message;
            }
            catch (InvalidWeaponException ex)
            {
                return ex.Message;
            }
            catch (NullReferenceException ex)
            {
                return ex.Message;
            }

        }



        /// <summary>
        /// This method calls on the right IsValid check. If a slot is already occupied it switches the items and
        /// puts the previous slot occupier back into  the inventory. 
        /// Then it proceeds to call UpdateStats(). Needs some decoupling love.
        /// Can throw an ArgumentNullException and proceeds to return the message.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="hero"></param>
        /// <returns></returns>
        public string EquipItem(string itemName, Hero hero)
        {
            try
            {
                if (itemName == null || hero == null) throw new ArgumentNullException();
                var requestedItem = hero.Inventory.GetItemFromInventory(itemName);
                if (requestedItem.Name.Length == 0) return "Item could not be found";

                var validityCheck = hero switch
                {
                    Warrior => IsValidForWarrior(itemName, hero),
                    Mage => IsValidForMage(itemName, hero),
                    Ranger => IsValidForRanger(itemName, hero),
                    Rogue => IsValidForRogue(itemName, hero),
                    _ => "false"
                };

                if (validityCheck == "true")
                {
                    var type = requestedItem is Armor ? "armour" : "weapon";
                    if (hero.EquippedItems != null && hero.EquippedItems.ContainsKey(requestedItem.Slot))
                    {

                        var backToInventory = hero.EquippedItems[requestedItem.Slot];
                        hero.Inventory.AddItemToInventory(backToInventory);
                        hero.EquippedItems[requestedItem.Slot] = requestedItem;
                        hero.Inventory.DeleteItemFromInventory(requestedItem.Name);
                        UpdateStats(hero);
                        return $"New {type} equipped!";
                    }

                    if (hero.EquippedItems != null) hero.EquippedItems.Add(requestedItem.Slot, requestedItem);
                    hero.Inventory.DeleteItemFromInventory(requestedItem.Name);
                    UpdateStats(hero);
                    return $"New {type} equipped!";
                }

                if (validityCheck != "true")
                {
                    return validityCheck;
                }
            }
            catch (ArgumentNullException ex)
            {
                return ex.Message;
            }
            return "Something went wrong! We're sorry!";
        }

        /// <summary>
        /// This methods primary purpose is to extract the totalPrimary attribute from the hero
        /// Might throw Null reference error. It should not. Compilator says nothing, and it usually has some
        /// pretty strong opinions about this kind of stuff.
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        private double GetPrimaryValue(Hero hero)
        {
            try
            {
                if (hero.TotalAttribute == null) return 0.0;
                double totalPrimary = hero switch
                {
                    Warrior => hero.TotalAttribute.Strength,
                    Mage => hero.TotalAttribute.Intelligence,
                    Ranger => hero.TotalAttribute.Dexterity,
                    Rogue => hero.TotalAttribute.Dexterity,
                    _ => 0.0
                };

                return totalPrimary;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("You have designed the calling method wrong somehow!");
            }
        }

        /// <summary>
        /// clears the total attribute when called and iterates over the equipped items
        /// calls on the GetPrimaryValue(). Can throw Null reference/KeyNotFoundException 
        /// </summary>
        /// <param name="hero"></param>
        public void UpdateStats(Hero hero)
        {
            try
            {
                if (hero.TotalAttribute != null)
                {
                    if (hero.EquippedItems != null && (hero.EquippedItems.ContainsKey(Slot.Body)
                                                       || hero.EquippedItems.ContainsKey(Slot.Head)
                                                       || hero.EquippedItems.ContainsKey(Slot.Legs)))

                        hero.TotalAttribute.Strength = 0;
                    hero.TotalAttribute.Dexterity = 0;
                    hero.TotalAttribute.Intelligence = 0;
                    var counter = 0;

                    foreach (KeyValuePair<Slot, Item> entry in hero.EquippedItems)
                    {
                        if (entry.Key == Slot.Weapon) continue;
                        //Only add hero's default primary first time
                        if (counter == 0)
                        {
                            hero.TotalAttribute.Strength += ((Armor)entry.Value).PrimaryAttribute.Strength +
                                                                             hero.PrimaryAttribute.Strength;
                            hero.TotalAttribute.Dexterity += ((Armor)entry.Value).PrimaryAttribute.Dexterity +
                                                                             hero.PrimaryAttribute.Dexterity;
                            hero.TotalAttribute.Intelligence +=
                                                            ((Armor)entry.Value).PrimaryAttribute.Intelligence +
                                                                             hero.PrimaryAttribute.Intelligence;
                            counter++;
                        }
                        //Afterwards only add the other armor piece attributes
                        else
                        {
                            if (entry.Key == Slot.Weapon) continue;
                            hero.TotalAttribute.Strength += ((Armor)entry.Value).PrimaryAttribute.Strength;
                            hero.TotalAttribute.Dexterity += ((Armor)entry.Value).PrimaryAttribute.Dexterity;
                            hero.TotalAttribute.Intelligence += ((Armor)entry.Value).PrimaryAttribute.Intelligence;
                        }
                    }
                }

                if (hero.EquippedItems != null && (!hero.EquippedItems.ContainsKey(Slot.Weapon)))
                {
                    //Doing standard damage calculation since this assumes no weapon exists.
                    var totalPrimary = GetPrimaryValue(hero);
                    hero.Damage = 1.0 * (1.0 + (totalPrimary / 100.0));
                }
                else if (hero.EquippedItems != null && (hero.EquippedItems.ContainsKey(Slot.Weapon)))
                {
                    //Fetch already equipped weapon and use it for calculation
                    var weapon = hero.EquippedItems[Slot.Weapon] as Weapon;
                    var totalPrimary = GetPrimaryValue(hero);
                    if (weapon != null) hero.Damage = weapon.DamagePerSecond * (1.0 + (totalPrimary / 100.0));
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
