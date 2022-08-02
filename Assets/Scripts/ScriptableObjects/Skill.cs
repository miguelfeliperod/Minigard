using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Ability/Skill")]
public class Skill : ScriptableObject
{
    [SerializeField] string skillName;
    void UseAbility(Character user) { }
}
