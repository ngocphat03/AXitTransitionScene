namespace AXitUnityTemplate.TransitionScene.Runtime.Scripts.Interface
{
    using AXitUnityTemplate.TransitionScene.Runtime.Scripts.Animation;

    public interface ITransitionScene
    {
        public void OpenScene(string sceneName, bool withAnimation = true, bool loadByAddressable = false);

        public void OpenScene(int sceneBuildIndex, bool withAnimation = true, bool loadByAddressable = false);

        public void LoadSceneInBackground(string sceneName, bool loadByAddressable = false);

        public void LoadSceneInBackground(int sceneBuildIndex, bool loadByAddressable = false);

        public void LoadAnimation<T>(string key, bool loadByAddressable = false) where T : AsyncAnimationScene;
    }
}