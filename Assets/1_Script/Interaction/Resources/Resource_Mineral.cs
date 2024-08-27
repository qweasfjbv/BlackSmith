using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Mineral : ResourceBase
{
    private void Awake()
    {
        SetResourceInfo(Constants.ANIM_PARAM_MINE, Constants.ANIM_CLIPNAME_MINE, 0.45f, 0f);
    }

    public override int GetResource()
    {

        // TODO : PLAY SOUND
        Debug.Log("GGANG!");
        return -1;
    }

    public override void OnUpdate()
    {

    }
}
