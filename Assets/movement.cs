using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
    public float speed;
	void FixedUpdate () {
        float xDir = Input.GetAxis("Horizontal");
        transform.position += new Vector3(xDir*speed, 0, 0);
	}
}
