using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementComponent : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private int jumpForce = 5;

    [SerializeField] private int VelocityModifier = 3;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetAxis("Vertical") > 0 && isGrounded)
        {
            isGrounded = false;
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        }

        myRigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * VelocityModifier, myRigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
}
