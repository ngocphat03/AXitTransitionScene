#if !UNITASK

namespace AXitUnityTemplate.TransitionScene.Runtime.Scripts.Transition
{
    using UnityEngine;
    using AXitUnityTemplate.AssetLoader.Runtime.Interface;
    using AXitUnityTemplate.AssetLoader.Runtime.Utilities;
    using AXitUnityTemplate.TransitionScene.Runtime.Scripts.Animation;
    using AXitUnityTemplate.TransitionScene.Runtime.Scripts.Interface;
    using UnityEngine.SceneManagement;

    public class TransitionScene : MonoBehaviour, ITransitionScene
    {
        private (IAnimationScene animationOpen, IAnimationScene animationClose) animationsScene;

        private IAssetLoader assetLoader;

        public void OpenScene(string sceneName, bool withAnimation = true, bool loadByAddressable = false) { }

        public void OpenScene(int sceneBuildIndex, bool withAnimation = true, bool loadByAddressable = false) { throw new System.NotImplementedException(); }

        public void LoadSceneInBackground(string sceneName, bool loadByAddressable = false) { throw new System.NotImplementedException(); }

        public void LoadSceneInBackground(int sceneBuildIndex, bool loadByAddressable = false) { throw new System.NotImplementedException(); }

        public void LoadAnimationOpen(string key, bool loadByAddressable = false) { }

        public void LoadAnimationClose(string key, bool loadByAddressable = false) { throw new System.NotImplementedException(); }

        // ReSharper disable once RedundantAssignment
        private void LoadAnimation(string key, ref IAnimationScene animationScene)
        {
#if ADDRESSABLES_ASSET_LOADED
            
#else // Load by resources

            var asyncResult = this.assetLoader.LoadAssetAsync<EnumeratorAnimationScene>(key: key);
            this.StartCoroutine(asyncResult.ToCoroutine(onComplete: result =>
            {
                if (result) return;
                Debug.LogError($"Animation not found!!! Key: {key}");
            }));
            animationScene = asyncResult.GetResult();
#endif
        }
    }
}
#endif