using UnityEngine;

[CreateAssetMenu(fileName = "Foot", menuName = "ScriptableObjects/Equipments/Foot")]

public class Foot : BodyEquipment
{
    public override EquipmentType Type => EquipmentType.Foot;
}
