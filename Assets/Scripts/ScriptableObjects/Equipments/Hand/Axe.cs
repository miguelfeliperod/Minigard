using UnityEngine;

[CreateAssetMenu(fileName = "Axe", menuName = "ScriptableObjects/Weapons/Axe")]
public class Axe : HandEquipment
{
    public Axe(EquipmentType equipmentType) : base(equipmentType) { }
}
