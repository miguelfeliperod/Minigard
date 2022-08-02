using UnityEngine;

[CreateAssetMenu(fileName = "Crossbow", menuName = "ScriptableObjects/Weapons/Crossbow")]
public class Crossbow : HandEquipment
{
    public Crossbow(EquipmentType equipmentType) : base(equipmentType) { }
}
