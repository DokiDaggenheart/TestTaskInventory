using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryController : MonoBehaviour
{
    [Inject] private InventoryModel _model;
    [Inject] private ItemsConfig _config;
    [Inject] private InventoryDragService _dragService;
    private InventoryView _view;

    private void Start()
    {
        _view = GetComponent<InventoryView>();
        _view.Init(_model.Slots.Count);
        AddTestItems();
        _view.UpdateView(_model.Slots);
        _dragService.OnSwapRequested += _model.SwapItems;
        _dragService.OnSwapRequested += (int a, int b) => _view.UpdateView(_model.Slots);
    }

    private void AddTestItems()
    {
        _model.AddItem(_config.GetItem(0), 500);
        _model.AddItem(_config.GetItem(0), 500);
        _model.AddItem(_config.GetItem(0), 50);
        _model.AddItem(_config.GetItem(0), 50);
        _model.AddItem(_config.GetItem(0), 50);
        _model.AddItem(_config.GetItem(0), 50);
        _model.AddItem(_config.GetItem(0), 50);
        _model.AddItem(_config.GetItem(0), 50);
        _model.AddItem(_config.GetItem(1), 10);  
        _model.AddItem(_config.GetItem(50), 1, AnimalState.Wounded);
        _model.AddItem(_config.GetItem(50), 1, AnimalState.Wounded);
        _model.AddItem(_config.GetItem(50), 1, AnimalState.Healthy);
        _model.AddItem(_config.GetItem(100), 2);
    }

    public void AddItem(int ID, int count)
    {
        _model.AddItem(_config.GetItem(ID), count);
        _view.UpdateView(_model.Slots);
    }
}
