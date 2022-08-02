using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewCharacterWindow : MonoBehaviour
{
    //Character Description
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
    [SerializeField] TextMeshProUGUI hp;
    [SerializeField] TextMeshProUGUI mp;
    [SerializeField] TextMeshProUGUI atk;
    [SerializeField] TextMeshProUGUI mag;
    [SerializeField] TextMeshProUGUI def;
    [SerializeField] TextMeshProUGUI mdef;
    [SerializeField] TextMeshProUGUI evas;
    [SerializeField] TextMeshProUGUI atkspd;
    [SerializeField] TextMeshProUGUI critChan;
    [SerializeField] TextMeshProUGUI critDmg;
    [SerializeField] TextMeshProUGUI loot;


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

    void Start()
    {
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
        hp.text = "";
        mp.text = "";
        atk.text = "";
        mag.text = "";
        def.text = "";
        mdef.text = "";
        evas.text = "";
        atkspd.text = "";
        critChan.text = "";
        critDmg.text = "";
        loot.text = "";

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
        characterName.text = newCharacter.characterName?.ToString();
        
        age.text = newCharacter.age == 0 ? "Lost count" : newCharacter.age.ToString();
        genre.text = newCharacter.genre.ToString();
        race.text = newCharacter.race.name;
        job.text = newCharacter.firstClass.name;
        ability1.text = newCharacter.firstAbility.name;
        ability2.text = newCharacter.secondAbility.name;

        image.sprite = newCharacter.spriteRenderer.sprite;
        image.color = newCharacter.spriteRenderer.color;
        nameImage.text = newCharacter.characterName?.ToString();
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
        hp.text = newCharacter.hp.ToString();
        mp.text = newCharacter.mp.ToString();
        atk.text = newCharacter.atk.ToString();
        mag.text = newCharacter.mag.ToString();
        def.text = newCharacter.def.ToString();
        mdef.text = newCharacter.mdef.ToString();
        evas.text = newCharacter.evas.ToString();
        atkspd.text = newCharacter.atkspd.ToString();
        critChan.text = newCharacter.critChan.ToString();
        critDmg.text = newCharacter.critDmg.ToString();
        loot.text = newCharacter.loot.ToString();

        swordProficiency.text = newCharacter.swordProficiency.ToString();
        greatSwordProficiency.text = newCharacter.greatSwordProficiency.ToString();
        lanceProficiency.text = newCharacter.lanceProficiency.ToString();
        katanaProficiency.text = newCharacter.katanaProficiency.ToString();
        gloveProficiency.text = newCharacter.gloveProficiency.ToString();
        axeProficiency.text = newCharacter.axeProficiency.ToString();
        bowProficiency.text = newCharacter.bowProficiency.ToString();
        crossbowProficiency.text = newCharacter.crossbowProficiency.ToString();
        rodProficiency.text = newCharacter.rodProficiency.ToString();
        grimoryProficiency.text = newCharacter.grimoryProficiency.ToString();
        staffProficiency.text = newCharacter.staffProficiency.ToString();
        daggerProficiency.text = newCharacter.daggerProficiency.ToString();
        dualBladeProficiency.text = newCharacter.dualBladeProficiency.ToString();
        shieldProficiency.text = newCharacter.shieldProficiency.ToString();
        greatShieldProficiency.text = newCharacter.greatShieldProficiency.ToString();

        fireAffinity.text = newCharacter.fireAffinity.ToString();
        iceAffinity.text = newCharacter.iceAffinity.ToString();
        thunderAffinity.text = newCharacter.thunderAffinity.ToString();
        earthAffinity.text = newCharacter.earthAffinity.ToString();
        windAffinity.text = newCharacter.windAffinity.ToString();
        darknessAffinity.text = newCharacter.darknessAffinity.ToString();
        lightAffinity.text = newCharacter.lightAffinity.ToString();

        poisonResistance.text = newCharacter.poisonResistance.ToString();
        stunResistance.text = newCharacter.stunResistance.ToString();
        confusionResistance.text = newCharacter.confusionResistance.ToString();
        paralyseResistance.text = newCharacter.paralyseResistance.ToString();
        bleedResistance.text = newCharacter.bleedResistance.ToString();

    }
}
