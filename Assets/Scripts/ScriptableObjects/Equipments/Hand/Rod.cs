using UnityEngine;

[CreateAssetMenu(fileName = "Rod", menuName = "ScriptableObjects/Weapons/Rod")]
public class Rod : HandEquipment
{
    public Rod(EquipmentType equipmentType) : base(equipmentType) { }

    public override TargetPattern BasicAttackPattern => TargetPattern.MiddleFirst;
    public override int Range => 1;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.Rod;
}
