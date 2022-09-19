using UnityEngine;

[CreateAssetMenu(fileName = "GreatShield", menuName = "ScriptableObjects/Equipments/GreatShield")]
public class GreatShield : HandEquipment
{

    public override TargetPattern BasicAttackPattern => TargetPattern.None;
    public override int Range => 0;
    public override TargetTeam TargetTeam => TargetTeam.None;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.GreatShield;
}
