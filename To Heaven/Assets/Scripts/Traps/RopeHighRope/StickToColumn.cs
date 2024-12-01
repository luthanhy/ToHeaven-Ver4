using UnityEngine;

public class StickToColumn : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Ki?m tra n?u nh�n v?t va ch?m v?i c?t
        if (collision.gameObject.CompareTag("Player"))
        {
            // G?n nh�n v?t l�m con c?a c?t
            collision.transform.SetParent(transform);
            Debug.Log("Player stuck to column");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Khi nh�n v?t r?i kh?i c?t
        if (collision.gameObject.CompareTag("Player"))
        {
            // H?y g?n cha-con
            collision.transform.SetParent(null);
            Debug.Log("Player detached from column");
        }
    }
}
