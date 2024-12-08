using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleAxeSwing : MonoBehaviour
{
    // Đối tượng trung tâm để xoay quanh
    public Transform centerObject;

    // Tốc độ xoay
    public float rotationSpeed = 30f;

    void Update()
    {
        if (centerObject != null)
        {
            // Xoay đối tượng này quanh trục của centerObject
            transform.RotateAround(centerObject.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
