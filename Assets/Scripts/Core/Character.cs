using System;
using UnityEngine;

public class Character : Battler
{
    const int MinStatsPointsToDistribute = 1;
    const int MaxStatsPointsToDistribute = 11;
    const int InitialLevel = 1;
    const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";

    [SerializeField] ClassesList classList;
    [SerializeField] RacesList raceList;

    public string seed;

    // Final stats
    public Genre genre;
    public int age;
    public Race race;

    public FirstClass firstClass;
    public SecondClass secondClass;
    public ThirdClass thirdClass;

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

    void Start()
    {
        InitStats();
    }

    void GenerateSeed()
    {
        seed = "";
        int seedRange = UnityEngine.Random.Range(4, 16);
        for (int i = 0; i < seedRange; i++)
            seed += glyphs[UnityEngine.Random.Range(0, glyphs.Length)];
    }

    public void RandomizeCharacter()
    {
        GenerateSeed();
        UnityEngine.Random.InitState(seed.GetHashCode());

        RandomizeRaceColorAndGenre();
        RandomizeName();
        RandomizeClass();
        RandomizeNaturalStats();
        RandomizeStatusResistances();
        RandomizeElementalAfinities();
        RandomizeWeaponProficiencies();
    }

    public void RandomizeCharacter(string seed)
    {
        this.seed = seed;
        UnityEngine.Random.InitState(seed.GetHashCode());

        RandomizeRaceColorAndGenre();
        RandomizeName();
        RandomizeClass();
        RandomizeNaturalStats();
        RandomizeStatusResistances();
        RandomizeElementalAfinities();
        RandomizeWeaponProficiencies();
    }

    void RandomizeName()
    {
        battlerName = (genre == Genre.Male ? 
            NameList.maleNamesList[UnityEngine.Random.Range(0, NameList.maleNamesList.Count)] :
            NameList.femaleNamesList[UnityEngine.Random.Range(0, NameList.femaleNamesList.Count)])
            + " "
            + NameList.surnameList[UnityEngine.Random.Range(0, NameList.surnameList.Count)];
    }

    void RandomizeClass()
    {
        firstClass = classList.firstClassList[UnityEngine.Random.Range(0, classList.firstClassList.Count)];
        firstAbility = firstClass.FirstAbilityChoice;
        secondAbility = firstClass.SecondAbilityChoice;
    }

    void RandomizeRaceColorAndGenre()
    {
        race = raceList.racesList[UnityEngine.Random.Range(0, raceList.racesList.Count)];
        
        spriteRenderer.color = race.GetRandomBodyColor();
        
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

    void RandomizeNaturalStats()
    {
        level = InitialLevel;

        toughness = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        spirituality = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        bravery = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        inteligence = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        faith = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        evilness = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        dexterity = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        agility = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
        luck = UnityEngine.Random.Range(MinStatsPointsToDistribute, MaxStatsPointsToDistribute);
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
    protected override Battler GetRandomTarget()
    {
        return BattleManager.Instance.GetRandomEnemy();
    }
}
