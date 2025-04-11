using UnityEngine;
using UnityEngine.UI;

public class InventoryDragIcon : MonoBehaviour, IDragIcon
{
    [SerializeField] private Image iconImage;
    [SerializeField] private CanvasGroup canvasGroup;

    public void Show(Sprite icon, Vector2 position, float alpha)
    {
        iconImage.sprite = icon;
        iconImage.enabled = true;
        canvasGroup.alpha = alpha;
        transform.position = position;
        gameObject.SetActive(true);
    }

    public void Move(Vector2 position)
    {
        transform.position = position;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        iconImage.enabled = false;
    }
}

public interface IDragIcon
{
    void Show(Sprite icon, Vector2 position, float alpha);
    void Move(Vector2 position);
    void Hide();
}
