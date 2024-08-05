using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector3 direction;

    public float jumpForce;
    private Rigidbody playerRb;
    [SerializeField] private bool isOnGround;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get Input
        direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        // Move the Player
        transform.Translate(direction * (speed * Time.deltaTime));

        // To Jump
        if ((isOnGround) && Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isOnGround = true;
    }
}