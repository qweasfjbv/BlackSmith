using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Debug.Log("IDLE STATTE RUNNIGN" +vertInput);

        if (Mathf.Abs(vertInput) >= 0.9f ||Mathf.Abs(horzInput) >= 0.9f) stateMachine.ChangeState(controller.runState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
