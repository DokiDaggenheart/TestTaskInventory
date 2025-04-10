using System.Collections.Generic;
using UnityEngine;

public class InventoryModel
{
    public List<InventorySlot> Slots { get; private set; }
    public int MaxSlots { get; private set; }

    public InventoryModel(int maxSlots)
    {
        MaxSlots = maxSlots;
        Slots = new List<InventorySlot>(maxSlots);
        for (int i = 0; i < maxSlots; i++)
            Slots.Add(new InventorySlot());
    }

    public void AddItem(ItemData data, int count, AnimalState? state = null)
    {
        while (count > 0)
        {
            var slot = FindStackableSlot(data, state);
            if (slot != null)
            {
                int canAdd = data.StackLimit - slot.Item.Count;
                int toAdd = System.Math.Min(canAdd, count);
                slot.Item.Count += toAdd;
                count -= toAdd;
            }
            else
            {
                var emptySlot = FindEmptySlot();
                if (emptySlot == null) break;

                int toAdd = System.Math.Min(data.StackLimit, count);
                emptySlot.Item = new InventoryItem(data, toAdd, state);
                count -= toAdd;
            }
        }
    }

    private InventorySlot FindStackableSlot(ItemData data, AnimalState? state)
    {
        foreach (var slot in Slots)
        {
            if (slot.IsEmpty) continue;
            if (slot.Item.Data.ID == data.ID &&
                slot.Item.Count < data.StackLimit &&
                slot.Item.State == state)
                return slot;
        }
        return null;
    }

    private InventorySlot FindEmptySlot()
    {
        foreach (var slot in Slots)
        {
            if (slot.IsEmpty) return slot;
        }
        return null;
    }
}
