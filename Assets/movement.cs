using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
    public float speed;
    public float jumpForce;

    private bool grounded = true;
    private float xDir;
    private float xDirLock;
    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        xDir = Input.GetAxis("Horizontal");
        
        if (xDir != 0) {
            if (xDirLock == 0 || xDirLock != Mathf.Sign(xDir)) {
                transform.position += new Vector3(xDir * speed, 0, 0);
            }
        }
    }

    private void Update() {
        if (Input.GetKey("space") && grounded) {
            grounded = false;
            jump();
        }
    }

    private void jump() {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag) {
            case "Ground":
                grounded = true;
            break;
            case "Enemy":
                if (other.collider.GetType() == typeof(BoxCollider)) {
                    Debug.Log("umre");
                } else if (other.collider.GetType() == typeof(CapsuleCollider)) {
                    Destroy(other.gameObject);
                    jump();
                }
            return;
            case "Brick":
                if (other.collider.GetType() == typeof(BoxCollider)) {
                    grounded = true;
                } else if (other.collider.GetType() == typeof(CapsuleCollider)) {
                    other.gameObject.SendMessage("spawn");
                }
            break;
            case "Brick Hitbox":
                if (!grounded) {
                    xDirLock = Mathf.Sign(xDir);
                }
            break;
        }   
    }
    private void OnCollisionExit(Collision other) { 
        if (other.gameObject.tag == "Ground") {
            grounded = false;
        }

        if (other.gameObject.tag == "Brick Hitbox") {
            grounded = false;
            xDirLock = 0;
        }
    }
}
