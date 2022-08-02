using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Accessory", menuName = "ScriptableObjects/Equipments/Accessory")]
public class Accessory : Equipment
{
    [SerializeField] protected Element offensiveElement;
    [SerializeField] protected Element defensiveElement;

    public Accessory(EquipmentType equipmentType) : base(equipmentType)
    {
        type = EquipmentType.Acessory;
    }
}
