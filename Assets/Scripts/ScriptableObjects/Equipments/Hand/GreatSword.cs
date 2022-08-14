using UnityEngine;

[CreateAssetMenu(fileName = "GreatSword", menuName = "ScriptableObjects/Weapons/GreatSword")]
public class GreatSword : HandEquipment
{
    public GreatSword(EquipmentType equipmentType) : base(equipmentType) { }

    public override TargetPattern BasicAttackPattern => TargetPattern.FrontFirst;
    public override int Range => 2;
    public override TargetTeam TargetTeam => TargetTeam.Enemies;
    public override int MaxQuantity => 1;
    public override WeaponType WeaponType => WeaponType.GreatSword;
}
