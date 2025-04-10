using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ItemsConfig", menuName = "Configs/ItemsConfig")]
public class ItemsConfig : ScriptableObject
{
    [SerializeField] private List<ItemData> items;

    private Dictionary<int, ItemData> _lookup;

    private void OnEnable()
    {
        _lookup = new Dictionary<int, ItemData>();
        if(items != null)
        {
            foreach (var item in items)
            {
                _lookup[item.ID] = item;
            }
        }
    }

    public ItemData GetItem(int id) => _lookup.TryGetValue(id, out var item) ? item : null;
}
