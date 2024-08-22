using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rigid;

    [Header("Player Move Args")]
    [SerializeField] private float moveSpeed;       // meter per sec
    [SerializeField] private float rotationSpeed;

    [Header("Raycast Args")]
    [SerializeField] private float rayStartHeight;
    [SerializeField] private float rayLength;


    private PlayerStateMachine stateMachine;
    public WorkState workState;
    public IdleState idleState;
    public RunState runState;
    public RollState rollState;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();

        stateMachine = new PlayerStateMachine();

        workState = new WorkState(this, stateMachine);
        idleState = new IdleState(this, stateMachine);
        runState = new RunState(this, stateMachine);
        rollState = new RollState(this, stateMachine);

        stateMachine.Init(idleState);

    }

    private void Update()
    {
        stateMachine.CurState.HandleInput();

        stateMachine.CurState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.CurState.PhysicsUpdate();
    }




    public void Move(Vector3 direction)
    {
       rigid.MovePosition(transform.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    public void RotationSlerp(Quaternion targetRotation)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }


    public void GetRaycastFacility()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + new Vector3(0, rayStartHeight, 0), transform.TransformDirection(Vector3.forward), out hit, rayLength, Constants.LAYER_FACILITY))
        {
            if (Input.GetKeyDown(KeyCode.F)) Debug.Log(hit.transform.name);
        }
        Debug.DrawRay(transform.position + new Vector3(0, rayStartHeight, 0), transform.TransformDirection(Vector3.forward) * rayLength, Color.red);
    }

}
