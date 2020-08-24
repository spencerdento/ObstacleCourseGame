using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // References
    public Rigidbody body;
    public InputAction jumpAction;

    // Config
    public float jumpVelocity;

    // State
    private bool grounded;

    void OnEnable() {
        jumpAction.Enable();
    }

    public void Start() {
        jumpVelocity = 4;
        jumpAction.performed += _ => OnJumpAction();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "tag_ground") {
            grounded = true;
        }
    }
    
    void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "tag_ground") {
            grounded = false;
        }
    }

    void OnJumpAction() {
        if (!grounded) return;
        Jump(1f);
    }

    public void Jump(float strength) {
        body.velocity = new Vector3(body.velocity.x, strength * jumpVelocity, body.velocity.z);
    }

    

}
