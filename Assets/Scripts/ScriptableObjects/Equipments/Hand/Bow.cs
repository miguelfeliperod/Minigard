using UnityEngine;

[CreateAssetMenu(fileName = "Bow", menuName = "ScriptableObjects/Weapons/Bow")]
public class Bow : HandEquipment
{
    public Bow(EquipmentType equipmentType) : base(equipmentType) { }

    public override TargetPattern BasicAttackPattern => TargetPattern.BackFirst;
    public override int Range => 1;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.Bow;
}
