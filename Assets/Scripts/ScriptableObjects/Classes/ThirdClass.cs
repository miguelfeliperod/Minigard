using UnityEngine;

[CreateAssetMenu(fileName = "ThirdClass", menuName = "ScriptableObjects/Classes/ThirdClass")]

public class ThirdClass : ScriptableObject
{
    [SerializeField] string className;
    [SerializeField] ThirdClassType classType;

    [SerializeField] Skill firstAbilityChoice;
    [SerializeField] Skill secondAbilityChoice;
}
