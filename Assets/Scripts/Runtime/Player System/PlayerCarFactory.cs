using Zenject;
using UnityEngine;
using System.Threading.Tasks;
using Assets.Code.Scripts.Runtime.Assets_Management;

namespace Assets.Scripts.Runtime.Player_System
{
    public class PlayerCarFactory : IPlayerCarFactory
    {
        private readonly DiContainer container;
        private readonly IAssetProvider assetProvider;

        [Inject]
        public PlayerCarFactory(DiContainer container, IAssetProvider assetProvider)
        {
            this.container = container;
            this.assetProvider = assetProvider;
        }

        public async Task<Car> Create()
        {
            Car car = await assetProvider.LoadAsync<Car>(AssetsAdress.Car1);
            return container.InstantiatePrefabForComponent<Car>(car);
        }

        public async Task<Car> Create(Vector3 at, Transform parent)
        {
            Car car = await assetProvider.LoadAsync<Car>(AssetsAdress.Car1);
            return container.InstantiatePrefabForComponent<Car>(car, at, Quaternion.identity, parent);
        }
    }
}