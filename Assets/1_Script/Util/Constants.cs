using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{

    /// <summary>
    /// string of parameters used in player animators.
    /// </summary>
    public const string ANIM_PARAM_SPEED = "speed";
    public const string ANIM_PARAM_ROLL = "isRoll";
    public const string ANIM_PARAM_RUN = "isRun";
    public const string ANIM_PARAM_WORKREADY = "isWorkReady";

    public const string ANIM_PARAM_MINE = "isMine";


    /// <summary>
    /// string of animation name of player animations
    /// </summary>
    public const string ANIM_CLIPNAME_ROLL = "RollForward";
    public const string ANIM_CLIPNAME_MINE= "MiningLoop";


    /// <summary>
    /// Layers for Raycast
    /// </summary>
    public const int LAYER_FACILITY = 1 << 8;
    public const int LAYER_RESOURCE = 1 << 9;
}
