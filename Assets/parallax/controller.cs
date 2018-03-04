using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {
    public parallax[] layers;
    parallax[][] currentScene;
    void Start() {
        createScene(layers);
    }

    void createScene(parallax[] layers) {
        for (int i = 0; i < layers.Length; i++) {
            parallax[] layerScene = instLayer(layers[i]);

            for (int j = 0; j < 3; j++) {
                //currentScene[i][j] = layerScene[j];
            }
        }
    }

    parallax[] instLayer(parallax layer) {
        Vector3 boundary = layer.GetComponent<Renderer>().bounds.size;
        Vector3 leftPos = new Vector3(layer.transform.position.x - boundary.x, layer.transform.position.y, layer.transform.position.z);
        Vector3 rightPos = new Vector3(layer.transform.position.x + boundary.x, layer.transform.position.y, layer.transform.position.z);
        parallax[] scene = new parallax[3];
        scene[0] = Instantiate(layer, layer.transform.position, Quaternion.identity);
        scene[1] = Instantiate(layer, leftPos, Quaternion.identity);
        scene[2] = Instantiate(layer, rightPos, Quaternion.identity);
        scene[0].setCentral();
        return scene;
    }
}
