using UnityEngine;

namespace Facility
{
    public class Facility_Anvil : FacilityBase
    {

        private float actionCooltime = 1f;          // Related with Anim speed
        private bool isOnActionCooltime = false;

        private void Awake()
        {
            SetFacilityAnimInfo(Constants.ANIM_PARAM_HAMMER);
            SetFacilityTimingInfo();
        }


        public override void OnEnter()
        {
            isOnActionCooltime = false;
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

                if(Mathf.Abs(elapsedTiming-correctTimingRatio * maxTiming) < correctTimingRange)
                {
                    Debug.Log("OnTiming!");
                }
                else
                {
                    Debug.Log("NOTONTIMING!!");
                }
            }
        }

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

    }
}
