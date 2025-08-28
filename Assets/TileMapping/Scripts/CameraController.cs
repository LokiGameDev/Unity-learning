using UnityEngine;

public class CameraController : MonoBehaviour 
{
    [SerializeField]
    private float scrollSpeed = 10f;
    private float rotationSpeed = 5f;

    [SerializeField]
    private Transform pivot;

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            transform.position += scrollSpeed * new Vector3(0, -Input.GetAxis("Mouse ScrollWheel"), 0);
        }

        if (Input.GetMouseButton(2) && pivot != null)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.RotateAround(pivot.position, Vector3.up, mouseX * rotationSpeed);

            Vector3 right = transform.right;
            transform.RotateAround(pivot.position, right, -mouseY * rotationSpeed);
        }

    }

}