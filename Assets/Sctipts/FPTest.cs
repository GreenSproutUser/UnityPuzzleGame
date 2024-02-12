using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.FilePathAttribute;

public class FPTest : MonoBehaviour
{
    private Vector2 moveInput;
    bool running;
    [SerializeField] Transform orientation;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jump();
    }

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        move = orientation.forward * move.z + orientation.right * move.x; 
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        /* running if we want
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            
        }
        */  
    }
    private void jump()
    {
        if (groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
    }
 


}

