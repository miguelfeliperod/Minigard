using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Battle/Character")]
public class Character : Battler
{
    GameManager gameManager;

    const int MinStatsPointsToDistribute = 1;
    const int MaxStatsPointsToDistribute = 11;
    const int InitialLevel = 1;
    const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";

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
    public Foot footEquipment = null;
    public Accessory accessoryOneEquipment = null;
    public Accessory accessoryTwoEquipment = null;
    
    public HandEquipment mainHandEquipment = null;
    public HandEquipment subHandEquipment = null;

    public bool canEquipAccessoryTwo = false;
    public bool canEquipBothHands = false;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }
    public override bool HasSubWeapon()
    {
        if(subHandEquipment != null)
        {
            return subHandEquipment.BasicAttackPattern != TargetPattern.None;
        }
        return false;
    }

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

    string GetNewSeed()
    {
        seed = "";
        int seedRange = UnityEngine.Random.Range(4, 16);
        for (int seedCharacterIndex = 0; seedCharacterIndex < seedRange; seedCharacterIndex++)
            seed += glyphs[UnityEngine.Random.Range(0, glyphs.Length)];
        return seed;
    }

    public void RandomizeCharacter(string newSeed = "")
    {
        if(newSeed == "")
            newSeed = GetNewSeed();
        seed = newSeed;
        UnityEngine.Random.InitState(seed.GetHashCode());

        RandomizeRaceAndGenre();
        RandomizeName();
        RandomizeClass();
        RandomizeNaturalStats();
        RandomizeStatusResistances();
        RandomizeElementalAfinities();
        RandomizeWeaponProficiencies();
        SetInitialEquipment();
        RandomizeCharacterSprite();
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
        var classList = GameManager.Instance.ClassList.firstClassList;
        firstClass = classList[UnityEngine.Random.Range(0, classList.Count)];
        firstAbility = firstClass.FirstAbilityChoice;
        secondAbility = firstClass.SecondAbilityChoice;
    }

    void RandomizeRaceAndGenre()
    {
        var racesList = GameManager.Instance.RaceList.racesList;
        race = racesList[UnityEngine.Random.Range(0, racesList.Count)];
        
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
        else if (value < 97)
            return Affinity.Impressive;
        else
            return Affinity.Natural;
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

    void SetInitialEquipment()
    {
        Equipment weapon;
        var equipmentsList = GameManager.Instance.equipmentInventory;
        do { weapon = equipmentsList[UnityEngine.Random.Range(0, equipmentsList.Count)];
        } while (weapon is not HandEquipment);
            mainHandEquipment = (HandEquipment)weapon;
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
        else if (value < 97)
            return Affinity.Impressive;
        else
            return Affinity.Natural;
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

    float GetWeaponTypeProficiencyModifier(WeaponType WeaponType)
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

    public override Battler GetRandomTarget()
    {
        return BattleManager.Instance.GetRandomEnemy();
    }

    public override void InitStats()
    {
        base.InitStats();
    }

    public override void ExecuteBasicAttack(List<Battler> charactersList, List<Battler> enemyList, bool isSubWeapon = false)
    {
        Action damage = new();
        HandEquipment weapon = GetWeapon(isSubWeapon);

        List<Battler> targets = DetermineActionTargets(charactersList, enemyList, weapon.BasicAttackPattern, weapon.TargetTeam, weapon.Range, weapon.MaxQuantity);
        damage.isCritical = SetDamageIsCritical();
        damage.type = DamageType.Physical;
        damage.element = weapon.element;
        damage.statusAilment = weapon.statusAilment;
        damage.statusAilmentChance = GetStatusAilmentAffinityModifier(weapon.statusAilment);

        damage.value = SetBasicAttackDamage(damage, weapon);

        if (damage.isCritical)
        {
            damage.value *= GetCriticalDamageMultiplier();
        }
        foreach(Enemy enemy in targets)
        {
            enemy.ReceiveAction(damage);
        }
    }

    HandEquipment GetWeapon(bool isSubWeapon = false)
    {
        if (isSubWeapon)
            return subHandEquipment;
        else
            return mainHandEquipment;
    }

    public override void ExecuteFirstSkill(List<Battler> charactersList, List<Battler> monstersList)
    {
        throw new System.NotImplementedException();
    }

    public override void ExecuteSecondSkill(List<Battler> charactersList, List<Battler> monstersList)
    {
        throw new System.NotImplementedException();
    }

    public override int SetBasicAttackDamage(Action damage, HandEquipment weapon)
    {
        int totalDamage = GetBaseDamageValue(DamageType.Physical);

        return  (int)(totalDamage * totalDamage
            * (1 + GetElementAffinityModifier(damage.element))
            * GetWeaponTypeProficiencyModifier(weapon.WeaponType));
    }

    public void RandomizeCharacterSprite()
    {
        List<Texture2D> textureList = new List<Texture2D>(){
        GetRandomBodySprite(),
        GetRandomEyesSprite(),
        GetRandomUnderDressSprite(),
        GetRandomBottomDressSprite(),
        GetRandomFootDressSprite(),
        GetRandomTopDressSprite(),
        GetRandomHairSprite()
    };
        sprite = BattlerSpriteMerger.GetMergedSprites(textureList);
    }

    Texture2D GetRandomBodySprite()
    {
        var randomColor = race.GetRandomBodyColor();
        var texture = genre == Genre.Male ? race.GetRandomMaleBody() : race.GetRandomFemaleBody();

        return ApplyColorToSprite(texture, randomColor);
    }
    Texture2D GetRandomEyesSprite()
    {
        var randomColor = race.GetRandomEyeColor();
        var texture = genre == Genre.Male ? race.GetRandomMaleEyes() : race.GetRandomFemaleEyes();
        return ApplyColorToSprite(texture, randomColor, true);
    }
    Texture2D GetRandomUnderDressSprite()
    {
        List<Color> colorList = new List<Color>() { Color.blue, Color.red, Color.yellow, Color.green, Color.cyan, Color.magenta, Color.white };
        var randomColor = colorList[UnityEngine.Random.Range(0, colorList.Count)];
        var texture = race.GetRandomUnderDress();
        return ApplyColorToSprite(texture, randomColor);
    }
    Texture2D GetRandomBottomDressSprite()
    {
        List<Color> colorList = new List<Color>() { Color.blue, Color.red, Color.yellow, Color.green, Color.cyan, Color.magenta, Color.white };
        var randomColor = colorList[UnityEngine.Random.Range(0, colorList.Count)];
        var texture = race.GetRandomBottomDress();
        return ApplyColorToSprite(texture, randomColor);
    }
    Texture2D GetRandomFootDressSprite()
    {
        List<Color> colorList = new List<Color>() { Color.blue, Color.red, Color.yellow, Color.green, Color.cyan, Color.magenta, Color.white };
        var randomColor = colorList[UnityEngine.Random.Range(0, colorList.Count)];
        var texture = race.GetRandomFootDress();
        return ApplyColorToSprite(texture, randomColor);
    }
    Texture2D GetRandomTopDressSprite()
    {
        List<Color> colorList = new List<Color>() { Color.blue, Color.red, Color.yellow, Color.green, Color.cyan, Color.magenta, Color.white };
        var randomColor = colorList[UnityEngine.Random.Range(0, colorList.Count)];
        var texture = race.GetRandomTopDress();
        return ApplyColorToSprite(texture, randomColor);
    }
    Texture2D GetRandomHairSprite()
    {
        var randomColor = race.GetRandomHairColor();
        var texture = genre == Genre.Male ? race.GetRandomMaleHair() : race.GetRandomFemaleHair();
        return ApplyColorToSprite(texture, randomColor);
    }

    Texture2D ApplyColorToSprite(Texture2D texture, Color filterColor, bool isEye = false)
    {
        var newTexture = new Texture2D(texture.width, texture.height);
        var pixelColors = texture.GetPixels();
        if (!isEye)
        {
            for (var pixel = 0; pixel < pixelColors.Length; pixel++)
            {
                if (pixelColors[pixel].a < 0.1f)
                {
                    pixelColors[pixel] = new Color(1, 1, 1, 0);
                }
                else
                {
                    pixelColors[pixel] = new Color(
                    pixelColors[pixel].r * filterColor.r,
                    pixelColors[pixel].g * filterColor.g,
                    pixelColors[pixel].b * filterColor.b
                    );
                }
            }
        }
        else
        {
            for (var pixel = 0; pixel < pixelColors.Length; pixel++)
            {
                if (pixelColors[pixel].a < 0.1f)
                {
                    pixelColors[pixel] = new Color(1, 1, 1, 0);
                }
                else if (pixelColors[pixel] == Color.white) {
                    pixelColors[pixel] = race.GetEyeBackColor();
                }
                else
                {
                    pixelColors[pixel] = new Color(
                    pixelColors[pixel].r * filterColor.r,
                    pixelColors[pixel].g * filterColor.g,
                    pixelColors[pixel].b * filterColor.b
                    );
                }
            }
        }

        newTexture.SetPixels(pixelColors);
        newTexture.Apply();
        return newTexture;
    }
}
