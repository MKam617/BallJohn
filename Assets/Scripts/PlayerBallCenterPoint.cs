using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallCenterPoint : MonoBehaviour
{
    [SerializeField] private Transform PlayerBall;


    private void Update()
    {
        this.gameObject.transform.position = PlayerBall.position;
    }
}
