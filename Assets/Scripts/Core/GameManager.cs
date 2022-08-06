using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PartyManager partyManager = new PartyManager();
    public static GameManager Instance;

    [SerializeField] Character prefabCharacter;
    public Character PrefabCharacter { get => prefabCharacter; }

    [SerializeField] ClassesList classList;
    public ClassesList ClassList { get => classList; }

    [SerializeField] RacesList raceList;
    public RacesList RaceList { get => raceList; }

    public GameObject playerCharacters;


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
