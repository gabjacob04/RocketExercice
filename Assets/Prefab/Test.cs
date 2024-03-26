using UnityEngine;

public class MoveAndRotate : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 3f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Move the GameObject
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Rotate the GameObject while right mouse button is held down
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            transform.Rotate(Vector3.up, mouseX);
        }

        // Update camera position to follow the GameObject
        if (mainCamera != null)
        {
            mainCamera.transform.position = transform.position - transform.forward * 10f + Vector3.up * 3f;
            mainCamera.transform.LookAt(transform.position + transform.forward * 10f);
        }
    }
}
