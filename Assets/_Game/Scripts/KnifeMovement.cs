using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float clickForce;
    private bool isJump;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.freezeRotation = false;
            KnifeJump();
        }
    }

    private void KnifeJump()
    {
        rb.angularVelocity = new Vector3(0,0, -4.5f);
        rb.velocity = new Vector3(speed, clickForce, 0);
        rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = Vector3.zero;
            rb.freezeRotation = true;
        }
    }
}
