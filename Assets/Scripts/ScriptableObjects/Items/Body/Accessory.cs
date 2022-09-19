using UnityEngine;

[CreateAssetMenu(fileName = "Accessory", menuName = "ScriptableObjects/Equipments/Accessory")]
public class Accessory : Equipment
{
    public override EquipmentType Type => EquipmentType.Acessory;

    [SerializeField] protected Element offensiveElement;
    [SerializeField] protected Element defensiveElement;
}
