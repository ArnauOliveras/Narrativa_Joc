using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState
    {
        WithoutCar,
        WithCar
    }
    GameManeger GM;
    public PlayerState currentState;
    public Animator animator;
    public CharacterController characterController;
    public Camera cam;
    public Transform lookAt;

    public float jumpForce = 2.0f;
    float verticalSpeed = 0.0f;
    public float lerpRotation = 0.25f;
    public float walkSpeed = 3;
    public float runSpeed = 10;

    float coyoteTimeTimer;
    public float coyoteTime = 0.2f;
    bool onGround = true;

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManeger").GetComponent<GameManeger>();
    }

    void Update()
    {
        if (!GM.TM.isTalking)
        {
            Move();
        }

    }

    void Move()
    {

        Vector3 _forwardCamera = cam.transform.forward;
        Vector3 _rightCamera = cam.transform.right;

        _forwardCamera.y = 0.0f;
        _rightCamera.y = 0.0f;

        _forwardCamera.Normalize();
        _rightCamera.Normalize();

        float _movementSpeed = 0.0f;
        Vector3 _movement = Vector3.zero;
        bool _hasMovement = false;

        if (Input.GetKey(KeyCode.W)) { _hasMovement = true; _movement = _forwardCamera; _movementSpeed = walkSpeed; }
        if (Input.GetKey(KeyCode.S)) { _hasMovement = true; _movement = -_forwardCamera; _movementSpeed = walkSpeed; }
        if (Input.GetKey(KeyCode.A)) { _hasMovement = true; _movement -= _rightCamera; _movementSpeed = walkSpeed; }
        if (Input.GetKey(KeyCode.D)) { _hasMovement = true; _movement += _rightCamera; _movementSpeed = walkSpeed; }

        _movement.Normalize();
        if (_hasMovement)
        {
            Quaternion _lookRotation = Quaternion.LookRotation(_movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, _lookRotation, lerpRotation);

        }

        if (onGround) { coyoteTimeTimer = coyoteTime; }
        else { coyoteTimeTimer -= Time.deltaTime; }


        //if (Input.GetKeyDown(KeyCode.Space) && coyoteTimeTimer > 0)
        //{
        //    verticalSpeed = jumpForce;
        //    coyoteTimeTimer = 0;
        //}


#if UNITY_EDITOR

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _movementSpeed = runSpeed;
        }
#endif


        _movement = _movement * _movementSpeed * Time.deltaTime;

        verticalSpeed = verticalSpeed + Physics.gravity.y * Time.deltaTime;
        _movement.y = verticalSpeed * Time.deltaTime;


        CollisionFlags _CollisionFlags = characterController.Move(_movement);

        if ((_CollisionFlags & CollisionFlags.Below) != 0)
        {
            verticalSpeed = 0.0f;
            onGround = true;
        }
        else { onGround = false; }

        if (_movementSpeed > 0.0f)
        {
            if (_movementSpeed == walkSpeed)
            {
                animator.SetInteger("Move", 1);
                animator.SetInteger("arms", 1);
            }
            if (_movementSpeed == runSpeed)
            {
                animator.SetInteger("Move", 2);
                animator.SetInteger("arms", 2);
            }

        }
        else
        {
            animator.SetInteger("Move", 0);
            animator.SetInteger("arms", 3);
        }
    }
}
