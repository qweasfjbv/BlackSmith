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
        protected float correctTimingRatio;      // 
        protected float correctTimingRange; // Doubled to right and left

        protected string animParam;
        public string AnimParam { get => animParam; }


        public abstract void ShowWorkUI();      // Show appropriate UI
        public abstract int ReturnItem(int itemId1, int itemId2);  // Return appropriate item with facilityId, itemId1, 2
        public abstract void OnEnter();
        public abstract void OnExit();
        public abstract void UpdateElapsedTiming();

        public void SetFacilityUI(WorkUI workUI)
        {
            this.workUI = workUI;

            workUI.SetTiming(maxTiming, correctTimingRatio, correctTimingRange);
        }
        protected void SetFacilityAnimInfo(string animParam)
        {
            this.animParam = animParam;
        }

        protected void SetFacilityTimingInfo(float timingSpeed = 100f, float correctTImingRatio = 0.5f, float correctTImingRange = 20f)
        {
            this.maxTiming = 100f;
            this.elapsedTiming = 0f; // by default
            this.timingSpeed = timingSpeed;
            this.correctTimingRatio = correctTImingRatio; // half(0.5f) by default
            this.correctTimingRange = correctTImingRange;
        }

        public virtual void OnTimingButtonPressed()
        {

        }

        public virtual void OnUpdate()          // Get Input during interacting (ex. space to timing)
        {
            UpdateElapsedTiming();
            workUI.SetPinPos(elapsedTiming / maxTiming);

        }

    }

}