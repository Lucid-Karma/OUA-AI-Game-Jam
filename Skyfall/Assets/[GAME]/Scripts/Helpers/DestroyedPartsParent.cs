using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedPartsParent : MonoBehaviour
{
    // Yok edilmeden önce geçecek süre 
    public float timeToDestroyAfterSingleCall = 5f;

    void Start()
    {
        // "DestroyParentO" fonksiyonunu belirli bir gecikmeyle çaðýr
        Invoke("DestroyParentO", timeToDestroyAfterSingleCall);
    }

    // Parça halindeki ev klonlarýný yok etmek için kullanýlan metot.
    void DestroyParentO()
    {
        // Bu GameObject'u yok et
        Destroy(gameObject);
    }
}

