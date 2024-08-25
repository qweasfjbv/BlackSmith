using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        controller.EraseAllAnimParam();
        controller.animator.SetBool(Constants.ANIM_PARAM_WORKREADY, true);

        facility = controller.RecentFacility;
        controller.FacInteractUI.gameObject.SetActive(false);
        controller.FacWorkUI.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();

        controller.FacWorkUI.gameObject.SetActive(false);
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
