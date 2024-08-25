using UnityEngine;

public abstract class ResourceBase : MonoBehaviour
{
    protected string animParam;
    public string AnimParam { get => animParam; }

    protected float actionTime;
    public float ActionTime { get => actionTime; }

    public abstract void OnUpdate();
    public abstract int GetResource();

}
