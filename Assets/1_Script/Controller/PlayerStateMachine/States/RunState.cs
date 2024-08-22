using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : StateBase
{

    private float vertInput = 0f;
    private float horzInput = 0f;
    private float vertInputM = 0f;
    private float horzInputM = 0f;
    private float diagW = 1.0f;

    bool isIncreasing = true;

    public RunState(PlayerController controller, PlayerStateMachine stateMachine)
        : base(controller, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();

        vertInput = vertInputM = horzInput = horzInputM = 0f;
        diagW = 1.0f;
        isIncreasing = true;

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
        vertInputM = Input.GetAxis("Vertical");
        horzInputM = Input.GetAxis("Horizontal");

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


        float speed = Mathf.Abs(vertInput) + Mathf.Abs(horzInput);
        float speedM = Mathf.Abs(vertInputM) + Mathf.Abs(horzInputM);

        if (Mathf.Approximately(speed, 0f))
        {
            stateMachine.ChangeState(controller.idleState);
        }
        if (speedM > 1f) isIncreasing = false;

        if (isIncreasing)
        {
            vertInput = vertInputM; horzInput = horzInputM;
        }


        controller.animator.SetFloat(Constants.ANIM_PARAM_SPEED, speed);

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (Mathf.Abs(horzInput) > 0.5f || Mathf.Abs(vertInput) > 0.5f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(horzInput, 0, vertInput));

            controller.RotationSlerp(targetRotation);
        }

        diagW = (Mathf.Abs(horzInput) > 0.5f && Mathf.Abs(vertInput) > 0.5f) ? 0.71f : 1.0f;
        controller.Move(new Vector3(horzInput, 0, vertInput)* diagW);
    }

}
