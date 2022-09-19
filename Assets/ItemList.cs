using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{
    [SerializeField] public Item item;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemQuantity;
    [SerializeField] Image itemImage;

    InventoryManager inventoryManager;
    
    public void SetItemData(Item item)
    {
        this. item = item;
        itemName.text = item.itemName;
        itemImage.sprite = item.sprite;
        itemImage.color = item.spriteColor;
        if (item is Collectable) {
            var collectable = item as Collectable;
            itemQuantity.text = collectable.quantity.ToString() + "x";
        }
        else
        {
            itemQuantity.text = "";
        }
    }

    public void SetInventoryManager(InventoryManager inventoryManager)
    {
        this.inventoryManager = inventoryManager;
    }

    public void OnClickShowItemInfo()
    {
        inventoryManager.selectedItem = this;

        if (inventoryManager.currentTab == ItemsTabs.Collectable)
        {
            inventoryManager.EnableSlider();
        }
        inventoryManager.EnableSellButton();
        inventoryManager.NameText.text = item.itemName;
        inventoryManager.PriceText.text = item.price.ToString();
        inventoryManager.DescriptionText.text = item.description;

        inventoryManager.RefreshSlider();
    }
}
