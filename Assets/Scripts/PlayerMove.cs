using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController charController;
    private CharacterAnimations playerAnimations;
 

    public float movement_speed = 3f;
    public float gravity = 9.8f;
    public float rotationSpeed = 0.15f;
    public float rotateDegreesPerSecond = 180f;

    void Awake()
    {
        charController = GetComponent<CharacterController>();
        playerAnimations = GetComponent<CharacterAnimations>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }
    void Move()
    {
        print("the value is " + Input.GetAxis((Axis.VERTICAL_AXIS)));

        if (Input.GetAxis(Axis.VERTICAL_AXIS) > 0)
        {
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;
            charController.Move(moveDirection * movement_speed * Time.deltaTime);
        }
        else if (Input.GetAxis(Axis.VERTICAL_AXIS)<0)
        {
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;
            charController.Move(moveDirection * movement_speed * Time.deltaTime);

        }

    }
    void Rotate()
    {
        Vector3 rotation_Direction = Vector3.zero;
        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0)
        {
            rotation_Direction = transform.TransformDirection(Vector3.left);
        }
        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0)
        {
            rotation_Direction = transform.TransformDirection(Vector3.right);
        }
        if (rotation_Direction!= Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, Quaternion.LookRotation(rotation_Direction),
                rotateDegreesPerSecond * Time.deltaTime);
        }
    }

}
