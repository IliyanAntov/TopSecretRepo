using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
    public float speed;
    public float distance;

    private float current = 0f;

    private void FixedUpdate() {
        if (speed > 0) {
            if (current + speed <= distance) {
                transform.position += new Vector3(speed, 0, 0);
                current += speed;
            } else {
                speed *= -1;
            }
        } else {
            if (current + speed >= 0) {
                transform.position += new Vector3(speed, 0, 0);
                current += speed;
            } else {
                speed *= -1;
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        speed *= -1;  

        //if (other.gameObject.tag == "gorniq hitboks na mario") {
        //    game over
        //}
    }
}
