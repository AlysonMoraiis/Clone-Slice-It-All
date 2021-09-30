using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Channels/ObstacleHitted")]
public class ObstacleHittedChannel : ScriptableObject
{
    public UnityAction OnObstacleHitted;
    public UnityAction OnCableTrigger;

    public void RaiseEvent()
    {
        OnObstacleHitted?.Invoke();
    }

    public void RaiseDeadEvent()
    {
        OnCableTrigger?.Invoke();
    }


}
