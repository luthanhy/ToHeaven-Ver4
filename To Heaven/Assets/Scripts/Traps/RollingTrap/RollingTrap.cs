using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingTrap : MonoBehaviour
{
    public float rotationSpeed;     // Tốc độ xoay
    public float moveSpeed;         // Tốc độ di chuyển
    public Vector3 moveDirection;   // Hướng di chuyển
    public float lifeTime = 5f;          // Thời gian tồn tại của bẫy
    public float fadeDuration = 1f;      // Thời gian mờ dần trước khi biến mất

    private Renderer renderer;
    private Color originalColor;


    private void Start()
    {
        // Lấy Renderer để quản lý hiệu ứng mờ dần
        renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            originalColor = renderer.material.color;
        }

        // Tự động hủy sau thời gian lifeTime
        Invoke(nameof(StartFadeAndDestroy), lifeTime - fadeDuration);
    }

    void Update()
    {
        // Xoay bẫy
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.Self);

        //// Di chuyển bẫy
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime, Space.World);
    }

    private void StartFadeAndDestroy()
    {
        StartCoroutine(FadeAndDestroy());
    }

    private IEnumerator FadeAndDestroy()
    {
        if (renderer != null)
        {
            for (float t = 0; t < fadeDuration; t += Time.deltaTime)
            {
                float alpha = Mathf.Lerp(1, 0, t / fadeDuration);
                renderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
                yield return null;
            }
        }
        Destroy(gameObject); // Xóa object sau khi hoàn tất mờ dần
    }
}
