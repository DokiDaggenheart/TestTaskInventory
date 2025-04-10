using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryController : MonoBehaviour
{
    [Inject] private InventoryModel _model;
    [Inject] private ItemsConfig _config;
    [Inject] private InventoryView _view;

    private void Start()
    {
        _view.Init(_model.Slots.Count);
        AddTestItems();
        _view.UpdateView(_model.Slots);
    }

    private void AddTestItems()
    {
        _model.AddItem(_config.GetItem(0), 100);
        _model.AddItem(_config.GetItem(1), 10);  
        _model.AddItem(_config.GetItem(50), 1, AnimalState.Wounded);
        _model.AddItem(_config.GetItem(50), 1, AnimalState.Healthy);
        _model.AddItem(_config.GetItem(100), 2);
    }
}
