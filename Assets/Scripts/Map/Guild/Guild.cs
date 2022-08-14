using UnityEngine;
using TMPro;

public class Guild : MonoBehaviour
{
    [SerializeField] NewCharacterWindow recruitWindow;
    [SerializeField] TMP_InputField InputField;
    Character character;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
        if (GameManager.Instance.partyManager.IsPartyEmpty)
        {
            OnGenerateRandomRecruitClick();
            OnRecruitClick();
            recruitWindow.UploadCharacterInfosClick(character);
            GameManager.Instance.partyManager.FrontSlot.Character = GameManager.Instance.partyManager.RecruitedList[0];
        }
    }

    public void OnGenerateRandomRecruitClick()
    {
        character = ScriptableObject.CreateInstance<Character>();
        character.RandomizeCharacter();
        character.name = character.battlerName;
        character.sprite = GameManager.Instance.SpritesReferences.allCharacterBodySprite;
        recruitWindow.UploadCharacterInfosClick(character);
    }

    public void OnGenerateSeedRecruitClick()
    {
        character = ScriptableObject.CreateInstance<Character>();
        character.RandomizeCharacter(InputField.text);
        character.name = character.battlerName;
        recruitWindow.UploadCharacterInfosClick(character);
    }

    public void OnRecruitClick()
    {
        gameManager.partyManager.RecruitedList.Add(character);
        OnGenerateRandomRecruitClick();
    }
}
