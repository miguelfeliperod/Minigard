using UnityEngine;
using UnityEngine.EventSystems;

public class ColliderButton : MonoBehaviour
{
    [SerializeField] Collider2D collider2d;
    [SerializeField] SpriteRenderer rend;
    [SerializeField] GameObject screen;

    Color isHighlighted;
    Color isNotHighlighted;

    Vector2 originalScale;
    Vector3 upscaleFactor;
    Vector3 maxScaleSize;

    void Start() 
    {    
        originalScale = transform.localScale;
        upscaleFactor = transform.localScale;
        maxScaleSize = transform.localScale * 1.1f;
        isHighlighted = rend.color;
        isNotHighlighted = isHighlighted * 0.9f;
        isNotHighlighted.a = 100f;
        rend.color = isNotHighlighted;
    }

    private void OnMouseEnter()
    {
        rend.color = isHighlighted;
    }

    private void OnMouseExit()
    {
        rend.color = isNotHighlighted;
        transform.localScale = originalScale;
    }

    void OnMouseOver()
    {
        if (transform.localScale.x < maxScaleSize.x && transform.localScale.y < maxScaleSize.y)
        transform.localScale += upscaleFactor * Time.deltaTime;
    }

    private void OnMouseUp()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (screen != null)
            screen.SetActive(true); 
    }
}
