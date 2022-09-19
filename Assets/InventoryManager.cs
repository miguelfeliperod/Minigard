using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ItemsTabs
{
    Collectable,
    Hand,
    Head,
    Chest,
    Foot,
    Accessory
}

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] ItemList itemListPrefab;
    [SerializeField] ScrollRect scrollRect;

    [SerializeField] Button CollectableButton;
    [SerializeField] Button WeaponButton;
    [SerializeField] Button HeadButton;
    [SerializeField] Button ChestButton;
    [SerializeField] Button FootButton;
    [SerializeField] Button AccessoryButton;

    [SerializeField] GameObject CollectableBG;
    [SerializeField] GameObject WeaponBG;
    [SerializeField] GameObject HeadBG;
    [SerializeField] GameObject ChestBG;
    [SerializeField] GameObject FootBG;
    [SerializeField] GameObject AccessoryBG;

    [SerializeField] TextMeshProUGUI nameText;
    public TextMeshProUGUI NameText { get => nameText; }
    [SerializeField] TextMeshProUGUI priceText;
    public TextMeshProUGUI PriceText { get => priceText; }
    [SerializeField] TextMeshProUGUI descriptionText;
    public TextMeshProUGUI DescriptionText { get => descriptionText; }

    [SerializeField] TextMeshProUGUI itensCount;
    [SerializeField] Slider itemCountSlider;
    [SerializeField] Button minusButton;
    [SerializeField] Button plusButton;
    [SerializeField] Button sellButton;

    public ItemList selectedItem = null;
    public ItemsTabs currentTab = ItemsTabs.Collectable;

    void OnEnable()
    {
        CollectionTabClick();
        DisableSlider();
        selectedItem = null;
        ClearInfo();
    }

    void RefreshCurrentTab()
    {
        switch (currentTab)
        {
            case ItemsTabs.Collectable:
                CollectionTabClick();
                break;
            case ItemsTabs.Hand:
                HandTabClick();
                break;
            case ItemsTabs.Head:
                HeadTabClick();
                break;
            case ItemsTabs.Chest:
                ChestTabClick();
                break;
            case ItemsTabs.Foot:
                FootTabClick();
                break;
            case ItemsTabs.Accessory:
                AccessoryTabClick();
                break;
        }
    }

    void DisableSlider()
    {
        itensCount.gameObject.SetActive(false);
        itemCountSlider.gameObject.SetActive(false);
        minusButton.gameObject.SetActive(false);
        plusButton.gameObject.SetActive(false);
    }

    public void EnableSlider()
    {
        itensCount.gameObject.SetActive(true);
        itemCountSlider.gameObject.SetActive(true);
        minusButton.gameObject.SetActive(true);
        plusButton.gameObject.SetActive(true);
        sellButton.gameObject.SetActive(true);
    }

    public void EnableSellButton()
    {
        sellButton.gameObject.SetActive(true);
    }

    void DisableAllBG()
    {
        CollectableBG.SetActive(false);
        WeaponBG.SetActive(false);
        HeadBG.SetActive(false);
        ChestBG.SetActive(false);
        FootBG.SetActive(false);
        AccessoryBG.SetActive(false);
        ClearInfo();
    }

    void ClearInfo()
    {
        nameText.text = "";
        priceText.text = "";
        descriptionText.text = "";
        DisableSlider();
        sellButton.gameObject.SetActive(false);
    }

    public void CollectionTabClick()
    {
        DisableAllBG();
        ClearContentList();

        currentTab = ItemsTabs.Collectable;

        CollectableBG.SetActive(true);
        foreach (Collectable item in GameManager.Instance.collectableInventory)
        {
           if(item.quantity > 0){
                var newItem = Instantiate(itemListPrefab, content.transform);
                newItem.SetItemData(item);
                newItem.SetInventoryManager(this);
            }
        }
    }

    public void HandTabClick()
    {
        DisableAllBG();
        ClearContentList();

        currentTab = ItemsTabs.Hand;

        WeaponBG.SetActive(true);
        foreach (Equipment equip in GameManager.Instance.equipmentInventory)
        {
            if(equip is HandEquipment)
            {
                var newItem = Instantiate(itemListPrefab, content.transform);
                newItem.SetItemData(equip);
                newItem.SetInventoryManager(this);
            }
        }
    }

    public void HeadTabClick()
    {
        DisableAllBG();
        ClearContentList();

        currentTab = ItemsTabs.Head;

        HeadBG.SetActive(true);
        foreach (Equipment equip in GameManager.Instance.equipmentInventory)
        {
            if (equip is Head)
            {
                var newItem = Instantiate(itemListPrefab, content.transform);
                newItem.SetItemData(equip);
                newItem.SetInventoryManager(this);
            }
        }
    }

    public void ChestTabClick()
    {
        DisableAllBG();
        ClearContentList();

        currentTab = ItemsTabs.Chest;

        ChestBG.SetActive(true);
        foreach (Equipment equip in GameManager.Instance.equipmentInventory)
        {
            if (equip is Chest)
            {
                var newItem = Instantiate(itemListPrefab, content.transform);
                newItem.SetItemData(equip);
                newItem.SetInventoryManager(this);
            }
        }
    }

    public void FootTabClick()
    {
        DisableAllBG();
        ClearContentList();

        currentTab = ItemsTabs.Foot;

        FootBG.SetActive(true);
        foreach (Equipment equip in GameManager.Instance.equipmentInventory)
        {
            if (equip is Foot)
            {
                var newItem = Instantiate(itemListPrefab, content.transform);
                newItem.SetItemData(equip);
                newItem.SetInventoryManager(this);
            }
        }
    }

    public void AccessoryTabClick()
    {
        DisableAllBG();
        ClearContentList();

        currentTab = ItemsTabs.Accessory;

        AccessoryBG.SetActive(true);
        foreach (Equipment equip in GameManager.Instance.equipmentInventory)
        {
            if (equip is Accessory)
            {
                var newItem = Instantiate(itemListPrefab, content.transform);
                newItem.SetItemData(equip);
                newItem.SetInventoryManager(this);
            }
        }
    }

    void ClearContentList()
    {
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void RefreshSlider()
    {
        if (selectedItem.item is Collectable)
        {
            var collectable = selectedItem.item as Collectable;
            itemCountSlider.minValue = 0;
            itemCountSlider.maxValue = collectable.quantity;
        }
        RefreshItemCounter();
    }

    public void OnPlusButtonClick()
    {
        if (selectedItem.item is Collectable)
        {
            var collectable = selectedItem.item as Collectable;
            itemCountSlider.value = Mathf.Min(collectable.quantity, itemCountSlider.value + 1);
        }
        RefreshSlider();
    }

    public void OnMinusButtonClick()
    {
        if (selectedItem.item is Collectable)
        {
            var collectable = selectedItem.item as Collectable;
            itemCountSlider.value = Mathf.Max(1, itemCountSlider.value - 1);
        }
        RefreshSlider();
    }

    public void OnSellButtonClick()
    {
        if (selectedItem.item is Collectable)
        {
            var collectable = selectedItem.item as Collectable;
            GameManager.Instance.goldAmount += (int)(0.3f * collectable.price * itemCountSlider.value);
            collectable.quantity -= (int)itemCountSlider.value;
        }
        else if (selectedItem.item is Equipment)
        {
            var equipment = selectedItem.item as Equipment;
            GameManager.Instance.goldAmount += (int)(0.3f * equipment.price);
            GameManager.Instance.equipmentInventory.Remove(equipment);
        }
        else { }
        RefreshCurrentTab();
        RefreshSlider();
    }

    public void RefreshItemCounter()
    {
        itensCount.text = itemCountSlider.value.ToString();
    }
}