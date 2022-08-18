using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Button AllButton;
    [SerializeField] Button WeaponButton;
    [SerializeField] Button HeadButton;
    [SerializeField] Button ChestButton;
    [SerializeField] Button FootButton;
    [SerializeField] Button AccessoryButton;

    [SerializeField] GameObject AllBG;
    [SerializeField] GameObject WeaponBG;
    [SerializeField] GameObject HeadBG;
    [SerializeField] GameObject ChestBG;
    [SerializeField] GameObject FootBG;
    [SerializeField] GameObject AccessoryBG;

    public void DisableAllBG()
    {
        AllBG.SetActive(false);
        WeaponBG.SetActive(false);
        HeadBG.SetActive(false);
        ChestBG.SetActive(false);
        FootBG.SetActive(false);
        AccessoryBG.SetActive(false);
    }
}