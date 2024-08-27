using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MineState : StateBase
{
    public MineState(PlayerController controller, PlayerStateMachine stateMachine) 
        : base(controller, stateMachine)
    {
    }

    private ResourceBase resource = null;

    private float animLoopCount = 0f;

    public override void Enter()
    {
        base.Enter();
        resource = controller.RecentResource;
        
        controller.EraseAllAnimParam();
        controller.animator.SetBool(Constants.ANIM_PARAM_WORKREADY, true);
        controller.animator.SetBool(resource.AnimParam, true);
        animLoopCount = 0;

        controller.transform.LookAt(resource.transform);
        controller.SetRotation(new Vector3(0,  controller.transform.eulerAngles.y + resource.InteractRotY, 0));
        controller.FacInteractUI.gameObject.SetActive(false);
    }

    public override void Exit() 
    { 
        base.Exit();

        controller.animator.SetBool(resource.AnimParam, false);
        controller.animator.SetBool(Constants.ANIM_PARAM_WORKREADY, false);
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (resource != null) resource.OnUpdate();
        else stateMachine.ChangeState(controller.idleState);

        if (Input.GetKeyDown(KeyCode.Escape))    // Escape Mine state 
        {
            stateMachine.ChangeState(controller.idleState);
        }

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


        if (controller.animator.GetCurrentAnimatorStateInfo(0).IsName(resource.AnimName))
        {
            float elapsedTime = controller.animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            if (elapsedTime% 1 > resource.ActionTime && animLoopCount < elapsedTime)
            {
                animLoopCount += 1.0f;
                resource.GetResource();
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
