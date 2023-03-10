using GameMechanics;
using UnityEngine;
using Zenject;

public class PlayerInputInstaller : MonoInstaller
{
    [SerializeField] private PlayerInputController _playerInputController;
    public override void InstallBindings()
    {
        BindPlayerInputController();
    }

    private void BindPlayerInputController()
    {
        Container.Bind<IInputController>().FromInstance(_playerInputController).AsSingle();
    }
}
