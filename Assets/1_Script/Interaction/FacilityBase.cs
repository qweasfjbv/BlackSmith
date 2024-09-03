using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Field;

namespace Facility
{
    public abstract class FacilityBase : MonoBehaviour
    {

        protected WorkUI workUI;

        protected float maxTiming;          // Timing UI looks circle.
        protected float elapsedTiming;      // current pin location (modular needed)
        protected float timingSpeed;        // pin move speed;
        protected float correctTiming;      // 
        protected float correctTimingRange; // Doubled to right and left

        protected string animParam;
        public string AnimParam { get => animParam; }

        protected void SetFacilityAnimInfo(string animParam)
        {
            this.animParam = animParam;
        }

        protected void SetFacilityTimingInfo(WorkUI workUI, float timingSpeed = 1f, float correctTIming = 0.5f, float correctTImingRange = 5f)
        {
            this.workUI = workUI;
            this.maxTiming = 100f;
            this.elapsedTiming = 0f; // by default
            this.timingSpeed = timingSpeed;
            this.correctTiming = correctTIming; // half by default
            this.correctTimingRange = correctTImingRange;
        }

        public virtual void OnTimingButtonPressed()
        {

        }

        public abstract void ShowWorkUI();      // Show appropriate UI
        public abstract void SetFacilityUI();   // Set timing vars (maybe called in ShowWorkUI)
        public abstract void OnUpdate();        // Get Input during interacting (ex. space to timing)
        public abstract int ReturnItem(int itemId1, int itemId2);  // Return appropriate item with facilityId, itemId1, 2

    }

}