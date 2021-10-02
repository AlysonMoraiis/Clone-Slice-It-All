using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Channels/WinCollision")]
public class WinCollisionChannel : ScriptableObject
{
    public UnityAction OnWinCollision;

    public void RaiseEvent()
    {
        OnWinCollision?.Invoke();
    }
}
