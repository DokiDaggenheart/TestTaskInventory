using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    [SerializeField] private ItemsConfig itemsConfig;

    public override void InstallBindings()
    {
        Container.Bind<ItemsConfig>().FromInstance(itemsConfig).AsSingle();
        Container.Bind<InventoryModel>().AsSingle().WithArguments(20);
        Container.Bind<InventoryController>().FromComponentInHierarchy().AsSingle();
    }
}
