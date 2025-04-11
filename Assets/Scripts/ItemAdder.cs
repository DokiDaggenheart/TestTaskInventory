using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemAdder : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_InputField idInput;
    [SerializeField] private TMP_InputField countInput;
    [SerializeField] private Button addButton;

    [Header("References")]
    [SerializeField] private InventoryController inventoryController;
    [SerializeField] private ItemsConfig itemsConfig;

    private void Start()
    {
        addButton.onClick.AddListener(AddItem);
    }

    private void AddItem()
    {
        Debug.Log("Adddd");
        inventoryController.AddItem(Convert.ToInt32(idInput.text), Convert.ToInt32(countInput.text));
    }
}
