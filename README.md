# RPG_Game

## Assumptions / Notes from Author 

I handle the equippItems and Inventory as two separate storage entities, so for example,
when i change from a previous to a new weapon the previous weapon should be returned to the inventory. 

**Important** items need to be added to the inventory before trying to equip them, 
any item might be added to the inventory but invalid items will not be equipped.

I decided to put an 10 items limit on the Inventory for now. Might change it later on.

I might implement operator overloading at a later stage. 

The equiphandler gets a lot of responsibility right now, at some stage i would like to break out the 
validation logic from it. 

I hope you will enjoy this project! 

@gabrielandersson
