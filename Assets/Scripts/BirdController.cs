using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private float speed = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();


        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnJump(InputValue jumpValue)
    {
        Vector3 jumpreset = rb.linearVelocity;
        jumpreset.y = 0f;
        rb.linearVelocity = jumpreset;

        Vector3 jumpPower = new Vector3(0.0f, 1f, 0.0f);

        rb.AddForce(jumpPower, ForceMode.Impulse);
    }
    void Update()
    {

    }

        void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, movementY, 0.0f);
        rb.AddForce(movement * speed, ForceMode.Impulse);
    }
}
