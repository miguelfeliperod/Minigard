using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField] public string itemName = "";
    [SerializeField] public string description = "";
    [SerializeField] public int price = 1;

    [SerializeField] public Sprite sprite;
    [SerializeField] public Color spriteColor;
}
