using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject modelPrefab; // Prefab of the model
    public int numberOfModels = 20; // Number of models
    public float verticalStep = 1f; // Step height (Y)
    public float forwardStep = 2f; // Step length (Z)
    public float fixedRotationAngle = 10f; // Fixed rotation angle for each step
    public Transform startPoint; // Starting point

    void Start()
    {
        // Starting position and rotation
        Vector3 spawnPosition = startPoint != null ? startPoint.position : transform.position;
        Quaternion spawnRotation = Quaternion.identity;

        for (int i = 0; i < numberOfModels; i++)
        {
            // Instantiate the model at the current position
            GameObject model = Instantiate(modelPrefab, spawnPosition, spawnRotation);

            // Apply a fixed rotation incrementally (optional, can be adjusted)
            spawnRotation *= Quaternion.Euler(0, fixedRotationAngle, 0);

            // Update the spawn position for the next model
            spawnPosition += -(spawnRotation * Vector3.forward * forwardStep); // Move forward
            spawnPosition += Vector3.up * verticalStep;                     // Move upward
        }
    }
}
