using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 5f;

    [Header("Screen Limits")]
    [SerializeField] float minX = -6f;
    [SerializeField] float maxX = 6f;

    private Rigidbody rb;
    public bool isAlive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        Vector3 velocity = new Vector3(moveInput * moveSpeed, 0f, 0f);

        rb.linearVelocity = velocity;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            transform.position.y,
            transform.position.z
        );
    }
}
