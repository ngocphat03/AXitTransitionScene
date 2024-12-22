#if UNITASK
namespace AXitUnityTemplate.TransitionScene.Runtime.Scripts.Transition
{
    using System;
    using UnityEngine;
    using Cysharp.Threading.Tasks;
    using Object = UnityEngine.Object;
    using AXitUnityTemplate.AssetLoader.Runtime.Loader;
    using AXitUnityTemplate.AssetLoader.Runtime.Interface;
    using UnityEngine.ResourceManagement.ResourceProviders;
    using AXitUnityTemplate.TransitionScene.Runtime.Scripts.Animation;
    using AXitUnityTemplate.TransitionScene.Runtime.Scripts.Interface;

    public class AsyncTransitionScene : ITransitionScene
    {
        private readonly IAssetLoader        assetLoader;
        private readonly RootTransitionScene rootTransitionScene;

        public AsyncTransitionScene(IAssetLoader        assetLoader,
                                    RootTransitionScene rootTransitionScene)
        {
            this.assetLoader         = assetLoader;
            this.rootTransitionScene = rootTransitionScene;
        }

        private AsyncAnimationScene animationScene;
        private SceneInstance       targetScene;

        public async void OpenScene(string sceneName, bool withAnimation = true, bool loadByAddressable = false)
        {
            if (loadByAddressable)
            {
                // Load scene by addressable
                if (this.assetLoader is not AddressableAssetLoader addressableAssetLoader) throw new Exception("Cannot load scene by addressable");

#if UNITASK
                // Load scene and optionally play open animation
                var loadSceneTask = addressableAssetLoader.LoadSceneAsync(sceneName, false);
                await (this.animationScene?.PlayAnimationOpen() ?? UniTask.CompletedTask);

                // Wait for the scene to load and activate
                this.targetScene = await loadSceneTask;
                await this.targetScene.ActivateAsync();

                // Optionally play close animation
                await (this.animationScene?.PlayAnimationClose() ?? UniTask.CompletedTask);
                Object.Destroy(this.animationScene?.gameObject);
#endif
            }
            else
            {
                // Load scene by scene name
            }
        }

        public void OpenScene(int sceneBuildIndex, bool withAnimation = true, bool loadByAddressable = false) { throw new System.NotImplementedException(); }

        public void LoadSceneInBackground(string sceneName, bool loadByAddressable = false) { throw new System.NotImplementedException(); }

        public void LoadSceneInBackground(int sceneBuildIndex, bool loadByAddressable = false) { throw new System.NotImplementedException(); }

        public async void LoadAnimation<T>(string key, bool loadByAddressable = false) where T : AsyncAnimationScene
        {
#if UNITASK
            var animationGameObject = Object.Instantiate(await this.assetLoader.LoadAssetAsync<GameObject>(key).ToUniTask(), this.rootTransitionScene.GetRootTransform());
            if (animationGameObject.TryGetComponent<T>(out var asyncAnimationScene))
            {
                this.animationScene = asyncAnimationScene;
            }
            else
            {
                Debug.LogError($"GameObject loaded with key: {key} does not have component of type {typeof(T)}.");
            }
#endif
        }
    }
}
#endif