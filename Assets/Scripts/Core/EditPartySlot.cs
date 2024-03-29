using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EditPartySlot : MonoBehaviour
{
    [SerializeField] Character character;
    public Character Character { get => character; set => character = value; }

    public CharacterPartySlotType slotType;

    [SerializeField] Image image;
    public Image Image { get => image; set => image = value; }

    [SerializeField] EditPartySlotManager partyManager;

    [SerializeField] Image selectedImage;

    [SerializeField] Button button;
    
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI jobText;
    public TextMeshProUGUI lvlText;

    void Start() {
        if (character != null)
            RefreshTexts();
    }

    public void OnPartySlotClick()
    {
        if (selectedImage.enabled)
        {
            selectedImage.enabled = false;
            partyManager.SelectedPartyIndex = CharacterPartySlotType.None;
            return;
        }
        partyManager.SelectPartySlot(slotType);
    }

    public void SetSelectedImageState(bool state)
    {
        selectedImage.enabled = state;
    }

    public void RefreshTexts()
    {
        image.sprite = character.sprite;
        image.color = Color.white;
        nameText.text = character.battlerName;
    }

    public void ResetSlot()
    {
        nameText.text = "Empty";
        image.color = Color.clear;
    }
}
