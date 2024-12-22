namespace AXitUnityTemplate.TransitionScene.Runtime.Scripts.Interface
{
    public interface IAsyncAnimation
    {
        public bool IsCompleted { get; }

#if UNITASK
        public Cysharp.Threading.Tasks.UniTask ToUniTask();
#else
        public System.Collections.IEnumerator ToCoroutine(System.Action onComplete = null)
        {
            return IAsyncAnimation.ToCoroutineInternal(this, onComplete);
        }

        private static System.Collections.IEnumerator ToCoroutineInternal(IAsyncAnimation asyncResult, System.Action onComplete = null)
        {
            while (!asyncResult.IsCompleted)
            {
                yield return null;
            }

            onComplete?.Invoke();
        }
#endif
    }
}