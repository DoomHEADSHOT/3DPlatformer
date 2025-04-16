using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.Rendering;

public class MovementScript : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float JumpForce;
    public Transform cameraTransform;

    public float ySpeed;
    public Animator animator;

    public CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput ,0,verticalInput );
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y,Vector3.up) * movementDirection;
        movementDirection.Normalize();
        Vector3 velocity = movementDirection;
        velocity.y = ySpeed;
        ySpeed += Physics.gravity.y * Time.deltaTime;
        //transform.Translate(movementDirection*Time.deltaTime * speed,Space.World);
        characterController.Move(velocity * speed * Time.deltaTime);

        if(movementDirection != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
            //transform.forward = movementDirection;
            Quaternion toRotation = Quaternion.LookRotation(movementDirection,Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        } else
        {
            animator.SetBool("isMoving",false);
        }

        if (characterController.isGrounded) {
            ySpeed = -0.5f;
           if (Input.GetButtonDown("Jump"))
           {
           ySpeed = JumpForce;
                }
        }

     
 

    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus) { 
            Cursor.lockState = CursorLockMode.Locked;
        } else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
