using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewCharacterWindow : MonoBehaviour
{
    //Character Description
    [SerializeField] TextMeshProUGUI seed;
    [SerializeField] TextMeshProUGUI characterName;
    [SerializeField] TextMeshProUGUI age;
    [SerializeField] TextMeshProUGUI genre;
    [SerializeField] TextMeshProUGUI race;
    [SerializeField] TextMeshProUGUI job;
    [SerializeField] TextMeshProUGUI ability1;
    [SerializeField] TextMeshProUGUI ability2;

    // Image
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI nameImage;
    [SerializeField] TextMeshProUGUI raceImage;
    [SerializeField] TextMeshProUGUI jobImage;
    [SerializeField] TextMeshProUGUI levelImage;

    //Equipments
    [SerializeField] TextMeshProUGUI rHand;
    [SerializeField] TextMeshProUGUI lHand;
    [SerializeField] TextMeshProUGUI head;
    [SerializeField] TextMeshProUGUI chest;
    [SerializeField] TextMeshProUGUI legs;
    [SerializeField] TextMeshProUGUI foot;
    [SerializeField] TextMeshProUGUI acc1;
    [SerializeField] TextMeshProUGUI acc2;

    //Natural Stats
    [SerializeField] TextMeshProUGUI level;
    [SerializeField] TextMeshProUGUI toughness;
    [SerializeField] TextMeshProUGUI spirituality;
    [SerializeField] TextMeshProUGUI bravery;
    [SerializeField] TextMeshProUGUI inteligence;
    [SerializeField] TextMeshProUGUI faith;
    [SerializeField] TextMeshProUGUI evilness;
    [SerializeField] TextMeshProUGUI dexterity;
    [SerializeField] TextMeshProUGUI agility;
    [SerializeField] TextMeshProUGUI luck;


    //Weapon Proficiency
    [SerializeField] TextMeshProUGUI swordProficiency;
    [SerializeField] TextMeshProUGUI greatSwordProficiency;
    [SerializeField] TextMeshProUGUI lanceProficiency;
    [SerializeField] TextMeshProUGUI katanaProficiency;
    [SerializeField] TextMeshProUGUI gloveProficiency;
    [SerializeField] TextMeshProUGUI axeProficiency;
    [SerializeField] TextMeshProUGUI bowProficiency;
    [SerializeField] TextMeshProUGUI crossbowProficiency;
    [SerializeField] TextMeshProUGUI rodProficiency;
    [SerializeField] TextMeshProUGUI grimoryProficiency;
    [SerializeField] TextMeshProUGUI staffProficiency;
    [SerializeField] TextMeshProUGUI daggerProficiency;
    [SerializeField] TextMeshProUGUI dualBladeProficiency;
    [SerializeField] TextMeshProUGUI shieldProficiency;
    [SerializeField] TextMeshProUGUI greatShieldProficiency;

    //Elemental Affinities
    [SerializeField] TextMeshProUGUI fireAffinity; 
    [SerializeField] TextMeshProUGUI iceAffinity;
    [SerializeField] TextMeshProUGUI thunderAffinity;
    [SerializeField] TextMeshProUGUI earthAffinity;
    [SerializeField] TextMeshProUGUI windAffinity;
    [SerializeField] TextMeshProUGUI darknessAffinity;
    [SerializeField] TextMeshProUGUI lightAffinity;

    //Stats Ailments
    [SerializeField] TextMeshProUGUI poisonResistance;
    [SerializeField] TextMeshProUGUI stunResistance;
    [SerializeField] TextMeshProUGUI confusionResistance;
    [SerializeField] TextMeshProUGUI paralyseResistance;
    [SerializeField] TextMeshProUGUI bleedResistance;

    [SerializeField] Color fullRed;
    [SerializeField] Color fullOrange;
    [SerializeField] Color fullYellow;
    [SerializeField] Color lightGreen;
    [SerializeField] Color fullGreen;

    void Start()
    {
        seed.text = "";
        characterName.text = "";
        age.text = "";
        genre.text = "";
        race.text = "";
        job.text = "";
        ability1.text = "";
        ability2.text = "";


        rHand.text = "";
        lHand.text = "";
        head.text = "";
        chest.text = "";
        legs.text = "";
        foot.text = "";
        acc1.text = "";
        acc2.text = "";


        level.text = "";
        toughness.text = "";
        spirituality.text = "";
        bravery.text = "";
        inteligence.text = "";
        faith.text = "";
        evilness.text = "";
        dexterity.text = "";
        agility.text = "";
        luck.text = "";

        nameImage.text = "";
        raceImage.text = "";
        jobImage.text = "";
        levelImage.text = "";

        swordProficiency.text = "";
        greatSwordProficiency.text = "";
        lanceProficiency.text = "";
        katanaProficiency.text = "";
        gloveProficiency.text = "";
        axeProficiency.text = "";
        bowProficiency.text = "";
        crossbowProficiency.text = "";
        rodProficiency.text = "";
        grimoryProficiency.text = "";
        staffProficiency.text = "";
        daggerProficiency.text = "";
        dualBladeProficiency.text = "";
        shieldProficiency.text = "";
        greatShieldProficiency.text = "";


        fireAffinity.text = "";
        iceAffinity.text = "";
        thunderAffinity.text = "";
        earthAffinity.text = "";
        windAffinity.text = "";
        darknessAffinity.text = "";
        lightAffinity.text = "";


        poisonResistance.text = "";
        stunResistance.text = "";
        confusionResistance.text = "";
        paralyseResistance.text = "";
        bleedResistance.text = "";


    }

    public void UploadCharacterInfosClick(Character newCharacter)
    {
        seed.text = newCharacter.seed;
        characterName.text = newCharacter.battlerName?.ToString();
        
        age.text = newCharacter.age == 0 ? "Lost count" : newCharacter.age.ToString();
        genre.text = newCharacter.genre.ToString();
        race.text = newCharacter.race.name;
        job.text = newCharacter.firstClass.name;
        ability1.text = newCharacter.firstAbility.name;
        ability2.text = newCharacter.secondAbility.name;

        image.sprite = newCharacter.spriteRenderer.sprite;
        image.color = newCharacter.spriteRenderer.color;
        nameImage.text = newCharacter.battlerName?.ToString();
        raceImage.text = newCharacter.race.name;
        jobImage.text = newCharacter.firstClass.name;
        levelImage.text = "Lvl: " + newCharacter.level.ToString();

        rHand.text = newCharacter.rightHandEquipment?.ToString();
        lHand.text = newCharacter.leftHandEquipment?.ToString();
        head.text = newCharacter.headEquipment?.ToString();
        chest.text = newCharacter.chestEquipment?.ToString();
        legs.text = newCharacter.legEquipment?.ToString();
        foot.text = newCharacter.footEquipment?.ToString();
        acc1.text = newCharacter.accessoryOneEquipment?.ToString();
        acc2.text = newCharacter.accessoryTwoEquipment?.ToString();

        level.text = newCharacter.level.ToString();

        toughness.text = newCharacter.toughness.ToString();
        toughness.color = SetStatsNumberColor((int)newCharacter.toughness);
        spirituality.text = newCharacter.spirituality.ToString();
        spirituality.color = SetStatsNumberColor((int)newCharacter.spirituality);
        bravery.text = newCharacter.bravery.ToString();
        bravery.color = SetStatsNumberColor((int)newCharacter.bravery);
        inteligence.text = newCharacter.inteligence.ToString();
        inteligence.color = SetStatsNumberColor((int)newCharacter.inteligence);
        faith.text = newCharacter.faith.ToString();
        faith.color = SetStatsNumberColor((int)newCharacter.faith);
        evilness.text = newCharacter.evilness.ToString();
        evilness.color = SetStatsNumberColor((int)newCharacter.evilness);
        dexterity.text = newCharacter.dexterity.ToString();
        dexterity.color = SetStatsNumberColor((int)newCharacter.dexterity);
        agility.text = newCharacter.agility.ToString();
        agility.color = SetStatsNumberColor((int)newCharacter.agility);
        luck.text = newCharacter.luck.ToString();
        luck.color = SetStatsNumberColor((int)newCharacter.luck);

        swordProficiency.text = newCharacter.swordProficiency.ToString();
        swordProficiency.color = SetProficiencyColor(newCharacter.swordProficiency);
        greatSwordProficiency.text = newCharacter.greatSwordProficiency.ToString();
        greatSwordProficiency.color = SetProficiencyColor(newCharacter.greatSwordProficiency);
        lanceProficiency.text = newCharacter.lanceProficiency.ToString();
        lanceProficiency.color = SetProficiencyColor(newCharacter.lanceProficiency);
        katanaProficiency.text = newCharacter.katanaProficiency.ToString();
        katanaProficiency.color = SetProficiencyColor(newCharacter.katanaProficiency);
        gloveProficiency.text = newCharacter.gloveProficiency.ToString();
        gloveProficiency.color = SetProficiencyColor(newCharacter.gloveProficiency);
        axeProficiency.text = newCharacter.axeProficiency.ToString();
        axeProficiency.color = SetProficiencyColor(newCharacter.axeProficiency);
        bowProficiency.text = newCharacter.bowProficiency.ToString();
        bowProficiency.color = SetProficiencyColor(newCharacter.bowProficiency);
        crossbowProficiency.text = newCharacter.crossbowProficiency.ToString();
        crossbowProficiency.color = SetProficiencyColor(newCharacter.crossbowProficiency);
        rodProficiency.text = newCharacter.rodProficiency.ToString();
        rodProficiency.color = SetProficiencyColor(newCharacter.rodProficiency);
        grimoryProficiency.text = newCharacter.grimoryProficiency.ToString();
        grimoryProficiency.color = SetProficiencyColor(newCharacter.grimoryProficiency);
        staffProficiency.text = newCharacter.staffProficiency.ToString();
        staffProficiency.color = SetProficiencyColor(newCharacter.staffProficiency);
        daggerProficiency.text = newCharacter.daggerProficiency.ToString();
        daggerProficiency.color = SetProficiencyColor(newCharacter.daggerProficiency);
        dualBladeProficiency.text = newCharacter.dualBladeProficiency.ToString();
        dualBladeProficiency.color = SetProficiencyColor(newCharacter.dualBladeProficiency);
        shieldProficiency.text = newCharacter.shieldProficiency.ToString();
        shieldProficiency.color = SetProficiencyColor(newCharacter.shieldProficiency);
        greatShieldProficiency.text = newCharacter.greatShieldProficiency.ToString();
        greatShieldProficiency.color = SetProficiencyColor(newCharacter.greatShieldProficiency);

        fireAffinity.text = newCharacter.fireAffinity.ToString();
        fireAffinity.color = SetAffinityColor(newCharacter.fireAffinity);
        iceAffinity.text = newCharacter.iceAffinity.ToString();
        iceAffinity.color = SetAffinityColor(newCharacter.iceAffinity);
        thunderAffinity.text = newCharacter.thunderAffinity.ToString();
        thunderAffinity.color = SetAffinityColor(newCharacter.thunderAffinity);
        earthAffinity.text = newCharacter.earthAffinity.ToString();
        earthAffinity.color = SetAffinityColor(newCharacter.earthAffinity);
        windAffinity.text = newCharacter.windAffinity.ToString();
        windAffinity.color = SetAffinityColor(newCharacter.windAffinity);
        darknessAffinity.text = newCharacter.darknessAffinity.ToString();
        darknessAffinity.color = SetAffinityColor(newCharacter.darknessAffinity);
        lightAffinity.text = newCharacter.lightAffinity.ToString();
        lightAffinity.color = SetAffinityColor(newCharacter.lightAffinity);

        poisonResistance.text = newCharacter.poisonResistance.ToString();
        poisonResistance.color = SetAffinityColor(newCharacter.poisonResistance);
        stunResistance.text = newCharacter.stunResistance.ToString();
        stunResistance.color = SetAffinityColor(newCharacter.stunResistance);
        confusionResistance.text = newCharacter.confusionResistance.ToString();
        confusionResistance.color = SetAffinityColor(newCharacter.confusionResistance);
        paralyseResistance.text = newCharacter.paralyseResistance.ToString();
        paralyseResistance.color = SetAffinityColor(newCharacter.paralyseResistance);
        bleedResistance.text = newCharacter.bleedResistance.ToString();
        bleedResistance.color = SetAffinityColor(newCharacter.bleedResistance);
    }

    Color SetProficiencyColor(Proficiency proficiency)
    {
        switch (proficiency)
        {
            case Proficiency.S:
                return fullGreen;
            case Proficiency.A:
                return lightGreen;
            case Proficiency.B:
                return lightGreen;
            case Proficiency.C:
                return fullYellow;
            case Proficiency.D:
                return fullOrange;
            case Proficiency.E:
                return fullOrange;
            case Proficiency.F:
                return fullRed;
        }
        return new Color(0.6f, 0.6f, 0.0f);
    }

    Color SetAffinityColor(Affinity affinity)
    {
        switch (affinity)
        {
            case Affinity.Impressive:
                return fullGreen;
            case Affinity.High:
                return lightGreen;
            case Affinity.Neutral:
                return fullYellow;
            case Affinity.Low:
                return fullOrange;
            case Affinity.Poor:
                return fullRed;
        }
        return new Color(0.5f, 0.5f, 0.0f);
    }
    Color SetStatsNumberColor(int value)
    {
        switch (value)
        {
            case 1:
            case 2:
                return fullRed;
            case 3:
            case 4:
                return fullOrange;
            case 5:
            case 6:
                return fullYellow;
            case 7:
            case 8:
                return lightGreen;
            default:
                return fullGreen;
        }
    }

}
