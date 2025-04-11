public class InventoryItem
{
    public ItemData Data;
    public int Count;
    public AnimalState? State;

    public InventoryItem(ItemData data, int count, AnimalState? state = null)
    {
        Data = data;
        Count = count;
        State = state;
    }
}
