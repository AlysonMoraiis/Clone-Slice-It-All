using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Channels/KnifeHandleCollision")]
public class KnifeHandleCollision : ScriptableObject
{
    public UnityAction OnCableTrigger;

    public void RaiseEvent()
    {
        OnCableTrigger?.Invoke();
    }

}
