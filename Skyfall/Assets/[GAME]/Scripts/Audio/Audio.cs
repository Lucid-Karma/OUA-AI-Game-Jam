using UnityEngine;

public class Audio : MonoBehaviour
{
    // Arka plan müziði için ses kaynaðý
    private AudioSource _background;

    // Audio sýnýfýnýn tek bir örneðini tutar (singleton)
    public static Audio Instance { get; private set; }
    // Audio sýnýfýnýn bir örneðini tutar 
    public static Audio audioObject = null;

    void Awake()
    {
        // GameObject'den AudioSource bileþenini al
        _background = gameObject.GetComponent<AudioSource>();

        // Audio sýnýfýnýn örneði yoksa (ilk oluþturulma)
        if (audioObject == null)
        {
            // Bu nesneyi Instance olarak ata
            audioObject = this;
            // Sahneler arasýnda yok edilmemesini saðla
            DontDestroyOnLoad(this);
        }
        // Eðer baþka bir Audio nesnesi zaten varsa (sahne geçiþi)
        else if (this != audioObject)
        {
            // Bu GameObject'u yok et (gereksiz kopyayý önle)
            Destroy(gameObject);
        }
    }
}

