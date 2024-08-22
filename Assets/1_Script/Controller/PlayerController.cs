using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigid;

    [Header("Player Move Args")]
    [SerializeField] private float moveSpeed;       // meter per sec
    [SerializeField] private float rotationSpeed;

    [Header("Raycast Args")]
    [SerializeField] private float rayStartHeight;
    [SerializeField] private float rayLength;

    [Header("DEBUG : Input Values")]
    [SerializeField] private float vertInput = 0f;
    [SerializeField] private float horzInput = 0f;
    [SerializeField] private float vertInputM = 0f;
    [SerializeField] private float horzInputM = 0f;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetAxisInput();

        GetRaycastFacility();

    }

    bool isIncreasing = false;

    private void GetAxisInput()
    {
        vertInput = Input.GetAxisRaw("Vertical");
        horzInput = Input.GetAxisRaw("Horizontal");
        vertInputM = Input.GetAxis("Vertical");
        horzInputM = Input.GetAxis("Horizontal");


        float speed = Mathf.Abs(vertInput) + Mathf.Abs(horzInput);
        float speedM = Mathf.Abs(vertInputM) + Mathf.Abs(horzInputM);

        if (Mathf.Approximately(speed, 0f)) isIncreasing = true;
        if (speedM > 1f) isIncreasing = false;

        if (isIncreasing)
        {
            vertInput = vertInputM; horzInput = horzInputM;
        }
       

        animator.SetFloat(Constants.ANIM_PARAM_SPEED, speed);

        float diagW = (Mathf.Abs(horzInput) > 0.5f && Mathf.Abs(vertInput) > 0.5f) ? 0.71f : 1.0f;

        if(Mathf.Abs(horzInput) > 0.5f || Mathf.Abs(vertInput) > 0.5f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(horzInput, 0, vertInput));

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        

        rigid.MovePosition(transform.position + new Vector3(horzInput, 0, vertInput) * moveSpeed * Time.deltaTime * diagW);
    }


    private void GetRaycastFacility()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + new Vector3(0, rayStartHeight, 0), transform.TransformDirection(Vector3.forward), out hit, rayLength, Constants.LAYER_FACILITY))
        {
            if (Input.GetKeyDown(KeyCode.F)) Debug.Log(hit.transform.name);
        }
        Debug.DrawRay(transform.position + new Vector3(0, rayStartHeight, 0), transform.TransformDirection(Vector3.forward) * rayLength, Color.red);
    }

}
