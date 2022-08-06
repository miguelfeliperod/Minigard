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
            GameManager.Instance.partyManager.FrontSlot.Character = GameManager.Instance.partyManager.RecruitedList[0];
        }
    }

    public void OnGenerateRandomRecruitClick()
    {
        if (character != null)
            Destroy(character.gameObject);
        character = Instantiate(gameManager.PrefabCharacter);
        character.RandomizeCharacter();
        recruitWindow.UploadCharacterInfosClick(character);
    }

    public void OnGenerateSeedRecruitClick()
    {
        if (character != null)
            Destroy(character.gameObject);
        character = Instantiate(gameManager.PrefabCharacter);
        character.RandomizeCharacter(InputField.text);
        recruitWindow.UploadCharacterInfosClick(character);
    }

    public void OnRecruitClick()
    {
        character.gameObject.name = character.battlerName;
        gameManager.partyManager.RecruitedList.Add(character);
        character.transform.SetParent(gameManager.playerCharacters.transform);
        character = null;
        OnGenerateRandomRecruitClick();
    }
}
