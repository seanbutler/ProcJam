using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoving : MonoBehaviour
{    public float speed=15.0f;

    void Start()
    {
        transform.position=new Vector3(0,0,0);
    }

    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal")*Vector3.right*speed*Time.deltaTime);
        transform.Translate(Input.GetAxis("Vertical")*Vector3.forward*speed*Time.deltaTime);
        // transform.Translate(Input.GetAxis("Vertical")*Vector3.up*speed*Time.deltaTime);
    }
}
