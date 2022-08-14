using UnityEngine;

[CreateAssetMenu(fileName = "Axe", menuName = "ScriptableObjects/Weapons/Axe")]
public class Axe : HandEquipment
{
    public Axe(EquipmentType equipmentType) : base(equipmentType) { }

    public override TargetPattern BasicAttackPattern => TargetPattern.FrontFirst;
    public override int Range => 3;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.Axe;
}
