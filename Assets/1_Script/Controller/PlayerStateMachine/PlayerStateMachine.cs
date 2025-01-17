using StateMachine.State;

namespace StateMachine
{
    public class PlayerStateMachine
    {
        private StateBase curState;
        public StateBase CurState { get { return curState; } }

        public void Init(StateBase startState)
        {
            curState = startState;
            startState.Enter();
        }

        public void ChangeState(StateBase newState)
        {
            curState.Exit();

            curState = newState;
            newState.Enter();
        }
    }

}