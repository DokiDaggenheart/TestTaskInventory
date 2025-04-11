using System;
using UnityEngine;
using Zenject;

public class InventoryDragService : MonoBehaviour
{
    [Inject] private IDragIcon dragIcon;
    [SerializeField, Range(0f, 1f)] private float dragIconAlpha = 0.6f;

    private int _sourceIndex = -1;
    public event Action<int, int> OnSwapRequested;

    public void BeginDrag(int sourceIndex, Sprite icon, Vector2 position)
    {
        _sourceIndex = sourceIndex;
        dragIcon.Show(icon, position, dragIconAlpha);
    }

    public void UpdateDrag(Vector2 position)
    {
        dragIcon.Move(position);
    }

    public void EndDrag(int targetIndex)
    {
        dragIcon.Hide();
        if (_sourceIndex != targetIndex && _sourceIndex != -1)
            OnSwapRequested?.Invoke(_sourceIndex, targetIndex);

        _sourceIndex = -1;
    }

    public void Cancel()
    {
        dragIcon.Hide();
        _sourceIndex = -1;
    }
}
