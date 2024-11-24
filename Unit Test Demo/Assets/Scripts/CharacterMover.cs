using UnityEngine;

public class CharacterMover : MonoBehaviour, ICharacter
{
    private Rigidbody rb;

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float speedCap;
    [SerializeField]
    private float gravityValue;
    [SerializeField]
    private bool isPlayer;

    public bool canMove;
    public bool IsPlayer => isPlayer;
    public int Health { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Health = 10;
        canMove = true;
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontal, 0, vertical);

        if (canMove)
        {
            MovePlayer(movementDirection);
        }
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        rb.AddForce(Vector3.down * gravityValue, ForceMode.Force);
    }

    private void MovePlayer(Vector3 movementDirection)
    {
        rb.AddForce(movementDirection * movementSpeed, ForceMode.Acceleration);
        if (rb.velocity.magnitude > speedCap)
        {
            rb.velocity = rb.velocity.normalized * speedCap;
        }
    }
}
