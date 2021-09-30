using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [Header("ScriptableObjects")]
    [SerializeField]
    private ObstacleHittedChannel obstacleHitted;
    [SerializeField]
    private Data data;

    [Header("Others")]    
    [SerializeField]
    private Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Knife"))
        {
            data.Coins += 1;
            Debug.Log("Bateu");
            obstacleHitted.RaiseEvent();
        }
    }
}
