#if ZENJECT
namespace AXitUnityTemplate.TransitionScene.Runtime.Scripts.Installer
{
    using Zenject;
    using UnityEngine;
    using AXitUnityTemplate.TransitionScene.Runtime.Scripts.Interface;
    using AXitUnityTemplate.TransitionScene.Runtime.Scripts.Utilities;
    using AXitUnityTemplate.TransitionScene.Runtime.Scripts.Transition;

    public class TransitionSceneInstaller : Installer<TransitionSceneInstaller>
    {
        public override void InstallBindings()
        {
            var transitionSceneSetting = Resources.Load<TransitionSceneSetting>("TransitionSceneSetting");

            if (!transitionSceneSetting) throw new System.Exception("TransitionSceneSetting is not found in Resources folder");
            this.Container.BindInstance(Object.Instantiate(transitionSceneSetting.RootTransitionScene)).AsSingle().NonLazy();
            
            this.Container.Bind<ITransitionScene>().To<AsyncTransitionScene>().AsSingle().NonLazy();
        }
    }
}
#endif