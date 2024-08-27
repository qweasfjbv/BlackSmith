using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FacilityBase : MonoBehaviour
{

    protected float maxTiming;          // Timing UI looks circle.
    protected float elaspedTiming;      // current pin location (modular needed)
    protected float timingSpeed;        // pin move speed;
    protected float correctTiming;      // 
    protected float correctTimingRange;

    public abstract void ShowWorkUI();      // Show appropriate UI
    public abstract void SetFacilityUI();   // Set timing vars (maybe called in ShowWorkUI)
    public abstract void OnUpdate();        // Get Input during interacting (ex. space to timing)
    public abstract int ReturnItem(int itemId1, int itemId2);  // Return appropriate item with facilityId, itemId1, 2

}
