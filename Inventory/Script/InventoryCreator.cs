using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InventoryCreator : MonoBehaviour
{
    private void Awake() 
    {
        addLifeFlask(10,1,12,12,"Life Posion Level 1");
        addManaFlask(10,1,12,12,"Mana Posion Level 1");
        addFood(10,1,12,12,"Food 1");
        addGun(ItemsRarity.Common,10,1,15,100,"Hand Gun");
        addSword(ItemsRarity.Common,10,1,100,3,"Iron Sword");
        addBow(ItemsRarity.Uncommon,12,2,30,80,"Hard Bow");
        addDagger(ItemsRarity.Mythic,50,1,1,1000,"Mysthic Dagger");

        GenJson();
    }
    InventoryItemList items=new InventoryItemList();
    #region add Items
    private void addLifeFlask(float healing,int tier,int StackQuantity,int quantity,string name)
    {
        LifeFlask tempLifeFlask =new LifeFlask();
        InventoryItems tempInventoryItems=new InventoryItems();
        tempLifeFlask.HPHealing=HPRestore(tier);
        tempLifeFlask.ItemTier=tier;
        tempLifeFlask.Quantity=quantity;
        tempLifeFlask.StackQuantity=StackQuantity;
        tempInventoryItems.itemData=JsonUtility.ToJson(tempLifeFlask);
        tempInventoryItems.ItemName=name;
        tempInventoryItems.itemType=ItemsType.LifeFlask;
        items.itemList.Add(tempInventoryItems);
    }
    private void addManaFlask(float recovery,int tier,int StackQuantity,int quantity,string name)
    {
        ManaFlask temp =new ManaFlask();
        InventoryItems temp2=new InventoryItems();
        temp.ManaRecovery=recovery;
        temp.ItemTier=tier;
        temp.Quantity=quantity;
        temp.StackQuantity=StackQuantity;
        temp2.itemData=JsonUtility.ToJson(temp);
        temp2.ItemName=name;
        temp2.itemType=ItemsType.ManaFlask;
        items.itemList.Add(temp2);
    }
    private void addFood(float recovery,int tier,int StackQuantity,int quantity,string name)
    {
        Food temp =new Food();
        InventoryItems temp2=new InventoryItems();
        temp.HungerFill=recovery;
        temp.ItemTier=tier;
        temp.Quantity=quantity;
        temp.StackQuantity=StackQuantity;
        temp2.itemData=JsonUtility.ToJson(temp);
        temp2.ItemName=name;
        temp2.itemType=ItemsType.Food;
        items.itemList.Add(temp2);
    }
    private void addSword(ItemsRarity ir, float damge,int level,float Durability,float range,string name)
    {
        Sword temp=new Sword();
        InventoryItems temp2=new InventoryItems();
        temp.range=range;
        temp.Damge=damge;
        temp.Durability=Durability;
        temp.Level=level;
        temp.rarity=ir;
        temp2.ItemName=name;
        temp2.itemType=ItemsType.Sword;
        temp2.itemData=JsonUtility.ToJson(temp);
        items.itemList.Add(temp2);
    }
    private void addGun(ItemsRarity ir, float damge,int level,int Magazine,float Durability,string name)
    {
        Gun temp=new Gun();
        InventoryItems temp2=new InventoryItems();
        temp.Magazine=Magazine;
        temp.Damge=damge;
        temp.Durability=Durability;
        temp.Level=level;
        temp.rarity=ir;
        temp2.ItemName=name;
        temp2.itemType=ItemsType.Gun;
        temp2.itemData=JsonUtility.ToJson(temp);
        items.itemList.Add(temp2);
    }
    private void addBow(ItemsRarity ir, float damge,int level,int range,float Durability,string name)
    {
        Bow temp=new Bow();
        InventoryItems temp2=new InventoryItems();
        temp.range=range;
        temp.Damge=damge;
        temp.Durability=Durability;
        temp.Level=level;
        temp.rarity=ir;
        temp2.ItemName=name;
        temp2.itemType=ItemsType.Bow;
        temp2.itemData=JsonUtility.ToJson(temp);
        items.itemList.Add(temp2);
    }
    private void addDagger(ItemsRarity ir, float damge,int level,int range,float Durability,string name)
    {
        Dagger temp=new Dagger();
        InventoryItems temp2=new InventoryItems();
        temp.range=range;
        temp.Damge=damge;
        temp.Durability=Durability;
        temp.Level=level;
        temp.rarity=ir;
        temp2.ItemName=name;
        temp2.itemType=ItemsType.Dangger;
        temp2.itemData=JsonUtility.ToJson(temp);
        items.itemList.Add(temp2);
    }
    #endregion add Items

    private void GenJson()
    {
        //Debug.LogError(JsonUtility.ToJson(items));
        SaveDataToPersistent("InventoryData", JsonUtility.ToJson(items));
    }
    private void SaveDataToPersistent(string fileName, string dataString)
    {
        string dataPath = $"{Application.persistentDataPath}/{fileName}.txt";

        new System.Threading.Thread(() =>
        {
            File.WriteAllText(dataPath, dataString);
        }
        ).Start();
    }

    private void RetrieveData()
    {
        string dataString = ReadDataFromPersistent("InventoryData");
        if(dataString != "")
        {
            items = JsonUtility.FromJson<InventoryItemList>(dataString);
        }
        else
        {
            items = new InventoryItemList();
        }
    }

    private string ReadDataFromPersistent(string fileName)
    {
        string dataPath = $"{Application.persistentDataPath}/{fileName}.txt";
        if (System.IO.File.Exists(dataPath))
        {
            return System.IO.File.ReadAllText(dataPath);
        }
        else
        {
            return "";
        }
    }

    [SerializeField] private ItemConfig itemConfig;
    private float HPRestore(int Tier)
    {
        return itemConfig.hPConfig.HPRestore(Tier);
    }
}


