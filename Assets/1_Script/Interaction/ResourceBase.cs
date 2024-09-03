using UnityEngine;

namespace Resource
{
    public abstract class ResourceBase : MonoBehaviour
    {
        protected string animParam;
        protected string animName;
        protected float actionTime;
        protected float interactRotate = 0;

        public string AnimParam { get => animParam; }
        public string AnimName { get => animName; }
        public float ActionTime { get => actionTime; }
        public float InteractRotY { get => interactRotate; }

        protected void SetResourceInfo(string animParam, string animName, float actionTime, float interactRotate)
        {
            this.animParam = animParam;
            this.animName = animName;
            this.actionTime = actionTime;
            this.interactRotate = interactRotate;
        }

        public abstract void OnUpdate();
        public abstract int GetResource();

    }
}
