using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Biến public để bạn có thể chỉnh tốc độ xoay trực tiếp ngoài Unity
    public float rotationSpeed = 500f;

    void Update()
    {
        // Kiểm tra xem người chơi có đang giữ chuột trái (hoặc chạm ngón tay) không
        if (Input.GetMouseButton(0))
        {
            // Lấy khoảng cách vuốt chuột theo chiều ngang (trục X)
            float mouseX = Input.GetAxis("Mouse X");

            // Lệnh xoay: transform.Rotate(trục X, trục Y, trục Z)
            // Xoay tháp quanh trục Y (trục dọc). Nhân với -1 để hướng xoay thuận tay
            transform.Rotate(0, -mouseX * rotationSpeed * Time.deltaTime, 0);
        }
    }
}