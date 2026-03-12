using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Mục Tiêu")]
    public Transform target; // Quả bóng sẽ được kéo vào đây

    [Header("Cài đặt Camera")]
    public float smoothSpeed = 5f; // Tốc độ di chuyển cho mượt (càng nhỏ càng trễ)
    public float offsetY = 3f; // Khoảng cách Camera đứng cao hơn quả bóng

    // Dùng LateUpdate thay vì Update để đảm bảo Camera di chuyển sau khi quả bóng đã tính toán xong vật lý
    void LateUpdate()
    {
        // Nếu chưa kéo quả bóng vào thì bỏ qua để không bị lỗi code
        if (target == null) return; 

        // Lấy vị trí hiện tại của Camera
        Vector3 newPos = transform.position;

        // BÍ QUYẾT: Chỉ dùng Mathf.Lerp cho riêng trục Y. 
        // Trục X và Z giữ nguyên để Camera không bị lắc lư sang hai bên.
        newPos.y = Mathf.Lerp(transform.position.y, target.position.y + offsetY, smoothSpeed * Time.deltaTime);

        // Áp dụng vị trí mới cho Camera
        transform.position = newPos;
    }
}