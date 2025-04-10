using UnityEngine;

[System.Serializable]
public class ItemData
{
    public int ID;
    public string Name;
    public ItemType ItemType;
    public Sprite Icon;
    public int StackLimit;
}

public enum ItemType
{
    Resource,
    Animal,
    Consumable
}

public enum AnimalState
{
    Healthy,
    Wounded
}