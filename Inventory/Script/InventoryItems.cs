using System.Diagnostics.Contracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class InventoryItems
{
    public string ItemName;
    public ItemsType itemType;
    public string itemData;

}
[Serializable]
public class InventoryItemList
{
    public List<InventoryItems> itemList =new List<InventoryItems>();
}
[Serializable]
public enum ItemsType
{
    LifeFlask=1, ManaFlask=2, Food=3, 
    Sword=4,Dangger=5, Gun=11, Bow=12, 
    BodyArmor=6, Gloves=7,
    QuestItem=8,
    CraftMaterial=9,
}
[Serializable]
public enum ItemsRarity
{
        Common=1, Uncommon=2, Rare=3, Epic=4, Lengend=5, Mythic=6 
}

#region Consumable Items class
[Serializable]
public class ConsumableItems
{
    public int ItemTier;
    public int StackQuantity;
    public int Quantity;

}
[Serializable]
public class LifeFlask : ConsumableItems
{
    public float HPHealing;
}
[Serializable]
public class ManaFlask : ConsumableItems
{
    public float ManaRecovery;
}
[Serializable]
public class Food : ConsumableItems
{
    public float HungerFill;
}

#endregion Consumable Items class

#region  Weapon Items
[Serializable]
public class Weapon
{
    public ItemsRarity rarity;
    public float Damge;
    public int Level;
    public float Durability;
}
[Serializable]
public class Sword:Weapon
{
    public float range;
}
public class Dagger:Weapon
{
    public float range;
}
public class Gun:Weapon
{
    public int Magazine;
}
public class Bow:Weapon
{
    public float range;
}
#endregion Weapon Items

#region  Armor Items
[Serializable]
public class Armour
{
    public ItemsRarity rarity;
    public float ArmourValue;
    public int Level;
    public float Durability;
}
[Serializable]
public class Helmet:Armour
{

}
[Serializable]
public class Pant :Armour
{
    
}
[Serializable]
public class Gloves :Armour
{
       
}
#endregion

