using UnityEngine;
using UnityEngine.UI;

public class InventorySlotView : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text countText;
    [SerializeField] private GameObject woundedIndicator;

    public void Setup(InventoryItem item)
    {
        icon.sprite = item.Data.Icon;
        countText.text = item.Count > 1 ? item.Count.ToString() : "";
        woundedIndicator.SetActive(item.Data.ItemType == ItemType.Animal && item.State == AnimalState.Wounded);
    }

    public void Clear()
    {
        icon.sprite = null;
        countText.text = "";
        woundedIndicator.SetActive(false);
    }
}
