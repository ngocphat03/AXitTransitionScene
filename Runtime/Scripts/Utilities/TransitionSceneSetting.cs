namespace AXitUnityTemplate.TransitionScene.Runtime.Scripts.Utilities
{
    using UnityEngine;
    using AXitUnityTemplate.TransitionScene.Runtime.Scripts.Transition;

    [CreateAssetMenu(fileName = "TransitionSceneSetting", menuName = "AXit/TransitionScene/TransitionSceneSetting")]
    public class TransitionSceneSetting : ScriptableObject
    {
        [field: SerializeField] public RootTransitionScene RootTransitionScene { get; private set; }
    }
}