using UnityEngine;

public class RollingTrapActivator : MonoBehaviour
{
    public GameObject trap; // Bẫy cần hiển thị


    private RollingTrap rollingTrap; // Biến lưu trữ script RollingTrap

    private void Start()
    {
        if (trap != null)
        {
            // Ẩn bẫy khi bắt đầu game
            trap.SetActive(false);

            // Lấy script RollingTrap từ bẫy
            rollingTrap = trap.GetComponent<RollingTrap>();
            if (rollingTrap != null)
            {
                rollingTrap.enabled = false; // Vô hiệu hóa script ban đầu
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Kích hoạt bẫy khi người chơi đi vào Trigger Zone
        if (other.CompareTag("Player"))
        {
            if (trap != null)
            {
                trap.SetActive(true); // Hiển thị bẫy

                if (rollingTrap != null)
                {
                    rollingTrap.enabled = true; // Kích hoạt script RollingTrap
                  
                }
            }
        }
    }
}
