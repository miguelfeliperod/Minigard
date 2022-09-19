using UnityEngine;

[CreateAssetMenu(fileName = "Chest", menuName = "ScriptableObjects/Equipments/Chest")]
public class Chest : BodyEquipment
{
    public override EquipmentType Type => EquipmentType.Chest;
}
