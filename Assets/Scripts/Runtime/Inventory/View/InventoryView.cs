using Zenject;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject slotPrefab;
    [Inject] private InventoryDragService _dragService;

    private List<InventorySlotView> _views = new();

    public void Init(int slotCount)
    {
        for (int i = 0; i < slotCount; i++)
        {
            var obj = Instantiate(slotPrefab, contentParent);
            var slotView = obj.GetComponent<InventorySlotView>();
            slotView.Init(i, _dragService);
            _views.Add(obj.GetComponent<InventorySlotView>());
        }
    }

    public void UpdateView(List<InventorySlot> slots)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsEmpty)
                _views[i].Clear();
            else
                _views[i].Setup(slots[i].Item);
        }
    }
}
