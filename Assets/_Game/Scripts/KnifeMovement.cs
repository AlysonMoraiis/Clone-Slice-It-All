using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    [Header("Alterables")]
    [SerializeField]
    private float clickForce;
    [SerializeField]
    private float movementSpeed;
    //[SerializeField]
    //private float rotationSpeed;
    
    [Header("Others")]
    [SerializeField]
    private Rigidbody rb;

    //private float timeLeft = 1;

    public bool rool;

    private void Update()
    {
        if (transform.rotation.z >= 0 && transform.rotation.z <= 20 && rool)
        {
            KnifeRotation(0.2f);
            float timeLeft = 1;
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
            KnifeRotation(6.2f);
            rool = false;
            }
        }
    }

    public void KnifeJump()
    {
        rb.constraints = RigidbodyConstraints.None;
        KnifeRotation(6.2f);
        rb.velocity = new Vector3(movementSpeed, clickForce, 0);
        rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
    }

    private void KnifeRotation(float rotationSpeed)
    {
        rb.angularVelocity = new Vector3(0, 0, -rotationSpeed);
        float timeLeft = 0.9f;
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
        rool = true;
        }
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
}
