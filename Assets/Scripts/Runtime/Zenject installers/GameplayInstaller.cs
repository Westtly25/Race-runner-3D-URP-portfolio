using Zenject;
using UnityEngine;
using UniRx.Diagnostics;
using Assets.Scripts.Runtime.Sound_System;
using Assets.Scripts.Runtime.Location_System;
using Logger = UniRx.Diagnostics.Logger;

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

        private void BindLocationSpawner()
        {
            Container.Bind<LocationSegmentSpawner>()
                     .FromInstance(locationSegmentSpawner)
                     .AsSingle()
                     .NonLazy();
        }
    }
}