using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Hàm này sẽ được gán vào sự kiện On Click() của nút "Thử Lại"
    public void RetryGame()
    {
        // Kiểm tra xem quả bóng có nhớ tên màn cũ không
        if (!string.IsNullOrEmpty(Ball.lastLevel))
        {
            // Load lại đúng cái màn mà quả bóng đã lưu
            SceneManager.LoadScene(Ball.lastLevel);
        }
        else
        {
            // Đề phòng trường hợp lỗi chưa lưu được, cho quay tạm về Level 1
            SceneManager.LoadScene("Level1");
        }
    }
    
    // Hàm cho nút chọn "Màn 1"
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    // Hàm cho nút chọn "Màn 2" (Bắt buộc phải có "public" ở đầu)
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}