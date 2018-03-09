using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour {
    public GameObject item;
    private bool spawned = false;

    public void spawn() {
        if (item != null && !spawned) {
            float height = item.GetComponent<Renderer>().bounds.size.y;
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
            Instantiate(item, pos, Quaternion.identity);
            spawned = true;
        }
    }
}
