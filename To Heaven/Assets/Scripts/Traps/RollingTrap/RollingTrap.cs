using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingTrap : MonoBehaviour
{
    public float rotationSpeed;     // Tốc độ xoay
    public float moveSpeed;         // Tốc độ di chuyển
    public Vector3 moveDirection;   // Hướng di chuyển

    void Update()
    {
        // Xoay bẫy
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        // Di chuyển bẫy
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime, Space.World);
    }
}
