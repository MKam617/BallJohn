using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private bool jump;
    private bool canJump;
    private int jumpQuantity;
    [SerializeField] private int maxJumpQuantity = 1;
    [SerializeField] private int speedOfMoving = 1;

    private void Start()
    {
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speedOfMoving);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            canJump = true;
            jumpQuantity += 1;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpQuantity = 0;
        }
    }
    
    private void FixedUpdate()
    {
        if (jump && canJump && jumpQuantity <= maxJumpQuantity)
        {
            _rigidbody.AddForce(Vector3.up * 300);
            jump = false;           
        } 
    }

}
