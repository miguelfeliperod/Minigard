using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] Battler battler;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] UIBattlerStats uiBattlerStats;
    [SerializeField] DamageText damageText;
    BattleManager battleManager;

    public Battler Battler { get => battler; set => battler = value; }

    bool battleIsOn = false;

    float basicAttackTimer = 0;
    float subAttackTimer = 0;
    float firstSkillTimer = 0;
    float secondSkillTimer = 0;

    bool hasSubWeapon = false;

    private void Start()
    {
        battleManager = BattleManager.Instance;
        BattleManager.BattleStateEvent += SetBattleState;
    }

    void Update()
    {
        if (battleIsOn && battler.IsAlive)
        {
            PerformBattlerActions();
        }
    }

    public void SetBattleState(bool state)
    {
        battleIsOn = state;
    }

    public void SetBattlerData()
    {
        if (battler == null)
        {
            return;
        }
        spriteRenderer.sprite = battler.sprite;
        uiBattlerStats.gameObject.SetActive(true);
        hasSubWeapon = battler.HasSubWeapon();
        uiBattlerStats.SetInterface(battler);

        battler.ReceiveDamageEvent += LauchDamageText;

        battler.InitStats();
        basicAttackTimer = Random.Range(0f, 4f);

        if (hasSubWeapon)
            subAttackTimer = battler.BasicAttackTimer / 2;
    }

    void LauchDamageText(int value, Color color)
    {
       var damageTextObject = Instantiate(damageText, transform);
        damageTextObject.SetValues(value.ToString(), color);
    }

    public void DisableSlot()
    {
        uiBattlerStats.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private void PerformBattlerActions()
    {
        if (!battleManager.IsAnyCharacterAlive || !battleManager.IsAnyEnemyAlive) return;

        if (basicAttackTimer < 0) {
            BasicAttackAction();
        }

        if (hasSubWeapon)
        {
            if(subAttackTimer < 0) 
            {
                BasicAttackAction(hasSubWeapon);
            }    
            subAttackTimer -= Time.deltaTime;
        }

        if (firstSkillTimer < 0) {
            FirstAbilityAction();
        }

        if (secondSkillTimer < 0) {
            SecondAbilityAction();
        }

        basicAttackTimer -= Time.deltaTime;
        firstSkillTimer -= Time.deltaTime;
        secondSkillTimer -= Time.deltaTime;
    }

    void BasicAttackAction(bool alternateWeapon = false) {
        battler.ExecuteBasicAttack(GetAliveCharacters(), GetAliveEnemies(), alternateWeapon);
        UpdateAllUiInfo();
        if (alternateWeapon)
            subAttackTimer = battler.BasicAttackTimer;
        else
            basicAttackTimer = battler.BasicAttackTimer;
    }
    void FirstAbilityAction() {
        UpdateAllUiInfo();
        firstSkillTimer = battler.FirstSkillTimer;
    }
    void SecondAbilityAction() {
        UpdateAllUiInfo();
        secondSkillTimer = battler.SecondSkillTimer;
    }

    List<Battler> GetAliveCharacters()
    {
        return battleManager.CharactersList.Where(x => x.IsAlive==true).ToList();
    }

    List<Battler> GetAliveEnemies()
    {
        return battleManager.EnemiesList.Where(x => x.IsAlive == true).ToList();
    }

    void UpdateAllUiInfo()
    {
        foreach(Slot slot in battleManager.characterSlotList) {
            if (slot.isActiveAndEnabled)
                slot.uiBattlerStats.UpdateInfo();
        }

        foreach (Slot slot in battleManager.enemySlotList)
        {
            if (slot.isActiveAndEnabled)
                slot.uiBattlerStats.UpdateInfo();
        }
    }
}
