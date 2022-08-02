using UnityEngine;

[CreateAssetMenu(fileName = "Bow", menuName = "ScriptableObjects/Weapons/Bow")]
public class Bow : HandEquipment
{
    public Bow(EquipmentType equipmentType) : base(equipmentType) { }
}
