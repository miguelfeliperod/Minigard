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
        for (int i = 0; i < Math.Min(characterSlotList.Count, partyManager.CountActiveCharacters); i++)
        {
            characterSlotList[i].Battler = partyManager.PartyList[i].Character;
            characterSlotList[i].SetBattler();
        }
        for (int i = 0; i < Math.Min(enemySlotList.Count, battleInfo.enemiesList.Count); i++)
        {
            enemySlotList[i].Battler = battleInfo.enemiesList[i];
            enemySlotList[i].SetBattler();
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
        fightIsOn = true;
    }
    

    public Battler GetRandomEnemy() 
    {
        List<Battler> aliveEnemies = new List<Battler>();
        
        foreach (Slot slot in enemySlotList) {
            if (slot.Battler.CurrentHp > 0)
                aliveEnemies.Add(slot.Battler);
        }
        return aliveEnemies[UnityEngine.Random.Range(0, aliveEnemies.Count - 1)];
    }

    public Battler GetRandomCharacter()
    {
        List<Battler> aliveCharacters = new List<Battler>();

        foreach (Slot slot in characterSlotList)
        {
            if(slot.Battler != null) {
                if (slot.Battler.CurrentHp > 0)
                    aliveCharacters.Add(slot.Battler);
            }   
        }
        if (aliveCharacters.Count == 0) throw new System.Exception("Empty aliveCharacters List");

        return aliveCharacters[UnityEngine.Random.Range(0, 0)];
    }
}
