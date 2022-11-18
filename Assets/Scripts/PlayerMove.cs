using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform BallCenterPoint;
    private Rigidbody _rigidbody;
    private bool jump;
    private bool canJump;

    private void Start()
    {
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }


    private void OnCollisionEnter(Collision some)
    {
        if (some.gameObject.tag == "Ground")
        {  
            canJump = true;
        }
    }


 
    private void FixedUpdate()
    {
        if (canJump && jump)
        {
            _rigidbody.AddForce(Vector3.up * 300);
            canJump = false;
            jump = false;
        }
    }

}
