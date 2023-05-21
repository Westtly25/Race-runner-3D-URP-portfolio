using Zenject;
using UnityEngine;
using Logger = UniRx.Diagnostics.Logger;
using Assets.Scripts.Runtime.Save_System;
using Assets.Scripts.Runtime.Sound_System;
using Assets.Scripts.Runtime.Location_System;

namespace Assets.Scripts.Runtime.Zenject_installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField]
        private LocationSegmentSpawner locationSegmentSpawner;

        public override void InstallBindings()
        {
            BindLogger();
            BindInputService();
            BindSoundService();
            BindSaveService();
            BindLocationSpawner();
        }

        private void BindLogger()
        {
            Logger logger = new Logger("Main logger");

            Container.Bind<Logger>()
                     .FromInstance(logger)
                     .AsSingle()
                     .NonLazy();
        }

        private void BindInputService()
        {
            Container.BindInterfacesAndSelfTo<InputService>()
                     .FromNew()
                     .AsSingle()
                     .NonLazy();
        }

        private void BindSoundService()
        {
            Container.BindInterfacesAndSelfTo<SoundService>()
                     .FromNew()
                     .AsSingle()
                     .NonLazy();
        }

        public void BindSaveService()
        {
            Container.Bind<SaveService>()
                     .FromNew()
                     .AsSingle()
                     .NonLazy();
        }

        private void BindLocationSpawner()
        {
            Container.Bind<LocationSegmentSpawner>()
                     .FromInstance(locationSegmentSpawner)
                     .AsSingle()
                     .NonLazy();
        }
    }
}