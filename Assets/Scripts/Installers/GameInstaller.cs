using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private StatsManager statsManager;
    [SerializeField] private DataManager dataManager;
    public override void InstallBindings()
    {
        Container.Bind<Inventory>().FromInstance(inventory);
        Container.Bind<StatsManager>().FromInstance(statsManager);
        Container.Bind<DataManager>().FromInstance(dataManager);
    }
}