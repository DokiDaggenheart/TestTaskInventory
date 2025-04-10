using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject slotPrefab;

    private List<InventorySlotView> _views = new();

    public void Init(int slotCount)
    {
        for (int i = 0; i < slotCount; i++)
        {
            var obj = Instantiate(slotPrefab, contentParent);
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
