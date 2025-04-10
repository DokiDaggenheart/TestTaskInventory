using DG.Tweening;
using UnityEngine;

public class InventoryUIAnimation : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform panel;

    public void Show()
    {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.DOFade(1, 0.25f);
        panel.DOScale(Vector3.one, 0.25f).From(Vector3.zero).SetEase(Ease.OutBack);
    }

    public void Hide()
    {
        canvasGroup.DOFade(0, 0.2f).OnComplete(() =>
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        });
        panel.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InBack);
    }

}
