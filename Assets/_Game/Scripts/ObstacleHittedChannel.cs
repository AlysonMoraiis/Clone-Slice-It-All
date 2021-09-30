using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Channels/ObstacleHitted")]
public class ObstacleHittedChannel : ScriptableObject
{
    public UnityAction OnObstacleHitted;

    public void RaiseEvent()
    {
        OnObstacleHitted?.Invoke();
    }
}
