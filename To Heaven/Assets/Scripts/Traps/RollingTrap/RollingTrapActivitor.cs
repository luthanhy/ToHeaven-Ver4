using UnityEngine;
using System.Collections.Generic;

public class RollingTrapActivator : MonoBehaviour
{
    public List<GameObject> traps; // Danh sách các bẫy cần hiển thị

    private List<RollingTrap> rollingTraps = new List<RollingTrap>(); // Danh sách lưu trữ script RollingTrap

    private void Start()
    {
        foreach (GameObject trap in traps)
        {
            if (trap != null)
            {
                // Ẩn bẫy khi bắt đầu game
                trap.SetActive(false);

                // Lấy script RollingTrap từ bẫy
                RollingTrap rollingTrap = trap.GetComponent<RollingTrap>();
                if (rollingTrap != null)
                {
                    rollingTrap.enabled = false; // Vô hiệu hóa script ban đầu
                    rollingTraps.Add(rollingTrap); // Thêm vào danh sách rollingTraps
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Kích hoạt bẫy khi người chơi đi vào Trigger Zone
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < traps.Count; i++)
            {
                if (traps[i] != null)
                {
                    traps[i].SetActive(true); // Hiển thị bẫy

                    if (rollingTraps[i] != null)
                    {
                        rollingTraps[i].enabled = true; // Kích hoạt script RollingTrap
                    }
                }
            }
        }
    }
}
