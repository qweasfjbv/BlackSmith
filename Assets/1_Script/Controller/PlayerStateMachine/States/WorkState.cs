using UnityEngine;
using Controller;
using Facility;

namespace StateMachine.State
{
    public class WorkState : StateBase
    {
        public WorkState(PlayerController controller, PlayerStateMachine stateMachine)
            : base(controller, stateMachine)
        {

        }

        private FacilityBase facility = null;

        public override void Enter()
        {
            base.Enter();
            facility = controller.RecentFacility;
            facility.SetFacilityUI(controller.FacWorkUI);
            facility.OnEnter();

            controller.EraseAllAnimParam();
            controller.animator.SetBool(Constants.ANIM_PARAM_WORKREADY, true);
            controller.animator.SetBool(facility.AnimParam, true);

            controller.transform.LookAt(facility.transform);
            controller.FacInteractUI.gameObject.SetActive(false);
            controller.FacWorkUI.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            base.Exit();


            facility.OnExit();

            controller.FacWorkUI.gameObject.SetActive(false);
            controller.animator.SetBool(facility.AnimParam, false);
            controller.animator.SetBool(Constants.ANIM_PARAM_WORKREADY, false);
        }

        public override void HandleInput()
        {
            base.HandleInput();

            Debug.Log(facility.name);

            if (facility != null) facility.OnUpdate();
            else stateMachine.ChangeState(controller.idleState);

            if (Input.GetKeyDown(KeyCode.Escape))    // Escape Work state 
            {
                stateMachine.ChangeState(controller.idleState);
            }

        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

    }

}