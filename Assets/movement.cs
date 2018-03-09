using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
    public float speed;
    public float jumpForce;

    private bool grounded = true;
    private bool jumping = false;

    private void FixedUpdate() {
        float xDir = Input.GetAxis("Horizontal");
        transform.position += new Vector3(xDir * speed, 0, 0);
        if (jumping) {
            transform.position += new Vector3(0, jumpForce, 0);
        }
    }

    private void Update() {
        if (Input.GetKey("space") && grounded) {
            grounded = false;
            jumping = true;
        }
    }

    private void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag) {
            case "Ground":
                grounded = true;
                jumping = false;
            break;
            case "Enemy":
                if (other.collider.GetType() == typeof(BoxCollider)) {
                    Debug.Log("umre");
                } else if (other.collider.GetType() == typeof(CapsuleCollider)) {
                    Destroy(other.gameObject);
                }
            break;
            case "Brick":
                if (other.collider.GetType() == typeof(BoxCollider)) {
                    grounded = true;
                    jumping = false;
                } else if (other.collider.GetType() == typeof(CapsuleCollider)) {
                    other.gameObject.SendMessage("spawn");
                }
            break;

        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Brick") {
            grounded = false;
        }
    }
}
