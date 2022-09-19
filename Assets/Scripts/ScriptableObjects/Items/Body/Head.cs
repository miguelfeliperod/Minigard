using UnityEngine;

[CreateAssetMenu(fileName = "Head", menuName = "ScriptableObjects/Equipments/Head")]
public class Head : BodyEquipment
{
    public override EquipmentType Type => EquipmentType.Head;
}
