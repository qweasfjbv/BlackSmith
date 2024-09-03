using UnityEngine;
using Controller;

namespace StateMachine.State
{
    public class IdleState : StateBase
    {

        private float vertInput = 0f;
        private float horzInput = 0f;

        public IdleState(PlayerController controller, PlayerStateMachine stateMachine)
            : base(controller, stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
            controller.GetComponent<Animator>().SetFloat(Constants.ANIM_PARAM_SPEED, 0);

            controller.animator.SetBool(Constants.ANIM_PARAM_ROLL, false);
            controller.animator.SetBool(Constants.ANIM_PARAM_RUN, false);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();

            vertInput = Input.GetAxisRaw("Vertical");
            horzInput = Input.GetAxisRaw("Horizontal");


            if (Input.GetKeyDown(KeyCode.F))
            {
                if (controller.IsDetectFacility) stateMachine.ChangeState(controller.workState);
                if (controller.IsDetectResource) stateMachine.ChangeState(controller.mineState);
            }

        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Debug.Log("STATE : IDLE");
            if (Mathf.Abs(vertInput) >= 0.9f || Mathf.Abs(horzInput) >= 0.9f) stateMachine.ChangeState(controller.runState);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            controller.GetRaycastFacility();
        }

    }
}