using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallCenterPoint : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [HideInInspector] public float sin;
    [HideInInspector] public float cos;

    private void Update()
    {
        this.gameObject.transform.position = Player.position;

        this.gameObject.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);

        sin = Mathf.Sin((this.gameObject.transform.rotation.eulerAngles.y * Mathf.PI) / 180);
        cos = Mathf.Cos((this.gameObject.transform.rotation.eulerAngles.y * Mathf.PI) / 180);
    }
}
