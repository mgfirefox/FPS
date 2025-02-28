using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public MouseRotationAxes mouseRotationAxes = MouseRotationAxes.XY;

    public float horizontalSensitivity = 10.0f;
    public float verticalSensitivity = 10.0f;

    public float minSlopeAngle = -89.0f;
    public float maxSlopeAngle = 89.0f;

    private float rotationX = 0;


    //private void Start()
    //{
    //    if (TryGetComponent<Rigidbody>(out var rigidbody))
    //    {
    //        print("abc");
    //        rigidbody.freezeRotation = true;
    //    }
    //}

    void Update()
    {
        if (mouseRotationAxes == MouseRotationAxes.X)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * horizontalSensitivity, 0);
        }
        else if (mouseRotationAxes == MouseRotationAxes.Y)
        {
            rotationX -= Input.GetAxis("Mouse Y") * verticalSensitivity;
            rotationX = Mathf.Clamp(rotationX, minSlopeAngle, maxSlopeAngle);
            transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, 0);
        }
        else
        {
            rotationX -= Input.GetAxis("Mouse Y") * verticalSensitivity;
            rotationX = Mathf.Clamp(rotationX, minSlopeAngle, maxSlopeAngle);

            float rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * horizontalSensitivity;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }
}
