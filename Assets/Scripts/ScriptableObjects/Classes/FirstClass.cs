using UnityEngine;

[CreateAssetMenu(fileName = "FirstClass", menuName = "ScriptableObjects/Classes/FirstClass")]
public class FirstClass : ScriptableObject
{
    [SerializeField] string className;
    [SerializeField] FirstClassType classType;

    [SerializeField] Skill firstAbilityChoice;
    public Skill FirstAbilityChoice { get => firstAbilityChoice; }
    [SerializeField] Skill secondAbilityChoice;
    public Skill SecondAbilityChoice { get => secondAbilityChoice; }
}
