using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    [SerializeField] private ItemsConfig itemsConfig;
    [SerializeField] private int slotsCount;
    public override void InstallBindings()
    {
        Container.Bind<ItemsConfig>().FromInstance(itemsConfig).AsSingle();
        Container.Bind<InventoryModel>().AsSingle().WithArguments(slotsCount);
        Container.Bind<InventoryController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<InventoryDragService>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<InventoryDragIcon>().FromComponentInHierarchy().AsSingle();
    }
}
