using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private bool jump;
    private bool canJump;
    private int jumpQuantity;
    [SerializeField] private int speedOfMoving = 1;
    [SerializeField] private int maxJumpQuantity = 1;
    [SerializeField] private int jumpingForce = 300;

    [SerializeField] private PlayerBallCenterPoint playerBallCenterPoint;

    private void Start()
    {
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddForce(new Vector3(1 * playerBallCenterPoint.sin,0,1 * playerBallCenterPoint.cos) * speedOfMoving);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.AddForce(new Vector3(-1 * playerBallCenterPoint.sin,0,-1 * playerBallCenterPoint.cos) * speedOfMoving);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(new Vector3(1 * playerBallCenterPoint.cos,0,1 * playerBallCenterPoint.sin) * speedOfMoving);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddForce(new Vector3(-1 * playerBallCenterPoint.cos,0,-1 * playerBallCenterPoint.sin) * speedOfMoving);
        }



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
            _rigidbody.AddForce(Vector3.up * jumpingForce);
            jump = false;           
        } 
    }

}
