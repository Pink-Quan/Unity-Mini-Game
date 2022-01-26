using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Transform contend;
    [SerializeField] private InventoryItemScript prefab;
    [SerializeField] private ItemConfig itemConfig;
    
    InventoryItemList items=new InventoryItemList();
    public int sellectedIndext=0;
    public static InventoryController instance;
    public Action<int> OnsellectedItem;
    private void Awake() 
    {
        instance=this;
    }
    private void Start() 
    {
        RetrieveData();
        getItems();    
    }
    private void getItems()
    {
        for(int i=0;i<items.itemList.Count;i++)
        {
            InventoryItemScript tempPrefab=Instantiate(prefab,contend);
            tempPrefab.SetData(items.itemList[i].ItemName,items.itemList[i].itemType,items.itemList[i].itemData,i);

        }
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

    private void updateItem()
    {
        switch(items.itemList[sellectedIndext].itemType)
        {
            case ItemsType.LifeFlask:
                UpgradeLife();
                break;
            case ItemsType.ManaFlask:
            case ItemsType.Food:
                break;
            case ItemsType.Dangger:
            case ItemsType.Sword:
            case ItemsType.Gun:
            case ItemsType.Bow:
                break;
            case ItemsType.Gloves:
            case ItemsType.BodyArmor:
                break;
            default:
                break;
        }
    }
    private void UpgradeLife()
    {
        LifeFlask lf=JsonUtility.FromJson<LifeFlask>(items.itemList[sellectedIndext].itemData);
        lf.ItemTier++;
        lf.HPHealing=itemConfig.hPConfig.HPRestore(lf.ItemTier);
        items.itemList[sellectedIndext].itemData=JsonUtility.ToJson(lf);
        SaveData(JsonUtility.ToJson(items));
        RetrieveData();
        getItems();
    }
    public void checkSellect()
    {
        if(OnsellectedItem!=null)
            OnsellectedItem(sellectedIndext);
    }

    private void SaveData(string dataString)
    {
        string dataPath=ReadDataFromPersistent("InventoryData");
        File.WriteAllText(dataPath,dataString);
    }

}
