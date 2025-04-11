using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventorySlotView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI countText;

    private int _index;
    private InventoryItem _item;
    private InventoryDragService _dragService;

    public void Init(int index, InventoryDragService dragService)
    {
        _index = index;
        _dragService = dragService;
    }

    public void Setup(InventoryItem item)
    {
        _item = item;
        icon.enabled = true;
        icon.sprite = item.Data.Icon;
        countText.text = item.Count > 1 ? item.Count.ToString() : "";
    }

    public void Clear()
    {
        _item = null;
        icon.enabled = false;
        countText.text = "";
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_item == null) return;
        _dragService.BeginDrag(_index, _item.Data.Icon, eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _dragService.UpdateDrag(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_item == null)
        {
            _dragService.Cancel();
            return;
        }

        if (eventData.pointerEnter != null && eventData.pointerEnter.TryGetComponent(out InventorySlotView target))
        {
            _dragService.EndDrag(target._index);
        }
        else
        {
            _dragService.Cancel();
        }
    }
}
