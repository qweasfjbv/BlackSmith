using UnityEngine;
using UI.Field;
using System;

namespace Facility
{
    public abstract class FacilityBase : MonoBehaviour
    {

        protected WorkUI workUI;

        /** Timing Variables **/
        protected float maxTiming;          // Timing UI looks circle.
        protected float elapsedTiming;      // current pin location
        protected float timingSpeed;        // pin move speed;
        protected float correctTimingRatio;      // 
        protected float correctTimingRange; // Doubled to right and left

        /** Progress Variables **/
        protected float maxProgress;
        protected float elapsedProgress;
        protected float progressPerAction;

        protected string animParam;
        public string AnimParam { get => animParam; }
        public Action OnWorkComplete;


        /** ABSTRACT FUNCTIONS **/
        public abstract void ShowWorkUI();      // Show appropriate UI
        public abstract int ReturnItem(int itemId1, int itemId2);  // Return appropriate item with facilityId, itemId1, 2
        public abstract void UpdateElapsedTiming();


        #region VIRTUAL FUNCTIONS
        public virtual void OnUpdate()          // Get Input during interacting (ex. space to timing)
        {
            UpdateElapsedTiming();
            workUI.SetPinPos(elapsedTiming / maxTiming);

        }
        public virtual void OnEnter()
        {
            elapsedProgress = 0f;
            elapsedTiming = 0f;
            OnWorkComplete = null;
        }
        public virtual void OnExit()
        {

        }
        #endregion


        #region INIT FUNCTIONS
        public void SetFacilityInfo(WorkUI workUI)  // Called in WorkState Class
        {
            this.workUI = workUI;

            workUI.SetTiming(maxTiming, correctTimingRatio, correctTimingRange);
        }
        protected void SetAllInfoByFacID(int facId)
        {
            // TODO : GetInfo From ResourceManager and give values;
            FacilityInfo facInfo = Managers.Resource.GetFacilityInfo(facId);

            SetFacilityProgressInfo();
            SetFacilityTimingInfo();
            SetFacilityAnimInfo(Constants.ANIM_PARAM_HAMMER);

        }
        protected void SetFacilityProgressInfo(float progressPerAction = 20f)
        {
            this.maxProgress = 100f;
            this.progressPerAction = progressPerAction;
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
        #endregion

    }

}