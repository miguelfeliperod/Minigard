using UnityEngine;

public abstract class Equipment : ScriptableObject
{
    protected Equipment(EquipmentType type)
    {
        this.type = type;
    }
    [SerializeField] protected EquipmentType type;

    [SerializeField] protected string equipmentName = "";

    [SerializeField] protected string description = "";

    [SerializeField] protected float hpBonus = 0;
    [SerializeField] protected float mpBonus = 0;
    [SerializeField] protected float atkBonus = 0;
    [SerializeField] protected float magBonus = 0;
    [SerializeField] protected float defBonus = 0;
    [SerializeField] protected float mdefBonus = 0;
    [SerializeField] protected float evasionBonus = 0;
    [SerializeField] protected float atkspdBonus = 0;
    [SerializeField] protected float critBonus = 0;
    [SerializeField] protected float lootBonus = 0;

    [SerializeField] Sprite sprite;

}
