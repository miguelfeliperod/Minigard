using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] Battler battler;
    [SerializeField] SpriteRenderer spriteRenderer;
    public Battler Battler { get => battler; set => battler = value; }

    public void SetBattler()
    {
        if (battler == null) return;
        spriteRenderer.sprite = battler.sprite;
        spriteRenderer.color= battler.bodyColor;
    }
}
