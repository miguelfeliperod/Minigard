using UnityEngine;

[CreateAssetMenu(fileName = "Dagger", menuName = "ScriptableObjects/Weapons/Dagger")]
public class Dagger : HandEquipment
{
    public Dagger(EquipmentType equipmentType) : base(equipmentType) { }

    public override TargetPattern BasicAttackPattern => TargetPattern.FrontFirst;
    public override int Range => 1;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.Dagger;
}
