using UnityEngine;

public abstract class Item : ScriptableObject
{

    [SerializeField] protected string itemName = "";
    [SerializeField] protected string description = "";

    [SerializeField] Sprite sprite;
}
