using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [Header("ScriptableObjects")]
    [SerializeField]
    private ObstacleHittedChannel obstacleHitted;
    [SerializeField]
    private Data data;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Knife"))
        {
            data.Coins += 1;
            Destroy(gameObject);
            obstacleHitted.RaiseEvent();
        }
    }
}
