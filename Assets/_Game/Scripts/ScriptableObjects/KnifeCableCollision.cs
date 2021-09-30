using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Channels/KnifeCableCollision")]
public class KnifeCableCollision : ScriptableObject
{
    public UnityAction OnCableTrigger;

    public void RaiseEvent()
    {
        OnCableTrigger?.Invoke();
    }

}
