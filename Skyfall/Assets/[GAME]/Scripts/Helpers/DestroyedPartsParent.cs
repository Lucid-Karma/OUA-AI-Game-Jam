using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedPartsParent : MonoBehaviour
{
    public float timeToDestroyAfterSingleCall = 5f;

    private void Start()
    {
        Invoke("DestroyParentO", timeToDestroyAfterSingleCall);
    }

    private void DestroyParentO()
    {
        Destroy(gameObject);
    }
}
