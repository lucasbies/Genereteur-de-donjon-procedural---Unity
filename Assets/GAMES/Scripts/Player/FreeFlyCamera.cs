using UnityEngine;
using UnityEngine.InputSystem;

public class FreeFlyCamera : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float lookSpeed = 0.12f;

    public float speedStep = 2f;     // incrément molette
    public float minSpeed = 1f;
    public float maxSpeed = 100f;

    float yaw;
    float pitch;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Vector3 rot = transform.eulerAngles;
        yaw = rot.y;
        pitch = rot.x;
    }

    void Update()
    {

        float scroll = Mouse.current.scroll.ReadValue().y;
        if (scroll != 0)
        {
            moveSpeed += scroll * speedStep * Time.deltaTime;
            moveSpeed = Mathf.Clamp(moveSpeed, minSpeed, maxSpeed);
        }

        // rotation
        if (Mouse.current.rightButton.isPressed)
        {
            Vector2 delta = Mouse.current.delta.ReadValue();

            yaw += delta.x * lookSpeed;
            pitch -= delta.y * lookSpeed;
            pitch = Mathf.Clamp(pitch, -89f, 89f);

            transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
        }

        // deplacement
        Vector3 dir = Vector3.zero;

        if (Keyboard.current.wKey.isPressed) dir += Vector3.forward;
        if (Keyboard.current.sKey.isPressed) dir += Vector3.back;
        if (Keyboard.current.aKey.isPressed) dir += Vector3.left;
        if (Keyboard.current.dKey.isPressed) dir += Vector3.right;
        if (Keyboard.current.spaceKey.isPressed) dir += Vector3.up;
        if (Keyboard.current.leftCtrlKey.isPressed) dir += Vector3.down;

        transform.Translate(dir * moveSpeed * Time.deltaTime, Space.Self);
    }
}
