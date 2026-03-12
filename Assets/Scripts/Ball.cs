using UnityEngine;
using UnityEngine.SceneManagement; 

public class Ball : MonoBehaviour
{
    [Header("Cài đặt Lực nảy")]
    public float bounceForce = 6f; 

    // BÍ KÍP: Biến static này sẽ không bị xóa khi chuyển Scene.
    // Nó dùng để lưu lại tên màn chơi trước khi Game Over.
    public static string lastLevel;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // 1. Chạm đích (Finish) -> Chuyển màn tiếp theo
        if (collision.gameObject.CompareTag("Finish"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        // 2. Chạm bẫy đỏ (Danger) -> Ghi nhớ màn hiện tại và gọi Game Over
        else if (collision.gameObject.CompareTag("Danger"))
        {
            Debug.Log("GAME OVER! BẠN ĐÃ CHẠM BẪY!");
            
            // Ghi nhớ tên Scene hiện tại (VD: "Level1" hoặc "Level2") vào biến static
            lastLevel = SceneManager.GetActiveScene().name;
            
            // Load sang Scene Game Over (Đảm bảo bạn đã tạo Scene tên là "GameOverScene")
            SceneManager.LoadScene("GameOverScene"); 
        }
        // 3. Nảy bình thường
        else
        {
            rb.linearVelocity = new Vector3(0f, bounceForce, 0f);
        }
    }
}