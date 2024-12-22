namespace AXitUnityTemplate.TransitionScene.Runtime.Scripts.Transition
{
    using UnityEngine;
    using Object = UnityEngine.Object;

    public class RootTransitionScene : MonoBehaviour
    {
        [SerializeField] private Transform rootTransform;
        private void Awake() { Object.DontDestroyOnLoad(this.gameObject); }

        public Transform GetRootTransform() => this.rootTransform;
    }
}