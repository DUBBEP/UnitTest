using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterMover : MonoBehaviour, ICharacter
{
    private Rigidbody rb;

    [Header("Stats")]
    
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private int startingHealth;

    [Header("Parameters")]
    
    [SerializeField]
    private float speedCap;
    [SerializeField]
    private float gravityValue;
    [SerializeField]
    private bool isPlayer;

    [HideInInspector]
    public bool canMove;
    private bool dead;
    public bool IsPlayer => isPlayer;
    public int Health { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Health = startingHealth;
        canMove = true;
    }
    private void Start()
    {
        GameUI.instance.UpdateHealthText(this);
    }
    void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontal, 0, vertical);

        if (canMove && !dead)
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

    public void CheckHealth()
    {
        GameUI.instance.UpdateHealthText(this);

        if (Health <= 0)
            Die();
    }

    void Die()
    {
        rb.freezeRotation = false;
        dead = true;
    }
}
