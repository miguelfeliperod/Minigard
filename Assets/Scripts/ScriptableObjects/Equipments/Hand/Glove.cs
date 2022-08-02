using UnityEngine;

[CreateAssetMenu(fileName = "Glove", menuName = "ScriptableObjects/Weapons/Glove")]
public class Glove : HandEquipment
{
    public Glove(EquipmentType equipmentType) : base(equipmentType) { }
}
