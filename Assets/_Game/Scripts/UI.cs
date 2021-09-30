using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI coinsText;
    [SerializeField]
    private Data data;
    [SerializeField]
    private ObstacleHittedChannel obstacleHittedChannel;

    private void OnEnable()
    {
        obstacleHittedChannel.OnObstacleHitted += ValueUpdate;
    }
    private void OnDisable()
    {
        obstacleHittedChannel.OnObstacleHitted -= ValueUpdate;
    }

    private void ValueUpdate()
    {
        coinsText.text = data.Coins.ToString();
    }
}
