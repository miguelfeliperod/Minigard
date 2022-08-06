using System;
using UnityEngine;

public abstract class Battler : MonoBehaviour
{
    public string battlerName;

    public Skill firstAbility;
    public Skill secondAbility;
    public Skill thirdAbility;

    public SpriteRenderer spriteRenderer;

    // Final Stats
    public float level;
    float maxHp;
    float maxMp;
    float atk;
    float mag;
    float def;
    float mdef;
    float evas;
    float atkspd;
    float critChan;
    float critDmg;
    float loot;

    // Nature stats
    public float toughness;    // hp + def
    public float spirituality; // mp + mdef
    public float bravery;      // atk + hp
    public float inteligence;  // mag + mp
    public float faith;        // mag + mdef
    public float evilness;     // mag + def
    public float dexterity;    // crit.chance + crit.dmg
    public float agility;      // atk.spd + evas
    public float luck;         // evas + loot

    // Status Ailment afinities
    public Affinity poisonResistance = Affinity.Neutral;
    public Affinity stunResistance = Affinity.Neutral;
    public Affinity confusionResistance = Affinity.Neutral;
    public Affinity paralyseResistance = Affinity.Neutral;
    public Affinity bleedResistance = Affinity.Neutral;

    // Elemental afinities
    public Affinity fireAffinity = Affinity.Neutral;
    public Affinity iceAffinity = Affinity.Neutral;
    public Affinity thunderAffinity = Affinity.Neutral;
    public Affinity earthAffinity = Affinity.Neutral;
    public Affinity windAffinity = Affinity.Neutral;
    public Affinity darknessAffinity = Affinity.Neutral;
    public Affinity lightAffinity = Affinity.Neutral;

    private float atkCooldown;
    private float firstAbilityCooldown;
    private float secondAbilityCooldown;

    private float atkColdownTimer;
    private float firstAbilityCooldownTimer;
    private float secondAbilityCooldownTimer;

    private float currentHp;
    public float CurrentHp {get => currentHp; }
    private float currentMp;
    public float CurrentMp { get => currentMp; }

    public const int MinHP = 20;
    public const int MinMP = 20;

    private void Start()
    {
        InitStats();
    }

    void Update()
    {
        if (BattleManager.Instance == null) return;
        if (!BattleManager.Instance.FightIsOn) return;
        atkColdownTimer -= Time.deltaTime;
        firstAbilityCooldownTimer -= Time.deltaTime;
        secondAbilityCooldownTimer -= Time.deltaTime;

        if(atkColdownTimer <= 0)
        {
            ExecuteAutoAttack(GetRandomTarget());
        }
    }

    public void InitStats()
    {
        SetMaxHp();
        SetMaxMp();
        SetAtk();
        SetMag();
        SetDef();
        SetMdef();
        SetEvas();
        SetAtkspd();
        SetCritChan();
        SetCritDmg();
        SetLoot();
    }

    float GetAtkCooldown()
    {
        return Math.Max(2 - atkspd/10, 0.5f);
    }

    float GetFirstAbilityCooldown()
    {
        return 5;
    }

    float GetSecondAbilityCooldown()
    {
        return 8;
    }

    protected virtual Battler GetRandomTarget(){
        return this;
    }

    public virtual void ExecuteAutoAttack(Battler target)
    {

    }

        float GetElementAffinityModifier(Element element)
    {
        switch (element)
        {
            case Element.Fire:
                return AffinityToElementalValue(fireAffinity);
            case Element.Ice:
                return AffinityToElementalValue(iceAffinity);
            case Element.Thunder:
                return AffinityToElementalValue(thunderAffinity);
            case Element.Earth:
                return AffinityToElementalValue(earthAffinity);
            case Element.Wind:
                return AffinityToElementalValue(windAffinity);
            case Element.Darkness:
                return AffinityToElementalValue(darknessAffinity);
            case Element.Light:
                return AffinityToElementalValue(lightAffinity);
            default:
                return 1.0f;
        }
    }

    float GetStatusAilmentResistanceModifier(StatusAilment statusAilment)
    {
        switch (statusAilment)
        {
            case StatusAilment.Poison:
                return AffinityToResistanceValue(poisonResistance);
            case StatusAilment.Stun:
                return AffinityToResistanceValue(stunResistance);
            case StatusAilment.Confusion:
                return AffinityToResistanceValue(confusionResistance);
            case StatusAilment.Paralyse:
                return AffinityToResistanceValue(paralyseResistance);
            case StatusAilment.Bleed:
                return AffinityToResistanceValue(bleedResistance);
            default:
                return 1.0f;
        }
    }

    float AffinityToElementalValue(Affinity affinity)
    {
        switch (affinity)
        {
            case Affinity.Impressive:
                return 1.5f;
            case Affinity.High:
                return 1.25f;
            case Affinity.Neutral:
                return 1.0f;
            case Affinity.Low:
                return 0.75f;
            case Affinity.Poor:
                return 0.5f;
            default:
                return 1.0f;
        }
    }

    float AffinityToResistanceValue(Affinity affinity)
    {
        switch (affinity)
        {
            case Affinity.Impressive:
                return 1.0f;
            case Affinity.High:
                return .75f;
            case Affinity.Neutral:
                return .5f;
            case Affinity.Low:
                return 0.25f;
            case Affinity.Poor:
                return 0f;
            default:
                return .5f;
        }
    }

    void SetMaxHp() {
        maxHp = MinHP + toughness * 3 + bravery;
    }
    void SetMaxMp() {
        maxHp = MinMP + spirituality * 3 + inteligence;
    }
    void SetAtk() {
        atk = bravery * 3;
    }
    void SetMag() {
        mag = inteligence * 3 + faith + evilness;
    }
    void SetDef() {
        def = toughness * 2 + evilness;
    }
    void SetMdef() {
        mdef = spirituality * 2 + faith;
    }                  
    void SetEvas() {
        evas = agility * 2 + luck;
    }
    void SetAtkspd() {
        atkspd = agility * 3;
    }
    void SetCritChan() {
        critChan = dexterity * 3;
    }
    void SetCritDmg() { 
        critDmg = dexterity * 3;
    }
    void SetLoot() {
        loot = luck * 3;
    }
}
