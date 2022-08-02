using UnityEngine;

[CreateAssetMenu(fileName = "Katana", menuName = "ScriptableObjects/Weapons/Katana")]
public class Katana : HandEquipment
{
    public Katana(EquipmentType equipmentType) : base(equipmentType) { }
}
