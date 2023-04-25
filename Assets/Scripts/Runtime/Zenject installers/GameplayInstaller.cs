using Zenject;
using UniRx.Diagnostics;

namespace Assets.Scripts.Runtime.Zenject_installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLogger();
            BindInputService();
        }

        private void BindLogger()
        {
            Logger logger = new Logger("Main app logger");

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
    }
}