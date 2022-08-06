using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PartyManager partyManager = new PartyManager();
    public static GameManager Instance;

    [SerializeField] ClassesList classList;
    public ClassesList ClassList { get => classList; }

    [SerializeField] RacesList raceList;
    public RacesList RaceList { get => raceList; }

    public SpritesReferences SpritesReferences;

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
}
