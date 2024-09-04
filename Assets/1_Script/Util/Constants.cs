using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{

    /// <summary>
    /// string of parameters used in player animators.
    /// </summary>
    
    // FOR BASIC MOVEMENT
    public const string ANIM_PARAM_SPEED = "speed";
    public const string ANIM_PARAM_ROLL = "isRoll";
    public const string ANIM_PARAM_RUN = "isRun";
    public const string ANIM_PARAM_WORKREADY = "isWorkReady";

    // FOR INTERACTING
    public const string ANIM_PARAM_MINE = "isMine";
    public const string ANIM_PARAM_CHOP = "isChop";
    public const string ANIM_PARAM_HAMMER = "isHammer";


    /// <summary>
    /// string of animation name of player animations
    /// </summary>
    
    // FOR BASIC MOVEMENT
    public const string ANIM_CLIPNAME_IDLE = "Idle";
    public const string ANIM_CLIPNAME_RUN = "RunForward";
    public const string ANIM_CLIPNAME_ROLL = "RollForward";
    public const string ANIM_CLIPNAME_WORKREADY = "WorkReady";

    // FOR INTERACTING
    public const string ANIM_CLIPNAME_MINE= "Mining";
    public const string ANIM_CLIPNAME_CHOP = "Chopping";


    /// <summary>
    /// Layers for Raycast
    /// </summary>
    public const int LAYER_FACILITY = 1 << 8;
    public const int LAYER_RESOURCE = 1 << 9;
}
