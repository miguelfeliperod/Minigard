using UnityEngine;

[CreateAssetMenu(fileName = "Katana", menuName = "ScriptableObjects/Weapons/Katana")]
public class Katana : HandEquipment
{
    public Katana(EquipmentType equipmentType) : base(equipmentType) { }

    public override TargetPattern BasicAttackPattern => TargetPattern.FrontFirst;
    public override int Range => 2;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.Katana;
}
