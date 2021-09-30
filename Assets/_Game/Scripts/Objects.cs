using UnityEngine;

public class Objects : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private ObstacleHittedChannel obstacleHitted;
    [SerializeField]
    private Data data;
    

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
