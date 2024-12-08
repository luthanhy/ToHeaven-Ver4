using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public Transform door; // Cánh cửa thang máy
    public Transform wallOpenPosition;  // Tường để xác định vị trí mở
    public Transform wallClosedPosition; // Tường để xác định vị trí đóng
    public float doorSpeed = 2.0f; // Tốc độ đóng/mở cửa

    public Transform elevator; // Thang máy di chuyển
    public Transform startPoint; // Điểm bắt đầu
    public Transform endPoint;   // Điểm kết thúc
    public float elevatorSpeed = 2.0f; // Tốc độ di chuyển thang máy

    private bool isMoving = false; // Trạng thái di chuyển của thang máy
    private bool isDoorClosing = false;
    private bool isDoorOpening = false;
    private bool isDoorHalfClosing = false; // Trạng thái đóng cửa một nửa
    private bool isDoorDoubleOpening = false; // Trạng thái mở cửa gấp đôi
    private bool doorClosed = false; // Trạng thái cửa đã đóng hoàn toàn

    private Vector3 halfClosedPosition; // Vị trí đóng một nửa

    private void Start()
    {
        // Tính toán vị trí đóng một nửa khi bắt đầu
        halfClosedPosition = (wallOpenPosition.position + wallClosedPosition.position) / 2;
    }

    private void Update()
    {
        // Xử lý mở cửa
        if (isDoorOpening)
        {
            Vector3 targetPosition = new Vector3(wallOpenPosition.position.x, door.position.y, door.position.z);
            door.position = Vector3.MoveTowards(door.position, targetPosition, doorSpeed * Time.deltaTime);
            if (Vector3.Distance(door.position, targetPosition) < 0.01f)
            {
                isDoorOpening = false; // Hoàn thành mở cửa
            }
        }

        // Xử lý đóng cửa một nửa
        if (isDoorHalfClosing)
        {
            Vector3 targetPosition = new Vector3(wallClosedPosition.position.x, door.position.y, door.position.z);
            door.position = Vector3.MoveTowards(door.position, targetPosition, doorSpeed * Time.deltaTime);
            if (Vector3.Distance(door.position, targetPosition) < 0.01f)
            {
                isDoorHalfClosing = false; // Hoàn thành đóng cửa một nửa
                StartElevator(); // Bắt đầu di chuyển thang máy
            }
        }

        // Xử lý mở cửa gấp đôi
        if (isDoorDoubleOpening)
        {
            Vector3 targetPosition = new Vector3(wallOpenPosition.position.x, door.position.y, door.position.z);
            door.position = Vector3.MoveTowards(door.position, targetPosition, doorSpeed * Time.deltaTime);
            if (Vector3.Distance(door.position, targetPosition) < 0.01f)
            {
                isDoorDoubleOpening = false; // Hoàn thành mở cửa gấp đôi
            }
        }

        // Xử lý di chuyển thang máy
        if (isMoving)
        {
            elevator.position = Vector3.MoveTowards(elevator.position, endPoint.position, elevatorSpeed * Time.deltaTime);
            if (Vector3.Distance(elevator.position, endPoint.position) < 0.01f)
            {
                isMoving = false; // Dừng thang máy
                OpenDoubleDoor(); // Mở cửa gấp đôi khi đạt đỉnh
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Kiểm tra nhân vật bước vào thang máy
        {
            CloseHalfDoor(); // Đóng cửa một nửa khi vào thang máy
        }
    }

    public void OpenDoor()
    {
        isDoorOpening = true;
        isDoorClosing = false;
        isDoorHalfClosing = false;
        isDoorDoubleOpening = false;
        doorClosed = false; // Đặt lại trạng thái cửa mở
    }

    public void CloseDoor()
    {
        isDoorClosing = true;
        isDoorOpening = false;
        isDoorHalfClosing = false;
        isDoorDoubleOpening = false;
    }

    public void CloseHalfDoor()
    {
        isDoorHalfClosing = true;
        isDoorOpening = false;
        isDoorClosing = false;
        isDoorDoubleOpening = false;
    }

    public void OpenDoubleDoor()
    {
        isDoorDoubleOpening = true;
        isDoorOpening = false;
        isDoorClosing = false;
        isDoorHalfClosing = false;
        doorClosed = false; // Đặt lại trạng thái cửa mở
    }

    private void StartElevator()
    {
        isMoving = true;
    }
}