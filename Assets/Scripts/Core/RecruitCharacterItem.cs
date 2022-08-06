using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecruitCharacterItem : MonoBehaviour
{
    public Character character;
    public Image image;
    public Image selectedImage;
    public TextMeshProUGUI number;
    public TextMeshProUGUI recruitName;
    public TextMeshProUGUI job;
    public TextMeshProUGUI level;
    public EditPartySlotManager partyManager;
    public RectTransform rectTransform;
    public Button button;

    void Start() {
        SetSelectedImageState(false);
        partyManager = FindObjectOfType<EditPartySlotManager>();
    }

    public void OnRecruitClick()
    {
        if (selectedImage.enabled)
        {
            selectedImage.enabled = false;
            partyManager.SelectedRecruitIndex = -1;
            return;
        }
        partyManager.SelectRecruit(this);
    }

    public void SetSelectedImageState(bool state)
    {
        selectedImage.enabled = state;
    }

    public void SetEnableState(bool state)
    {
        button.interactable = state;
    }
}
