using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBattlerStats : MonoBehaviour
{
    public Battler battler;
    [SerializeField] Image frame;
    [SerializeField] Image battlerFace;
    [SerializeField] Image battlerHp;
    [SerializeField] Image battlerMp;
    [SerializeField] TextMeshProUGUI battlerNameText;

    public void SetInterface(Battler battler)
    {
        this.battler = battler;
        battlerFace.sprite = battler.sprite;
        battlerNameText.text = battler.battlerName;
    }

    public void UpdateInfo()
    {        
        battlerHp.gameObject.transform.localScale = new Vector2(
            Math.Clamp((float)battler.CurrentHp / (float)battler.maxHp, 0, 1), 1);

        battlerMp.gameObject.transform.localScale = new Vector2(
            Math.Clamp((float)battler.CurrentMp / (float)battler.maxMp, 0, 1), 1);
    }
}
