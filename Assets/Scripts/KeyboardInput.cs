using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    private CharacterController characterController;

    public float gravity = -9.8f;
    public float speed = 5.0f;


    public void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float deltaTime = Time.deltaTime;

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        var movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= deltaTime;
        movement = transform.TransformDirection(movement);
        movement.y = gravity;

        characterController.Move(movement);
    }
}
