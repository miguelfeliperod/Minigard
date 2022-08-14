using UnityEngine;

[CreateAssetMenu(fileName = "Crossbow", menuName = "ScriptableObjects/Weapons/Crossbow")]
public class Crossbow : HandEquipment
{
    public Crossbow(EquipmentType equipmentType) : base(equipmentType) { }

    public override TargetPattern BasicAttackPattern => TargetPattern.BackFirst;
    public override int Range => 3;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.Crossbow;
}
