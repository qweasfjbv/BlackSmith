using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Mineral : ResourceBase
{
    private void Awake()
    {
        animParam = Constants.ANIM_PARAM_MINE;
        actionTime = 0.45f;
    }

    public override int GetResource()
    {

        // TODO : PLAY SOUND
        Debug.Log("±ø!");
        return -1;
    }

    public override void OnUpdate()
    {

    }
}
