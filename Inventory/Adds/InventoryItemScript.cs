using UnityEngine;
using UnityEngine.UI;

public class InventoryItemScript : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField]private GameObject SelectItem; 

    private string ItemName;
    private ItemsType itemType;
    private string itemData;
    private int index;
    private void Start() 
    {
        InventoryController.instance.OnsellectedItem+=OnsellectedItem;
    }
    
    public void SetData(string itemName,ItemsType itemtype,string itemdata,int Index)
    {
        index=Index;
        ItemName=itemName;
        itemData=itemdata;
        itemType=itemtype;
        switch(itemtype)
        {
            case ItemsType.BodyArmor:
                image.sprite=Resources.Load<Sprite>("");
                break;
            case ItemsType.LifeFlask:
                image.sprite=Resources.Load<Sprite>("");
                break;
            default:
                image.sprite=Resources.Load<Sprite>("");
                break;
        }
    }
    public void getData()
    {
        switch(itemType)
        {
            case ItemsType.LifeFlask:
                LifeFlask lifeFlask=JsonUtility.FromJson<LifeFlask>(itemData);
                break;
            case ItemsType.ManaFlask:
                ManaFlask manaFlask=JsonUtility.FromJson<ManaFlask>(itemData);
                break;
            case ItemsType.Food:
                Food food=JsonUtility.FromJson<Food>(itemData);
                break;
            case ItemsType.Sword:
                Sword sword=JsonUtility.FromJson<Sword>(itemData);
                break;
            case ItemsType.Dangger:
                Dagger dangger=JsonUtility.FromJson<Dagger>(itemData);
                break;
            case ItemsType.Gun:
                Gun gun=JsonUtility.FromJson<Gun>(itemData);
                break;
            case ItemsType.Bow:
                Bow bow=JsonUtility.FromJson<Bow>(itemData);
                break;
            default:
                break;
        }
    }

    public void SellectedItem()
    {
        InventoryController.instance.checkSellect();
        SelectItem.SetActive(true);
        InventoryController.instance.sellectedIndext=index;

    }

    private void OnsellectedItem(int sellectedIndex)
    {
        if(sellectedIndex!=index)
            SelectItem.SetActive(false);
    }

}
