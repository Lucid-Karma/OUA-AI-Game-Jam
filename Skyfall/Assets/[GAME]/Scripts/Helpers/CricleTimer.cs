using UnityEngine;
using UnityEngine.UI;

public class CircularTimer : MonoBehaviour
{
    public Image timerImage; // Daire þekilli timer referansý
    public float duration = 10f; // Timer'ýn tamamen dolmasý için geçen süre
    public float decreaseSpeed = 4f; // Timer'ýn azalma hýzý (yüksek deðer = hýzlý azalma)
    public float increaseSpeed = 1f; // Timer'ýn artma hýzý (düþük deðer = yavaþ artma)

    private bool isSpacePressed = false; // Space tuþunun basýlý olup olmadýðýný kontrol eder
    private float currentValue; // Mevcut timer deðeri

    void Start()
    {
        if (timerImage == null)
        {
            timerImage = GetComponent<Image>();
        }

        // Timer'ýn baþlangýçta tamamen dolu olmasýný saðla
        currentValue = duration;
        timerImage.fillAmount = 1f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 0.2f;
            decreaseSpeed = 15f;
            isSpacePressed = true;
        }
        else
        {
            Time.timeScale = 1;
            isSpacePressed = false;
        }

        if (isSpacePressed)
        {
            currentValue -= Time.deltaTime * decreaseSpeed;
            if (currentValue <= 0)
            {
                currentValue = 0;
                Time.timeScale = 1;
            }
        }
        else
        {
            currentValue += Time.deltaTime * increaseSpeed;
            if (currentValue >= duration)
            {
                currentValue = duration;
            }
        }

        // Fill amount deðerini güncelle
        timerImage.fillAmount = currentValue / duration;
    }
}
