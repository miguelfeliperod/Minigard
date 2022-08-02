using UnityEngine;

public class Guild : MonoBehaviour
{
    [SerializeField] NewCharacterWindow createCharacterWindow;
    Character character;
    public void OnGenerateRandomRecruitClick()
    {
        if (character != null)
            Destroy(character.gameObject);
        character = Instantiate(GameManager.Instance.PrefabCharacter);
        character.RandomizeCharacter();
        createCharacterWindow.UploadCharacterInfosClick(character);
    }
}
