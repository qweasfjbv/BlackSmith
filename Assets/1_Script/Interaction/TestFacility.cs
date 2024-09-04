using UnityEngine;

namespace Facility
{
    public class TestFacility : FacilityBase
    {
        public override void OnEnter()
        {
            throw new System.NotImplementedException();
        }

        public override void OnExit()
        {
            throw new System.NotImplementedException();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("TIMING BUTTON PRESSED!");
            }
        }

        public override int ReturnItem(int itemId1, int itemId2)
        {
            throw new System.NotImplementedException();
        }


        public override void ShowWorkUI()
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateElapsedTiming()
        {
            throw new System.NotImplementedException();
        }
    }

}