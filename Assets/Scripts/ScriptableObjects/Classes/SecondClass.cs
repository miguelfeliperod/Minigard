using UnityEngine;

[CreateAssetMenu(fileName = "SecondClass", menuName = "ScriptableObjects/Classes/SecondClass")]
public class SecondClass : ScriptableObject
{
    [SerializeField] string className;
    [SerializeField] SecondClassType classType;

    [SerializeField] Skill firstAbilityChoice;
    [SerializeField] Skill secondAbilityChoice;
}