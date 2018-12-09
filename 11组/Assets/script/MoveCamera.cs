using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    float hor;
    float ver;

    float w;
    float a;
    public float roSpeed = 30f;
    public float speed = 5f;
    void Update()
    {
		//Debug.Log ("moveCamer!");
        hor = Input.GetAxis("Mouse X");
        ver = Input.GetAxis("Mouse Y");

        w = Input.GetAxis("Horizontal");
        a = Input.GetAxis("Vertical");
        Vector3 V = new Vector3(w,0,a);
        if (hor != 0 || ver != 0)
        {
            transform.Rotate(Vector3.up * hor * Time.deltaTime * roSpeed, Space.World);
            transform.Rotate(-Vector3.right * ver * Time.deltaTime * roSpeed);
        }

        if (w !=0 || a !=0)
        {
            transform.Translate( V * Time.deltaTime * speed);
        }
    }
}
