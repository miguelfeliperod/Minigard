using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public List<Slot> characterSlotList;
    public List<Slot> enemySlotList;
    public BattleInfo battleInfo;
    public TextMeshPro countdown;
    private PartyManager partyManager;

    bool fightIsOn = false;
    public bool FightIsOn => fightIsOn;

    public delegate void BattleState(bool state);
    public static event BattleState BattleStateEvent;

    List<Battler> charactersList = new List<Battler>();
    List<Battler> enemiesList = new List<Battler>();

    public List<Battler> CharactersList { get => charactersList; }
    public List<Battler> EnemiesList { get => enemiesList; }

    public bool IsAnyCharacterAlive
    {
        get
        {
            foreach (Battler character in charactersList)
            {
                if (character.IsAlive) return true;
            }
            return false;
        }
    }
    public bool IsAnyEnemyAlive
    {
        get
        {
            foreach (Battler enemy in enemiesList)
            {
                if (enemy.IsAlive) return true;
            }
            return false;
        }
    }

    bool IsBattleOver
    {
        get
        {
            return !IsAnyEnemyAlive || !IsAnyCharacterAlive;
        }
    }


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
        partyManager = GameManager.Instance.partyManager;
        SetBattleInfo();
        StartCoroutine(StartBattle());
    }

    void SetBattleInfo()
    {
        for (int characterSlotIndex = 0; characterSlotIndex < characterSlotList.Count; characterSlotIndex++)
        {
            if (partyManager.CountActiveCharacters > characterSlotIndex)
                SetCharacterSlot(characterSlotIndex);
            else 
                DisableCharacterSlot(characterSlotIndex);
        }
        for (int enemySlotIndex = 0; enemySlotIndex < enemySlotList.Count; enemySlotIndex++)
        {
            if (battleInfo.enemiesList.Count > enemySlotIndex)
                SetEnemySlot(enemySlotIndex);
            else 
                DisableEnemySlot(enemySlotIndex);
        }
    }

    void DisableCharacterSlot(Index slotIndex)
    {
        characterSlotList[slotIndex].DisableSlot();
    }

    void SetCharacterSlot(Index slotIndex) {
        characterSlotList[slotIndex].gameObject.SetActive(true);
        characterSlotList[slotIndex].Battler = partyManager.PartyList[slotIndex].Character;
        characterSlotList[slotIndex].SetBattlerData();
        charactersList.Add(characterSlotList[slotIndex].Battler);
    }

    void DisableEnemySlot(Index slotIndex)
    {
        enemySlotList[slotIndex].DisableSlot();
    }

    void SetEnemySlot(Index slotIndex)
    {
        enemySlotList[slotIndex].gameObject.SetActive(true);
        enemySlotList[slotIndex].Battler = Instantiate(battleInfo.enemiesList[slotIndex]); 
        enemySlotList[slotIndex].SetBattlerData();
        enemiesList.Add(enemySlotList[slotIndex].Battler);
    }

    void LateUpdate()
    {
        if (IsBattleOver)
        {
            fightIsOn = false;
            if (BattleStateEvent != null)
                BattleStateEvent(false);
        }
    }

    IEnumerator StartBattle()
    {
        countdown.text = "3";
        yield return new WaitForSeconds(1.0f);
        countdown.text = "2";
        yield return new WaitForSeconds(1.0f);
        countdown.text = "1";
        yield return new WaitForSeconds(1.0f);
        countdown.text = "FIGHT!";
        yield return new WaitForSeconds(1.0f);
        countdown.text = "";
        fightIsOn = true;

        if (BattleStateEvent != null)
            BattleStateEvent(true);
        yield return null;
    }

    public Battler GetRandomEnemy()
    {
        List<Battler> aliveEnemies = new List<Battler>();

        foreach (Enemy enemy in enemiesList)
        {
            if (enemy.CurrentHp > 0)
                aliveEnemies.Add(enemy);
        }
        return aliveEnemies[UnityEngine.Random.Range(0, aliveEnemies.Count)];
    }

    public Battler GetRandomCharacter()
    {
        List<Battler> aliveCharacters = new List<Battler>();

        foreach (Character character in charactersList)
        {
                if (character.CurrentHp > 0)
                    aliveCharacters.Add(character);
        }
        if (aliveCharacters.Count == 0) throw new System.Exception("Empty aliveCharacters List");

        return aliveCharacters[UnityEngine.Random.Range(0, 0)];
    }
}
