using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EditPartySlotManager : MonoBehaviour
{
    int selectedRecruitIndex;
    CharacterPartySlotType selectedPartyIndex;

    public int SelectedRecruitIndex { get => selectedRecruitIndex; set => selectedRecruitIndex = value; }
    public CharacterPartySlotType SelectedPartyIndex { get => selectedPartyIndex; set => selectedPartyIndex = value; }

    [SerializeField] List<EditPartySlot> partySlotList = new(5);
    [SerializeField] GameObject charactersList;
    [SerializeField] RecruitCharacterItem RecruitListCharacter;
    [SerializeField] List<RecruitCharacterItem> recruitsList;
    PartyManager partyManager;

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI raceText;
    [SerializeField] TextMeshProUGUI ageText;
    [SerializeField] TextMeshProUGUI genreText;
    [SerializeField] TextMeshProUGUI classText;
    [SerializeField] TextMeshProUGUI lvlText;
    [SerializeField] TextMeshProUGUI firstAbilityText;
    [SerializeField] TextMeshProUGUI secondAbilityText;

    // Start is called before the first frame update
    void OnEnable()
    {
        partyManager = GameManager.Instance.partyManager;
        UpdatePartySlots();
        UpdateRecruitsList();
    }

    void UpdateRecruitsList()
    {
        ClearRecruits();
        for(int i = 0; i < GameManager.Instance.partyManager.RecruitedList.Count; i++)
        {
            var character = GameManager.Instance.partyManager.RecruitedList[i];
            var recruit = Instantiate(RecruitListCharacter);
            recruit.character = character;
            recruit.name = character.battlerName;
            recruit.transform.SetParent(charactersList.transform);
            recruit.image.sprite = character.sprite;
            recruit.image.color = character.bodyColor;
            recruit.rectTransform.anchoredPosition = new Vector2(40, -40) + new Vector2(150 * (i % 7), -50 - 200 * (i / 7));

            recruit.number.text = i.ToString();
            recruit.recruitName.text = character.battlerName;
            recruit.job.text = character.firstClass.name.ToString();
            recruit.level.text = "Lvl: " + character.level.ToString();

            recruitsList.Add(recruit);
        }
        var recTransform = charactersList.GetComponent<Image>().rectTransform;
        recTransform.sizeDelta = new Vector2(recTransform.sizeDelta.x, Math.Max(630,
            (GameManager.Instance.partyManager.RecruitedList.Count / 7 + 1) * 205));
    }
    void ClearRecruits()
    {
        for(int i = 0; i < charactersList.transform.childCount; i++)
        {
            Destroy(charactersList.transform.GetChild(i).gameObject);
        }
        recruitsList.Clear();
    }

    public void BanRecruit()
    {
        if (selectedRecruitIndex < 0) return;

        var characterToRemove = partyManager.RecruitedList[selectedRecruitIndex];
        foreach(CharacterPartySlot slot in partyManager.PartyList)
        {
            if(slot.Character == characterToRemove)
            {
                if (partyManager.CountActiveCharacters <= 1) return;
                slot.Character = null;
            }
        }
        partyManager.RecruitedList.RemoveAt(selectedRecruitIndex);
        UnselectAllPartySlots();
        UnselectAllRecruitSlots();
        UpdatePartySlots();
        UpdateRecruitsList();
    }

    public void SelectRecruit(RecruitCharacterItem recruitToSelect) {
        selectedRecruitIndex = recruitsList.IndexOf(recruitToSelect);
        foreach (RecruitCharacterItem recruit in recruitsList)
        {
            recruit.SetSelectedImageState(recruit == recruitToSelect); 
        }
        UpdateTexts(recruitToSelect.character);
    }

    void UpdateTexts(Character character)
    {
        nameText.text = character.battlerName;
        raceText.text = character.race.name;
        ageText.text = character.age == 0 ? "Lost count" : character.age.ToString();
        genreText.text = character.genre.ToString();
        classText.text = character.firstClass.name.ToString();
        lvlText.text = character.level.ToString();
        firstAbilityText.text = character.firstAbility.name.ToString();
        secondAbilityText.text = character.secondAbility.name.ToString();
    }

    void UnselectAllRecruitSlots()
    {
        foreach (RecruitCharacterItem recruit in recruitsList)
        {
            recruit.SetSelectedImageState(false);
        }
        selectedRecruitIndex = -1;
    }

    public void AddCharacterToParty()
    {
        if (selectedRecruitIndex < 0) return;
        if (VerifyAlreadyInParty(recruitsList[selectedRecruitIndex].character)) return;
        switch (selectedPartyIndex)
        {
            case CharacterPartySlotType.FrontSlot:
                partyManager.FrontSlot.Character = recruitsList[selectedRecruitIndex].character;
                break;
            case CharacterPartySlotType.MidFrontSlot:
                partyManager.MidFrontSlot.Character = recruitsList[selectedRecruitIndex].character;
                break;
            case CharacterPartySlotType.MidSlot:
                partyManager.MidSlot.Character = recruitsList[selectedRecruitIndex].character;
                break;
            case CharacterPartySlotType.MidBackSlot:
                partyManager.MidBackSlot.Character = recruitsList[selectedRecruitIndex].character;
                break;
            case CharacterPartySlotType.BackSlot:
                partyManager.BackSlot.Character = recruitsList[selectedRecruitIndex].character;
                break;
            default:
                break;
        }
        
        UpdatePartySlots();
        UpdateRecruitsList();
        UnselectAllPartySlots();
        UnselectAllRecruitSlots();
    }

    bool VerifyAlreadyInParty(Character character)
    {
        foreach(CharacterPartySlot slot in partyManager.PartyList)
        {
            if (slot.Character == character) return true;
        }
        return false;
    }

    public void RemoveCharacterFromParty()
    {
        if (partyManager.CountActiveCharacters <= 1) return;
        switch (selectedPartyIndex)
        {
            case CharacterPartySlotType.FrontSlot:
                partyManager.PartyList[0].Character = null;
                break;
            case CharacterPartySlotType.MidFrontSlot:
                partyManager.PartyList[1].Character = null;
                break;
            case CharacterPartySlotType.MidSlot:
                partyManager.PartyList[2].Character = null;
                break;
            case CharacterPartySlotType.MidBackSlot:
                partyManager.PartyList[3].Character = null;
                break;
            case CharacterPartySlotType.BackSlot:
                partyManager.PartyList[4].Character = null;
                break;
            default:
                break;
        }
        UpdatePartySlots();
        UpdateRecruitsList();
        UnselectAllPartySlots();
        UnselectAllRecruitSlots();
    }

    public void UpdatePartySlots()
    {
        for (int i = 0; i < partyManager.PartyList.Count; i++)
        {
            if (i >= partyManager.CurrentPartySizeLimit)
            {
                partySlotList[i].gameObject.SetActive(false);
            }
            else if (partyManager.PartyList[i].Character == null)
            {
                partySlotList[i].ResetSlot();
            }
            else {
                partySlotList[i].gameObject.SetActive(true);
                partySlotList[i].Character = partyManager.PartyList[i].Character;
                partySlotList[i].RefreshTexts();
            }
        }   
    }

    void UnselectAllPartySlots(){
        foreach (EditPartySlot partySlot in partySlotList)
        {
            partySlot.SetSelectedImageState(false);
        }
        selectedPartyIndex = CharacterPartySlotType.None;
    }

    public void SelectPartySlot(CharacterPartySlotType slotType)
    {
        selectedPartyIndex = slotType;
        foreach (EditPartySlot partySlot in partySlotList)
        {
            partySlot.SetSelectedImageState(partySlot.slotType == slotType);
        }
    }
}
