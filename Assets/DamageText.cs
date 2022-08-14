using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField] TextMeshPro damageText;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] float timer = 0;
    [SerializeField] float duration = 2;
    [SerializeField] float yDeslocation = 2;
    [SerializeField] AnimationCurve animationCurve;

    public void SetValues(string text, Color color)
    {
        damageText.text = text;
        damageText.color = color;
    }

    void Update()
    {
        if (timer > duration) Destroy(gameObject);
        rectTransform.localPosition = new Vector2(0, Mathf.Lerp(0, yDeslocation, animationCurve.Evaluate(timer/duration)));
        timer += Time.deltaTime;
    }
}
