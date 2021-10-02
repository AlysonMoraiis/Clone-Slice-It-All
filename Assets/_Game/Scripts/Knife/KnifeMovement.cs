using UnityEngine;
using UnityEngine.UI;

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
    private KnifeHandleCollision knifeHandleCollision;

    [Header("Others")]
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Button clickButton;

    private bool canRotate;
    private bool canJump;

    private void OnEnable()
    {
        clickButton.onClick.AddListener(delegate {canJump = true;});
    }
    private void OnDisable()
    {
        clickButton.onClick.RemoveAllListeners();
    }

    private void FixedUpdate()
    {
        if (canRotate)
        {
            rb.angularVelocity = Vector3.forward * rotationSpeed;
        }

        if (canJump)
        {
            rb.constraints = RigidbodyConstraints.None;
            KnifeRotation();
            rb.velocity = new Vector3(-movementSpeed, clickForce, 0);
            rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
            canJump = false;
        }
    }

    private void KnifeRotation()
    {
        canRotate = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            canRotate = false;
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
        if(collision.gameObject.CompareTag("ForbiddenZone"))
        {
            knifeHandleCollision.RaiseEvent();
        }
    }
}
