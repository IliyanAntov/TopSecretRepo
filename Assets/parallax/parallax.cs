using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour {
    public float distance;
    private Vector2 offset;
    private bool adjacent = false;

    void Start() {
        offset = new Vector2(transform.position.x, transform.position.y);
        if (!adjacent) {
            float width = GetComponent<Renderer>().bounds.size.x;
            Vector3 leftPos = new Vector3(offset.x - width + 0.01f, transform.position.y, transform.position.z);
            Vector3 rightPos = new Vector3(offset.x + width - 0.01f, transform.position.y, transform.position.z);
            Instantiate(this, leftPos, Quaternion.identity).adjacent = true;
            Instantiate(this, rightPos, Quaternion.identity).adjacent = true;
        }
    }

    void FixedUpdate() {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        float newX = offset.x - (playerPos.x / distance);
        float newY = offset.y - (playerPos.y / distance*2);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

}