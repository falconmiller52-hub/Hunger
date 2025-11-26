using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Настройки игрока")]
    public float walkSpeed = 3.0f; // Скорость ходьбы (медленная для хоррора)
    public float runSpeed = 6.0f;  // Скорость бега
    public float mouseSensitivity = 2.0f; // Чувствительность мыши
    public float gravity = -9.81f; // Сила тяжести

    [Header("Привязки")]
    public Camera playerCamera; // Сюда перетащим камеру

    private CharacterController controller;
    private Vector3 velocity;
    private float xRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        // Скрываем курсор мыши, чтобы не мешал
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 1. Вращение камерой (Мышь)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Ограничиваем взгляд (чтобы не сломать шею)

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX); // Вращаем все тело игрока по горизонтали

        // 2. Движение (WASD)
        float x = Input.GetAxis("Horizontal"); // A и D
        float z = Input.GetAxis("Vertical");   // W и S

        // Проверка на бег (Shift)
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * currentSpeed * Time.deltaTime);

        // 3. Гравитация (чтобы падать, если под ногами нет пола)
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
