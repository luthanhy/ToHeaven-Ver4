using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class layerMovingCharacer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
 void OnTriggerEnter(Collider other)
    {
        // Lấy layer của đối tượng này
        int layer1 = gameObject.layer;

        // Lấy layer của đối tượng trigger
        int layer2 = other.gameObject.layer;

        // In ra thông tin về các layer
        Debug.Log("Layer của đối tượng này: " + LayerMask.LayerToName(layer1));
        Debug.Log("Layer của đối tượng trigger: " + LayerMask.LayerToName(layer2));
    }
}
