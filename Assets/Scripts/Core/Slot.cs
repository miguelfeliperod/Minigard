using UnityEngine;

public class Slot : MonoBehaviour
{
    //[SerializeField] IBattler battler;
    [SerializeField] Battler battler;
    public Battler Battler { get => battler; set => battler = value; }

    public void SetBattler()
    {
        if (battler == null) return;
        Instantiate(battler, this.transform);
    }
}
