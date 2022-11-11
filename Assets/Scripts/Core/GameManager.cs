using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dictionary<string, int> inventoryDictionary = new Dictionary<string, int>();
    [SerializeField] CollectableList collectableList;
    public PartyManager partyManager = new PartyManager();
    public List<Collectable> collectableInventory = new List<Collectable>();
    public List<Equipment> equipmentInventory = new List<Equipment>();
    public static GameManager Instance;
    public int goldAmount;

    [SerializeField] ClassesList classList;
    public ClassesList ClassList { get => classList; }

    [SerializeField] RacesList raceList;
    public RacesList RaceList { get => raceList; }

    public SpritesReferences SpritesReferences;

    public ColorIndex ColorIndex;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        BuildInventory();
    }

    void BuildInventory()
    {
        for (int itemIndex = 0; itemIndex < collectableList.collectables.Count; itemIndex++)
        {
            collectableInventory.Add(Instantiate(collectableList.collectables[itemIndex]));
            inventoryDictionary.Add(collectableList.collectables[itemIndex].itemName, itemIndex);
        }
    }
}
