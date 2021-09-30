using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    [Header("Alterables")]
    [SerializeField]
    private float clickForce;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotationSpeed;
    
    [Header("ScriptableObjects")]
    [SerializeField]
    private KnifeCableCollision knifeCableCollision;
    
    [Header("Others")]
    [SerializeField]
    private Rigidbody rb;

    void Start()
    {
    }

    public void KnifeJump()
    {
        //rb.freezeRotation = false;
        rb.constraints = RigidbodyConstraints.None;
        rb.angularVelocity = new Vector3(0,0, -rotationSpeed);
        rb.velocity = new Vector3(movementSpeed, clickForce, 0);
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
            knifeCableCollision.RaiseEvent();
            Debug.Log("Morreu");
        }
    }
}
