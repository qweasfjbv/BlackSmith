
public class StateBase
{
    protected PlayerController controller;
    protected PlayerStateMachine stateMachine;

    public StateBase(PlayerController controller, PlayerStateMachine stateMachine)
    {
        this.controller = controller;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() {}
    public virtual void HandleInput() {}
    public virtual void LogicUpdate() {}
    public virtual void PhysicsUpdate() {}
    public virtual void Exit() {}
}
