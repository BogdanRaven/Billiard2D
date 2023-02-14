using BilliardFactory;
using Zenject;

namespace Infrastructure.Installers
{
    public class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFactoryInstallerInterfaces();
            BindBallFactory();
        }
        
        private void BindFactoryInstallerInterfaces()
        {
            Container.BindInterfacesTo<FactoryInstaller>().FromInstance(this).AsSingle();
        }
        
        private void BindBallFactory()
        {
            Container.Bind<IBallFactory>().To<BallFactory>().AsSingle();
        }
    }
}
