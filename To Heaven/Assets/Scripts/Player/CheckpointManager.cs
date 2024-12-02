using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Vector3 respawnPosition; // Vị trí để respawn

    void Start()
    {
        // Thiết lập vị trí respawn ban đầu là vị trí spawn mặc định của nhân vật
        respawnPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Nếu nhân vật đi vào checkpoint (đối tượng có tag là "Checkpoint")
        if (other.CompareTag("Checkpoint"))
        {
            // Cập nhật vị trí respawn tới vị trí checkpoint
            respawnPosition = other.transform.position;
        }
    }

    public void Respawn()
    {
        // Đặt lại vị trí của nhân vật về vị trí respawn đã lưu
        transform.position = respawnPosition;
    }
}
