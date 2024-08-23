using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkState : StateBase
{
    public WorkState(PlayerController controller, PlayerStateMachine stateMachine)
        : base(controller, stateMachine)
    {

    }

    private FacilityBase interactingFacility = null;

    public override void Enter()
    {
        base.Enter();

        interactingFacility = controller.RecentFacility;
        controller.FacInteractUI.gameObject.SetActive(false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // TODO : Hit timing;
        }

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
