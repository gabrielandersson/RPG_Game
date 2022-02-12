using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    internal class Rogue : Hero
    {

        private Dictionary<Slot, Item> EquippedItems = new Dictionary<Slot, Item>();
        public Rogue(string name) : base(name)
        {
            Damage = 1 * (1 + (6 / 100));
            EquippedItems = new Dictionary<Slot, Item>();
            PrimaryAttribute = new PrimaryAttribute(2, 6, 1);
            TotalAttribute = PrimaryAttribute.Strength + PrimaryAttribute.Dexterity + PrimaryAttribute.Intelligence;
            HeroClass = HeroClass.Rogue;
        }

        public void EquipItem(string itemName)
        {   // kolla om hero har rätt lvl om vapen har för hög lvl - invalidWeaponExc, same med armor fast invalidArmorExc
            // kolla om hero's class får ha den item typen   glöm inte ignorecase för att minimera fel // same custom exc for all
            // om det är en armor category som klassen inte får ha - throw custom exception 
            // om det är en weapon category som klassen inte får ha - throw custom exception
            
            // om nyckeln i Dictionary inte är unik - delete old - in with the new 
            // om det går igenom - uppdatera karaktärens primary och total attribute med värdena
            // om det går igenom - return string "New weapon/armor returned" 
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
         

        }
        public override void LevelUp()
        {
            PrimaryAttribute.Strength += 1;
            PrimaryAttribute.Dexterity += 4;
            PrimaryAttribute.Intelligence += 1;
            Level++;
        }




    }
}
