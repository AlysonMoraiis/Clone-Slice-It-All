using UnityEngine;

public class WinGround : MonoBehaviour
{
    [Header("ScriptableObjects")]
    [SerializeField]
    private WinCollisionChannel WinCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Knife"))
        {
            WinCollision.RaiseEvent();
        }
    }
}
