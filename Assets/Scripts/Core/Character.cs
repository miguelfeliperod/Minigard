using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    const int MinStatsPointsToDistribute = 1;
    const int MaxStatsPointsToDistribute = 10;

    public void RandomizeCharacter()
    {
        RandomizeName();
        RandomizeRaceAndColor();
        RandomizeClass();
        RandomizeDescriptionData();
        RandomizeNaturalStats();
        RandomizeStatusResistances();
        RandomizeElementalAfinities();
        RandomizeWeaponProficiencies();
    }

    public void RandomizeCharacter(int seed)
    {
        UnityEngine.Random.InitState(seed);

        RandomizeName();
        RandomizeRaceAndColor();
        RandomizeClass();
        RandomizeDescriptionData();
        RandomizeNaturalStats();
        RandomizeStatusResistances();
        RandomizeElementalAfinities();
        RandomizeWeaponProficiencies();
    }

    [SerializeField] ClassesList classList;
    [SerializeField] RacesList raceList;
    public SpriteRenderer spriteRenderer;

    // Final stats
    public string characterName;
    public Genre genre;
    public int age;
    public Race race;

    public FirstClass firstClass;
    public SecondClass secondClass;
    public ThirdClass specialization;
    public Skill firstAbility;
    public Skill secondAbility;
    public Skill thirdAbility;

    public float level;
    public float hp;
    public float mp;
    public float atk;
    public float mag;
    public float def;
    public float mdef;
    public float evas;
    public float atkspd;
    public float critChan;
    public float critDmg;
    public float loot;

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

    public Head headEquipment = null;
    public Chest chestEquipment = null;
    public Leg legEquipment = null;
    public Foot footEquipment = null;
    public Accessory accessoryOneEquipment = null;
    public Accessory accessoryTwoEquipment = null;
    public HandEquipment leftHandEquipment = null;
    public HandEquipment rightHandEquipment = null;

    public bool canUseAccessoryTwo = false;
    public bool canUseBothHands = false;

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

    // WeaponType afinities
    public Proficiency swordProficiency = Proficiency.F;
    public Proficiency greatSwordProficiency = Proficiency.F;
    public Proficiency lanceProficiency = Proficiency.F;
    public Proficiency katanaProficiency = Proficiency.F;
    public Proficiency gloveProficiency = Proficiency.F;
    public Proficiency axeProficiency = Proficiency.F;
    public Proficiency bowProficiency = Proficiency.F;
    public Proficiency crossbowProficiency = Proficiency.F;
    public Proficiency rodProficiency = Proficiency.F;
    public Proficiency grimoryProficiency = Proficiency.F;
    public Proficiency staffProficiency = Proficiency.F;
    public Proficiency daggerProficiency = Proficiency.F;
    public Proficiency dualBladeProficiency = Proficiency.F;
    public Proficiency shieldProficiency = Proficiency.F;
    public Proficiency greatShieldProficiency = Proficiency.F;

    void RandomizeName()
    {
        characterName = NameList.namesList[UnityEngine.Random.Range(0, NameList.namesList.Count - 1)]
            + " "
            + NameList.surnameList[UnityEngine.Random.Range(0, NameList.surnameList.Count - 1)];
    }

    void RandomizeDescriptionData()
    {
        genre = UnityEngine.Random.value < 0.5 ? Genre.Male : Genre.Female;
        age = race.RaceType switch
        {
            RaceType.Human => UnityEngine.Random.Range(16, 120),
            RaceType.Dwarf => UnityEngine.Random.Range(40, 400),
            RaceType.HightElf => UnityEngine.Random.Range(16, 750),
            RaceType.DarkElf => UnityEngine.Random.Range(16, 750),
            RaceType.Orc => UnityEngine.Random.Range(12, 60),
            RaceType.Vampire => UnityEngine.Random.Range(15, 9999),
            RaceType.Werewolf => UnityEngine.Random.Range(16, 150),
            RaceType.Draconian => UnityEngine.Random.Range(16, 3000),
            RaceType.Demon => UnityEngine.Random.Range(16, 1500),
            _ => UnityEngine.Random.Range(16, 120),
        };

        if (race.RaceType == RaceType.Vampire || race.RaceType == RaceType.Demon || race.RaceType == RaceType.Draconian)
        {
            if (UnityEngine.Random.Range(0, 10) == 1)
                age = 0;
        }
    }

    void RandomizeClass()
    {
        firstClass = classList.firstClassList[UnityEngine.Random.Range(0, classList.firstClassList.Count)];
        firstAbility = firstClass.FirstAbilityChoice;
        secondAbility = firstClass.SecondAbilityChoice;
    }

    void RandomizeRaceAndColor()
    {
        race = raceList.racesList[UnityEngine.Random.Range(0, raceList.racesList.Count)];
        spriteRenderer.color = race.GetRandomBodyColor();
    }

    void RandomizeNaturalStats()
    {
        toughness = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        spirituality = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        bravery = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        inteligence = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        faith = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        evilness = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        dexterity = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        agility = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        luck = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);

        level = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        hp = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        mp = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        atk = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        mag = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        def = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        mdef = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        evas = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        atkspd = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        critChan = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        critDmg = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        loot = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);

    }

    void RandomizeStatusResistances()
    {
        poisonResistance = GetRandomStatusAffinity();
        stunResistance = GetRandomStatusAffinity();
        confusionResistance = GetRandomStatusAffinity();
        paralyseResistance = GetRandomStatusAffinity();
        bleedResistance = GetRandomStatusAffinity();
    }

    Affinity GetRandomStatusAffinity()
    {
        var value = UnityEngine.Random.Range(0, 100);
        if (value < 10)
            return Affinity.Poor;
        else if (value < 30)
            return Affinity.Low;
        else if (value < 70)
            return Affinity.Neutral;
        else if (value < 90)
            return Affinity.High;
        else
            return Affinity.Impressive;
    }

    void RandomizeElementalAfinities()
    {
        fireAffinity = GetRandomElementAffinity();
        iceAffinity = GetRandomElementAffinity();
        thunderAffinity = GetRandomElementAffinity();
        earthAffinity = GetRandomElementAffinity();
        windAffinity = GetRandomElementAffinity();
        darknessAffinity = GetRandomElementAffinity();
        lightAffinity = GetRandomElementAffinity();
    }

    Affinity GetRandomElementAffinity()
    {
        var value = UnityEngine.Random.Range(0, 100);
        if (value < 10)
            return Affinity.Poor;
        else if (value < 25)
            return Affinity.Low;
        else if (value < 75)
            return Affinity.Neutral;
        else if (value < 90)
            return Affinity.High;
        else
            return Affinity.Impressive;
    }

    void RandomizeWeaponProficiencies()
    {
        swordProficiency = GetRandomWeaponProfficiency();
        greatSwordProficiency = GetRandomWeaponProfficiency();
        lanceProficiency = GetRandomWeaponProfficiency();
        katanaProficiency = GetRandomWeaponProfficiency();
        gloveProficiency = GetRandomWeaponProfficiency();
        axeProficiency = GetRandomWeaponProfficiency();
        bowProficiency = GetRandomWeaponProfficiency();
        crossbowProficiency = GetRandomWeaponProfficiency();
        rodProficiency = GetRandomWeaponProfficiency();
        grimoryProficiency = GetRandomWeaponProfficiency();
        staffProficiency = GetRandomWeaponProfficiency();
        daggerProficiency = GetRandomWeaponProfficiency();
        dualBladeProficiency = GetRandomWeaponProfficiency();
        shieldProficiency = GetRandomWeaponProfficiency();
        greatShieldProficiency = GetRandomWeaponProfficiency();
    }

    Proficiency GetRandomWeaponProfficiency()
    {
        var value = UnityEngine.Random.Range(0, 100);
        if (value < 5)
            return Proficiency.F;
        else if (value < 15)
            return Proficiency.E;
        else if (value < 35)
            return Proficiency.D;
        else if (value < 60)
            return Proficiency.C;
        else if (value < 85)
            return Proficiency.B;
        else if (value < 95)
            return Proficiency.A;
        else
            return Proficiency.S;
    }

    float GetWeaponTypeAffinityModifier(WeaponType WeaponType)
    {
        switch (WeaponType)
        {
            case WeaponType.Sword:
                return ProficiencyToValue(swordProficiency);
            case WeaponType.GreatSword:
                return ProficiencyToValue(greatSwordProficiency);
            case WeaponType.Lance:
                return ProficiencyToValue(lanceProficiency);
            case WeaponType.Katana:
                return ProficiencyToValue(katanaProficiency);
            case WeaponType.Glove:
                return ProficiencyToValue(gloveProficiency);
            case WeaponType.Axe:
                return ProficiencyToValue(axeProficiency);
            case WeaponType.Bow:
                return ProficiencyToValue(bowProficiency);
            case WeaponType.Crossbow:
                return ProficiencyToValue(crossbowProficiency);
            case WeaponType.Rod:
                return ProficiencyToValue(rodProficiency);
            case WeaponType.Grimory:
                return ProficiencyToValue(grimoryProficiency);
            case WeaponType.Staff:
                return ProficiencyToValue(staffProficiency);
            case WeaponType.Dagger:
                return ProficiencyToValue(daggerProficiency);
            case WeaponType.DualBlade:
                return ProficiencyToValue(dualBladeProficiency);
            case WeaponType.Shield:
                return ProficiencyToValue(shieldProficiency);
            case WeaponType.GreatShield:
                return ProficiencyToValue(greatShieldProficiency);
            default:
                return 1.0f;
        }
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

    float ProficiencyToValue(Proficiency affinity)
    {
        switch (affinity)
        {
            case Proficiency.S:
                return 1.25f;
            case Proficiency.A:
                return 1.1f;
            case Proficiency.B:
                return 1.0f;
            case Proficiency.C:
                return 0.9f;
            case Proficiency.D:
                return 0.8f;
            case Proficiency.E:
                return 0.65f;
            case Proficiency.F:
                return 0.5f;
            default:
                return 0.5f;
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
}
