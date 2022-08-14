using UnityEngine;

[CreateAssetMenu(fileName = "Grimory", menuName = "ScriptableObjects/Weapons/Grimory")]
public class Grimory : HandEquipment
{
    public Grimory(EquipmentType equipmentType) : base(equipmentType) { }

    public override TargetPattern BasicAttackPattern => TargetPattern.MiddleFirst;
    public override int Range => 1;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.Grimory;
}
