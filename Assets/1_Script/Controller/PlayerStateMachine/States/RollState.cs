using UnityEngine;
using Controller;

namespace StateMachine.State
{

    public class RollState : StateBase
    {
        private AnimationClip rollClip;
        private float elapsedTime = 0f;

        public RollState(PlayerController controller, PlayerStateMachine stateMachine)
            : base(controller, stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();

            elapsedTime = 0f;

            ExecuteRollAnim();

        }

        public override void Exit()
        {
            base.Exit();

            controller.animator.SetBool(Constants.ANIM_PARAM_ROLL, false);
            controller.animator.speed = 1.0f;
        }

        public override void HandleInput()
        {
            base.HandleInput();

            // No Input available during rolling
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Debug.Log("STATE : ROLL");
            elapsedTime += Time.deltaTime;

            if (elapsedTime > controller.RollDuration * 0.7) stateMachine.ChangeState(controller.idleState);

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            controller.Roll(new Vector3(Mathf.Cos((90 - controller.transform.rotation.eulerAngles.y) * Mathf.Deg2Rad), 0, Mathf.Sin((90 - controller.transform.rotation.eulerAngles.y) * Mathf.Deg2Rad)));
        }

        private void ExecuteRollAnim()
        {

            AnimationClip[] clips = controller.animator.runtimeAnimatorController.animationClips;

            foreach (AnimationClip clip in clips)
            {
                if (clip.name.Equals(Constants.ANIM_CLIPNAME_ROLL))
                {
                    rollClip = clip;
                    break;
                }
            }


            controller.animator.speed = rollClip.length / controller.RollDuration;
            controller.animator.SetBool(Constants.ANIM_PARAM_ROLL, true);
        }

    }

}