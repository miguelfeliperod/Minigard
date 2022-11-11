using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Battler", menuName = "ScriptableObjects/Battle/Battler")]
public abstract class Battler : ScriptableObject
{
    GameManager gameManager;

    public string battlerName;

    public Skill firstAbility;
    public Skill secondAbility;
    public Skill thirdAbility;

    public Sprite sprite;

    public delegate void ReceiveDamageDelegate(int value, Color color);
    public event ReceiveDamageDelegate ReceiveDamageEvent;

    public abstract bool HasSubWeapon();

    // Final Stats
    public int level;
    public int maxHp;
    public int maxMp;
    public int atk;
    public int mag;
    public int def;
    public int mdef;
    public int evas;
    public int atkspd;
    public int critChan;
    public int critDmg;
    public int loot;

    // Nature stats
    public int toughness;    // hp + def
    public int spirituality; // mp + mdef
    public int bravery;      // atk + hp
    public int inteligence;  // mag + mp
    public int faith;        // mag + mdef
    public int evilness;     // mag + def
    public int dexterity;    // crit.chance + crit.dmg
    public int agility;      // atk.spd + evas
    public int luck;         // evas + loot

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

    private float basicAtkCooldownTimer;
    private float firstAbilityCooldownTimer;
    private float secondAbilityCooldownTimer;

    public float BasicAttackTimer { get => basicAtkCooldownTimer; }
    public float FirstSkillTimer { get => firstAbilityCooldownTimer; }
    public float SecondSkillTimer { get => secondAbilityCooldownTimer; }

    private int currentHp;
    public int CurrentHp { get => currentHp; set => currentHp = value; }

    private int currentMp;
    public int CurrentMp { get => currentMp; set => currentMp = value; }

    public const int MinHP = 20;
    public const int MinMP = 20;

    public bool IsAlive => currentHp > 0;
    public virtual void InitStats()
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

        currentHp = maxHp;
        currentMp = maxMp;

        basicAtkCooldownTimer = GetAtkCooldown();
    }

    float GetAtkCooldown()
    {
        return Math.Max(5 - (atkspd / 20), 0.4f);
    }

    public virtual Battler GetRandomTarget() {
        return this;
    }

    public float GetElementAffinityModifier(Element element)
    {
        switch (element)
        {
            case Element.Fire:
                return AffinityToElementalModifier(fireAffinity);
            case Element.Ice:
                return AffinityToElementalModifier(iceAffinity);
            case Element.Thunder:
                return AffinityToElementalModifier(thunderAffinity);
            case Element.Earth:
                return AffinityToElementalModifier(earthAffinity);
            case Element.Wind:
                return AffinityToElementalModifier(windAffinity);
            case Element.Darkness:
                return AffinityToElementalModifier(darknessAffinity);
            case Element.Light:
                return AffinityToElementalModifier(lightAffinity);
            case Element.None:
            default:
                return 0.0f;
        }
    }

    public int GetStatusAilmentAffinityModifier(StatusAilment statusAilment)
    {
        switch (statusAilment)
        {
            case StatusAilment.Poison:
                return AffinityToStatusAilmentValue(poisonResistance);
            case StatusAilment.Stun:
                return AffinityToStatusAilmentValue(stunResistance);
            case StatusAilment.Confusion:
                return AffinityToStatusAilmentValue(confusionResistance);
            case StatusAilment.Paralyse:
                return AffinityToStatusAilmentValue(paralyseResistance);
            case StatusAilment.Bleed:
                return AffinityToStatusAilmentValue(bleedResistance);
            case StatusAilment.None:
            default:
                return 0;
        }
    }

    float AffinityToElementalModifier(Affinity affinity)
    {
        switch (affinity)
        {
            case Affinity.Natural:
                return 0.6f;
            case Affinity.Impressive:
                return 0.5f;
            case Affinity.High:
                return 0.25f;
            case Affinity.Neutral:
                return 0.0f;
            case Affinity.Low:
                return -0.25f;
            case Affinity.Poor:
                return -0.5f;
            default:
                return 0.0f;
        }
    }

    int AffinityToStatusAilmentValue(Affinity affinity)
    {
        switch (affinity)
        {
            case Affinity.Natural:
                return 100;
            case Affinity.Impressive:
                return 80;
            case Affinity.High:
                return 60;
            case Affinity.Neutral:
                return 40;
            case Affinity.Low:
                return 20;
            case Affinity.Poor:
                return 0;
            default:
                return 40;
        }
    }

    void SetMaxHp() {
        maxHp = MinHP + toughness * 3 + bravery;
    }
    void SetMaxMp() {
        maxMp = MinMP + spirituality * 3 + inteligence;
    }
    void SetAtk() {
        atk = bravery;
    }
    void SetMag() {
        mag = (inteligence + faith + evilness)/3;
    }
    void SetDef() {
        def = (toughness + evilness)/2;
    }
    void SetMdef() {
        mdef = (spirituality + faith)/2;
    }                  
    void SetEvas() {
        evas = (agility + luck)/2;
    }
    void SetAtkspd() {
        atkspd = agility;
    }
    void SetCritChan() {
        critChan = dexterity;
    }
    void SetCritDmg() { 
        critDmg = dexterity;
    }
    void SetLoot() {
        loot = luck;
    }

    public List<Battler> DetermineActionTargets(List<Battler> charactersList, List<Battler> enemyList, TargetPattern pattern, TargetTeam targetTeam, int range, int maxQuantity)
    {
        List<Battler> listToSearch = new List<Battler>();
        List<Battler> possibleTargetList = new List<Battler>();

        switch (targetTeam)
        {
            case TargetTeam.Characters:
                listToSearch.AddRange(charactersList);
                break;
            case TargetTeam.Enemies:
                listToSearch.AddRange(enemyList);
                break;
            case TargetTeam.Both:
                listToSearch.AddRange(charactersList);
                listToSearch.AddRange(enemyList);
                break;
            case TargetTeam.None:
            default:
                return new List<Battler>();
        }

        switch (pattern)
        {
            case TargetPattern.FrontFirst:
                possibleTargetList.AddRange(SearchNFirstBattlersFromList(listToSearch, range));
                break;
            case TargetPattern.BackFirst:
                possibleTargetList.AddRange(SearchNLastBattlersFromList(listToSearch, range));
                break;
            case TargetPattern.MiddleFirst:
                possibleTargetList.AddRange(SearchNMiddleBattlersFromList(listToSearch, range));
                break;
            case TargetPattern.Random:
                possibleTargetList.AddRange(listToSearch);
                break;
            case TargetPattern.Everyone:
                possibleTargetList.AddRange(listToSearch);
                break;
            case TargetPattern.None:
            default:
                return new List<Battler>();
        }
        return PickRandomNBattlersFromList(possibleTargetList, maxQuantity);
    }

    List<Battler> SearchNFirstBattlersFromList(List<Battler> list, int n)
    {
        if (n >= list.Count) return list;
        List<Battler> possibleTargetList = new List<Battler>();

        for (int battlerIndex = 0; battlerIndex < n && battlerIndex < list.Count; battlerIndex++)
        {
            possibleTargetList.Add(list[battlerIndex]);
        }
        return possibleTargetList;
    }

    List<Battler> SearchNLastBattlersFromList(List<Battler> list, int n)
    {
        if (n >= list.Count) return list;
        List<Battler> possibleTargetList = new List<Battler>();

        for (int battlerIndex = list.Count - 1; battlerIndex >= list.Count - n && battlerIndex > 0; battlerIndex--)
        {
            possibleTargetList.Add(list[battlerIndex]);
        }
        return possibleTargetList;
    }

    List<Battler> SearchNMiddleBattlersFromList(List<Battler> list, int n)
    {
        if (n >= list.Count) return list;
        List<Battler> possibleTargetList = new List<Battler>();

        //Retorna apenas o membro do meio da lista;
        possibleTargetList.Add(list[(int)Mathf.Floor(list.Count / 2)]);
        return possibleTargetList;
    }

    List<Battler> PickRandomNBattlersFromList(List<Battler> list, int n)
    {
        if (n >= list.Count) return list;
        for (int elementsInList = list.Count; elementsInList > n; elementsInList = list.Count)
        {
            list.Remove(list[UnityEngine.Random.Range(0, list.Count)]);
        }
        return list;
    }

    public int GetDamageReductionBaseValue(Action damage)
    {
        switch (damage.type)
        {
            case DamageType.Physical:
                return damage.value / (int)Math.Sqrt(damage.value) * def;
            case DamageType.Magical:
                return damage.value / (int)Math.Sqrt(damage.value) * mdef;
            case DamageType.Hybrid:
                return damage.value / (int)Math.Sqrt(damage.value) * ((def + mdef) / 2);
            case DamageType.True:
            default:
                return damage.value;
        }
    }

    public void ApplyStatusAilment(Action action)
    {
        if (UnityEngine.Random.Range(0, action.statusAilmentChance) > GetStatusAilmentAffinityModifier(action.statusAilment))
        {

        }
    }

    public static Color GetColorElementDamage(Element element)
    {
        return element switch
        {
            Element.None => GameManager.Instance.ColorIndex.noneColor,
            Element.Fire => GameManager.Instance.ColorIndex.fireColor,
            Element.Ice => GameManager.Instance.ColorIndex.iceColor,
            Element.Thunder => GameManager.Instance.ColorIndex.thunderColor,
            Element.Earth => GameManager.Instance.ColorIndex.earthColor,
            Element.Wind => GameManager.Instance.ColorIndex.windColor,
            Element.Light => GameManager.Instance.ColorIndex.lightColor,
            Element.Darkness=> GameManager.Instance.ColorIndex.darknessColor,
            _ => Color.black,
        };
    }

    public void ReceiveAction(Action action)
    {
        var finalDamage = (int)(GetDamageReductionBaseValue(action) *
            (1 - (2 * GetElementAffinityModifier(action.element))));

        CurrentHp -= finalDamage;

        if (ReceiveDamageEvent != null)
        {
            ReceiveDamageEvent(finalDamage, GetColorElementDamage(action.element));
        }
        ApplyStatusAilment(action);
    }

    public int GetBaseDamageValue(DamageType damageType, int rawValue = 0)
    {        // Damage Atribute
        return damageType switch
        {
            DamageType.Physical => atk,
            DamageType.Magical => mag,
            DamageType.Hybrid => (int)((atk + mag)/2),
            DamageType.True => rawValue,
            _ => 0,
        };
    }

    public bool SetDamageIsCritical()
    {
        return UnityEngine.Random.Range(0, 100) < critChan;
    }

    public int GetCriticalDamageMultiplier()
    {
        return (int)(1.5f + critDmg / 100);
    }
    
    public abstract int SetBasicAttackDamage(Action action, HandEquipment weapon = null);
    public abstract void ExecuteBasicAttack(List<Battler> charactersList, List<Battler> monstersList, bool isSubWeapon = false);
    public abstract void ExecuteFirstSkill(List<Battler> charactersList, List<Battler> monstersList);
    public abstract void ExecuteSecondSkill(List<Battler> charactersList, List<Battler> monstersList);

}
