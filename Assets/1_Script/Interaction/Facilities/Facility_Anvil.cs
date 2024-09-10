using UnityEngine;

namespace Facility
{
    public class Facility_Anvil : FacilityBase
    {


        private float actionCooltime = 1f;          // Related with Anim speed
        private bool isOnActionCooltime = false;

        private void Awake()
        {
            SetAllInfoByFacID(-1); // TODO : GET ID FROM RESOURCE MANAGER
        }


        public override void OnEnter()
        {
            base.OnEnter();
            isOnActionCooltime = false;
            workUI.SetProgressBar(0f);
        }

        public override void OnExit()
        {

        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isOnActionCooltime) return;

                isOnActionCooltime = true;
                Invoke(nameof(ReleaseCooltime), actionCooltime);

                if(Mathf.Abs(elapsedTiming-correctTimingRatio * maxTiming) < correctTimingRange/2)
                {
                    AddProgress();
                }
                else
                {
                    Debug.Log("NOTONTIMING!!");
                }
            }
        }

        // TOOD : Preliminaries - ResourceManager, Inventory
        // Take an item out of the inventory, combine it
        // and then place the new item back in the inventory.
        public override int ReturnItem(int itemId1, int itemId2)
        {
            return -1;
        }


        public override void ShowWorkUI()
        {

        }


        bool isIncreasing = false;
        public override void UpdateElapsedTiming()
        {
            if (elapsedTiming < 0) isIncreasing = true;
            if (elapsedTiming > maxTiming) isIncreasing = false;

            elapsedTiming += timingSpeed * Time.deltaTime * (isIncreasing ? 1 : -1);
        }

        private void ReleaseCooltime()
        {
            isOnActionCooltime = false;
        }

        private void AddProgress(float weight = 1f)
        {
            elapsedProgress += progressPerAction * weight;
            workUI.SetProgressBar(elapsedProgress / maxProgress);

            if (elapsedProgress + Mathf.Epsilon > maxProgress)
            {
                OnWorkComplete.Invoke();
            }
        }

    }
}
