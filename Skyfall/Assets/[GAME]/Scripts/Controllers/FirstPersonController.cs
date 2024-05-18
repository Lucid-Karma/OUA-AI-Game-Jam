using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;
    public Camera playerCamera;

    private float rotationX = 0f;

    void Update()
    {
        // Player movement
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.position += move;

        // Player mouse look
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
