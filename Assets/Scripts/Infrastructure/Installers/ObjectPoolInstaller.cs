using GameLogic;
using Zenject;

namespace Infrastructure.Installers
{
    public class ObjectPoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindCueBallsObjectPool();
        }

        private void BindCueBallsObjectPool()
        {
            Container.Bind<ICueBallsObjectPool>().To<CueBallsObjectPool>().AsSingle();
        }
    }
}