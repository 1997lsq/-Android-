using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fan : MonoBehaviour {

	int speed=20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(Vector3.back*speed);
	}
}
