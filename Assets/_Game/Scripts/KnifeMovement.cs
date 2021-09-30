using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float clickForce;
    [SerializeField]
    private ObstacleHittedChannel obstacleHittedChannel;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void KnifeJump()
    {
        //rb.freezeRotation = false;
        rb.constraints = RigidbodyConstraints.None;
        rb.angularVelocity = new Vector3(0,0, -4.5f);
        rb.velocity = new Vector3(speed, clickForce, 0);
        rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = Vector3.zero;
            //rb.freezeRotation = true;
            //rb.freezePositionX = true;
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            obstacleHittedChannel.RaiseDeadEvent();
            Debug.Log("Morreu");
        }
    }
}
