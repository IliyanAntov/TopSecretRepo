using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour {
    public float distance;
    bool central = false;
    float offset;
    void Start() {
        offset = transform.position.x;
    }

    void FixedUpdate() {
        Vector3 pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = new Vector3(offset + (-pos.x / distance), transform.position.y, transform.position.z);
    }

    public void setCentral() {
        central = true;
    }

    public void printCentral() {
        Debug.Log(central);
    }
}
