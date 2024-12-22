namespace AXitUnityTemplate.TransitionScene.Sample.Scripts
{
    using UnityEngine;
    using UnityEngine.Playables;
    using Cysharp.Threading.Tasks;
    using AXitUnityTemplate.TransitionScene.Runtime.Scripts.Animation;

    public class SampleAsyncAnimationScene : AsyncAnimationScene
    {
        public override UniTask PlayAnimationOpen() => this.PlayTimelineAsync(this.TimelineOpen);

        public override UniTask PlayAnimationClose() => this.PlayTimelineAsync(this.TimelineClose);

        private async UniTask PlayTimelineAsync(PlayableDirector director)
        {
            if (!director)
            {
                Debug.LogWarning("Animation transition scene is null");
                return;
            }

            director.Play();
            await UniTask.WaitUntil(() => director.state != PlayState.Playing);
        }
    }
}