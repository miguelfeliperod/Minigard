using UnityEngine;

[CreateAssetMenu(fileName = "Glove", menuName = "ScriptableObjects/Equipments/Weapons/Glove")]
public class Glove : HandEquipment
{
    public override TargetPattern BasicAttackPattern => TargetPattern.FrontFirst;
    public override int Range => 1;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.Glove;
}
