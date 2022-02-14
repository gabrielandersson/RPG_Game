using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    public class Rogue : Hero
    {
        public Rogue(string name) : base(name)
        {

            EquippedItems = new Dictionary<Slot, Item>();
            PrimaryAttribute = new PrimaryAttribute(2, 6, 1);
            TotalAttribute = new TotalAttribute();
            TotalAttribute.Strength = PrimaryAttribute.Strength;
            TotalAttribute.Dexterity = PrimaryAttribute.Dexterity;
            TotalAttribute.Intelligence = PrimaryAttribute.Intelligence;
            Damage = 1 * (1 + (TotalAttribute.Dexterity / 100));
            HeroClass = HeroClass.Rogue;
        }

        public string EquipItem(string itemName)
        {
            try
            {
                var requestedItem = Inventory.GetItemFromInventory(itemName);
                if (requestedItem == null) return "No item with that name was found in the inventory!";
                if (requestedItem is Armor)
                {
                    if (requestedItem.RequiredLevel > Level) throw new InvalidArmorException("Too low lvl for this armor");
                    if ((requestedItem as Armor).Category == ArmorCat.Mail || (requestedItem as Armor).Category == ArmorCat.Leather)
                    {
                        if (EquippedItems.ContainsKey(requestedItem.Slot))
                        {
                            var backToInventory = EquippedItems[requestedItem.Slot];
                            Inventory.AddItemToInventory(backToInventory);
                            EquippedItems[requestedItem.Slot] = requestedItem;
                            Inventory.DeleteItemFromInventory(requestedItem.Name);
                            UpdateStats(requestedItem);
                            return "New armour equipped";
                        }
                        else
                        {
                            EquippedItems.Add(requestedItem.Slot, requestedItem);
                            Inventory.DeleteItemFromInventory(requestedItem.Name);
                            UpdateStats(requestedItem);
                            return "New armour equipped";
                        }
                    }
                    else
                    {
                        throw new InvalidArmorException("You can't equip armor of this category!");
                    }
                }
                if (requestedItem is Weapon)
                {
                    if (requestedItem.RequiredLevel > Level) throw new InvalidWeaponException("Too low lvl for this weapon");
                    if ((requestedItem as Weapon)?.Category == WeaponCat.Daggers || (requestedItem as Weapon)?.Category == WeaponCat.Swords)
                    {
                        if (EquippedItems.ContainsKey(requestedItem.Slot))
                        {
                            var backToInventory = EquippedItems[requestedItem.Slot];
                            Inventory.AddItemToInventory(backToInventory);
                            EquippedItems[requestedItem.Slot] = requestedItem;
                            Inventory.DeleteItemFromInventory(requestedItem.Name);

                            UpdateStats(requestedItem);
                            return "New weapon equipped!";

                        }
                        EquippedItems.Add(requestedItem.Slot, requestedItem);
                        Inventory.DeleteItemFromInventory(requestedItem.Name);
                        UpdateStats(requestedItem);
                        return "New weapon equipped!";
                    }
                    else
                    {
                        throw new InvalidWeaponException("You can't equip a weapon of this category!");
                    }

                }
            }
            catch (InvalidArmorException ex)
            {
                Console.WriteLine($"Exceptional custom exception: {ex.Message}");
            }
            catch (InvalidWeaponException ex)
            {
                Console.WriteLine($"Exceptional custom exception: {ex.Message}");
            }
            return "Something went wrong! The requested item existed but was not of type Armor or type Weapon!";
        }



        public void UpdateStats(Item item)
        {
            //cleara totalattributes och iterera sen igenom allt för att säkerställa att totalattributes blir rätt? 
            // om man tar bort ett item då? ta bort itemet först och cleara sen total attributes och gå sen igenom allt?
            // om vapnet som matas in från EquipItem är ett vapen då? det kan ju vara så att inget vapen finns sen tidigare
            // - meeen - det har isf redan blivit tillagt uppifrån i EquippedItems så det jag behöver bry mig om är om jag 
            // lägger till armor parts utan att ett vapen finns där.
            // om det är ett vapen som kommer in då? Det kommer iaf finnas med i listan isf - skiljer algoritmen sig om det är 
            // ett nytt vapen eller en förändring av vapen? 
            try
            {
                if (item == null) throw new ArgumentNullException("Empty argument");
                if ((!EquippedItems.ContainsKey(Slot.Weapon)) && item is Armor)
                {
                    TotalAttribute.Strength = 0;
                    TotalAttribute.Dexterity = 0;
                    TotalAttribute.Intelligence = 0;
                    foreach (KeyValuePair<Slot, Item> entry in EquippedItems)
                    {

                        TotalAttribute.Strength += (entry.Value as Armor).PrimaryAttribute.Strength + PrimaryAttribute.Strength;
                        TotalAttribute.Dexterity += (entry.Value as Armor).PrimaryAttribute.Dexterity + PrimaryAttribute.Dexterity;
                        TotalAttribute.Intelligence += (entry.Value as Armor).PrimaryAttribute.Intelligence + PrimaryAttribute.Intelligence;
                    }
                    Damage = 1 * (1 + ((TotalAttribute.Dexterity / 100)));
                }
                else if ((EquippedItems.ContainsKey(Slot.Weapon)) && item is Armor)
                {
                    TotalAttribute.Strength = 0;
                    TotalAttribute.Dexterity = 0;
                    TotalAttribute.Intelligence = 0;
                    foreach (KeyValuePair<Slot, Item> entry in EquippedItems)
                    {

                        TotalAttribute.Strength += (entry.Value as Armor).PrimaryAttribute.Strength + PrimaryAttribute.Strength;
                        TotalAttribute.Dexterity += (entry.Value as Armor).PrimaryAttribute.Dexterity + PrimaryAttribute.Dexterity;
                        TotalAttribute.Intelligence += (entry.Value as Armor).PrimaryAttribute.Intelligence + PrimaryAttribute.Intelligence;
                    }
                    var weapon = (EquippedItems[Slot.Weapon] as Weapon);
                    Damage = weapon.DamagePerSecond * (1 + ((TotalAttribute.Dexterity / 100)));
                }
                else if (item is Weapon)
                {
                    Damage = (item as Weapon).DamagePerSecond * ((1 + (TotalAttribute.Dexterity / 100)));
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public override void LevelUp()
        {
            PrimaryAttribute.Strength += 1;
            PrimaryAttribute.Dexterity += 4;
            PrimaryAttribute.Intelligence += 1;
            TotalAttribute.Strength += 1;
            TotalAttribute.Dexterity += 4;
            TotalAttribute.Intelligence += 1;

            if (!EquippedItems.ContainsKey(Slot.Weapon))
            {
                Damage = 1 * (1 + ((TotalAttribute.Dexterity / 100)));
            }
            Level++;
        }




    }
}
