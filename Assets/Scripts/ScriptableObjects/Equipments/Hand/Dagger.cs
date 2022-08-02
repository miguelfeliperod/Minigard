using UnityEngine;

[CreateAssetMenu(fileName = "Dagger", menuName = "ScriptableObjects/Weapons/Dagger")]
public class Dagger : HandEquipment
{
    public Dagger(EquipmentType equipmentType) : base(equipmentType) { }
}
