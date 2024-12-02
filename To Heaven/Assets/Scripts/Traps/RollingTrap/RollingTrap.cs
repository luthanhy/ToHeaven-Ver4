using System.Collections;
using UnityEngine;

public class RollingTrap : MonoBehaviour
{
    public float rotationSpeed = 100f; // Lực xoay
    public float moveSpeed = 5f;       // Tốc độ di chuyển
    public float lifeTime = 5f;       // Thời gian tồn tại
    public float fadeDuration = 1f;   // Thời gian mờ dần trước khi biến mất
    public Vector3 moveDirection = Vector3.forward; // Hướng di chuyển
    public float knockbackForce = 10f; // Lực đẩy người chơi khi va chạm

    private Rigidbody rb;             // Rigidbody của bẫy
    private Renderer renderer;        // Renderer để kiểm soát vật liệu của bẫy
    private Color originalColor;      // Lưu lại màu gốc của bẫy

    private void Start()
    {
        // Lấy Rigidbody
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody not found! Please attach a Rigidbody to the RollingTrap.");
            return;
        }

        // Lấy Renderer để điều chỉnh hiệu ứng mờ dần
        renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            originalColor = renderer.material.color;
        }

        // Bắt đầu xóa bẫy sau lifeTime giây và thêm hiệu ứng mờ dần
        Invoke(nameof(StartFadeAndDestroy), lifeTime - fadeDuration);
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            // Thêm lực xoay để bẫy lăn
            rb.AddTorque(transform.right * rotationSpeed * Time.fixedDeltaTime, ForceMode.Force);

            // Thêm lực di chuyển
            rb.AddForce(moveDirection.normalized * moveSpeed * Time.fixedDeltaTime, ForceMode.Force);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Kiểm tra nếu bẫy va chạm với người chơi
        if (collision.gameObject.CompareTag("Player"))
        {
            // Lấy Rigidbody của người chơi
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                // Tính toán hướng đẩy người chơi
                Vector3 knockbackDirection = (collision.transform.position - transform.position).normalized;
                knockbackDirection.y = 1f; // Đẩy người chơi lên một chút

                // Tác động lực lên người chơi
                playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
            }
        }
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
                // Tính toán giá trị alpha (độ trong suốt)
                float alpha = Mathf.Lerp(1, 0, t / fadeDuration);
                renderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
                yield return null;
            }
        }

        // Xóa object sau khi mờ dần
        Destroy(gameObject);
    }
}
