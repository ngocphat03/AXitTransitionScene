namespace AXitUnityTemplate.TransitionScene.Runtime.Scripts.Animation
{
    using UnityEngine;
    using UnityEngine.Playables;
    using Cysharp.Threading.Tasks;

    public abstract class AsyncAnimationScene : MonoBehaviour
    {
        [field: SerializeField] public PlayableDirector TimelineOpen  { get; private set; }
        [field: SerializeField] public PlayableDirector TimelineClose { get; private set; }

        public abstract UniTask PlayAnimationOpen();

        public abstract UniTask PlayAnimationClose();
    }
}