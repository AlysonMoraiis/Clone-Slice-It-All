using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHandleTrigger : MonoBehaviour
{
    [Header("ScriptableObjects")]
    [SerializeField]
    private KnifeHandleCollision knifeCableCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            knifeCableCollision.RaiseEvent();
        }
    }
}
