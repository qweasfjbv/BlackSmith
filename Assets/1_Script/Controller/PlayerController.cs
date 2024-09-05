using UnityEngine;

using UI.Field;
using StateMachine;
using StateMachine.State;
using Facility;
using Resource;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {
        public Animator animator;
        public Rigidbody rigid;

        [Header("Player Move Args")]
        [SerializeField] private float moveSpeed;       // meter per sec
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float rollSpeed;
        [SerializeField] private float rollDuration;

        [Header("Raycast Args")]
        [SerializeField] private float rayStartHeight;
        [SerializeField] private float rayLength;
        [SerializeField] private FacilityInteractUI facInteractUI;
        [SerializeField] private WorkUI facWorkUI;


        public float RollDuration { get => rollDuration; }
        public FacilityInteractUI FacInteractUI { get => facInteractUI; }
        public WorkUI FacWorkUI { get => facWorkUI; }


        private PlayerStateMachine stateMachine;
        public WorkState workState;
        public IdleState idleState;
        public RunState runState;
        public RollState rollState;
        public MineState mineState;

        private bool isDetectFacility = false;
        public bool IsDetectFacility { get => isDetectFacility; }

        private bool isDetectResource = false;
        public bool IsDetectResource { get => isDetectResource; }


        /// <summary>
        /// recently detected facility by raycast
        /// used in state scripts to set popup UI
        /// </summary>
        private FacilityBase recentFacility = null;
        public FacilityBase RecentFacility { get => recentFacility; }
        private ResourceBase recentResource = null;
        public ResourceBase RecentResource { get => recentResource; }


        private void Start()
        {
            animator = GetComponent<Animator>();
            rigid = GetComponent<Rigidbody>();

            stateMachine = new PlayerStateMachine();

            workState = new WorkState(this, stateMachine);
            idleState = new IdleState(this, stateMachine);
            runState = new RunState(this, stateMachine);
            rollState = new RollState(this, stateMachine);
            mineState = new MineState(this, stateMachine);

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
        public void Roll(Vector3 direction)
        {
            rigid.MovePosition(transform.position + direction * rollSpeed * Time.fixedDeltaTime);
        }

        public void RotationSlerp(Quaternion targetRotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        public void SetRotation(Vector3 vector3)
        {
            transform.rotation = Quaternion.Euler(vector3);
        }

        public void GetRaycastFacility()
        {
            RaycastHit hit;

            int targetLayer = Constants.LAYER_FACILITY | Constants.LAYER_RESOURCE;

            if (Physics.Raycast(transform.position + new Vector3(0, rayStartHeight, 0), transform.TransformDirection(Vector3.forward), out hit, rayLength, targetLayer))
            {

                facInteractUI.gameObject.SetActive(true);

                switch (1 << hit.transform.gameObject.layer)
                {
                    case Constants.LAYER_FACILITY:
                        recentFacility = hit.transform.GetComponent<FacilityBase>();
                        recentResource = null;
                        isDetectFacility = true;
                        isDetectResource = false;
                        break;
                    case Constants.LAYER_RESOURCE:
                        recentFacility = null;
                        recentResource = hit.transform.GetComponent<ResourceBase>();
                        isDetectResource = true;
                        isDetectFacility = false;
                        break;
                }

            }
            else
            {
                if (facInteractUI.gameObject.activeSelf) facInteractUI.gameObject.SetActive(false);
                isDetectFacility = false;
                isDetectResource = false;
            }

            Debug.DrawRay(transform.position + new Vector3(0, rayStartHeight, 0), transform.TransformDirection(Vector3.forward) * rayLength, Color.red);
        }

        // Switch Any state to IDLE (Animation, NOT StateMachine)
        public void EraseAllAnimParam()
        {
            animator.SetBool(Constants.ANIM_PARAM_RUN, false);
            animator.SetBool(Constants.ANIM_PARAM_ROLL, false);
        }

    }

}