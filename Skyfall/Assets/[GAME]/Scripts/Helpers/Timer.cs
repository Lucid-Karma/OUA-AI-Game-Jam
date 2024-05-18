using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour
{
    public Slider deTimer; // Slider referansý
    public float duration = 10f; // Slider'ýn tamamen dolmasý için geçen süre
    public float decreaseSpeed = 4f; // Slider'ýn azalma hýzý (yüksek deðer = hýzlý azalma)
    public float increaseSpeed = 1f; // Slider'ýn artma hýzý (düþük deðer = yavaþ artma)

    private bool isSpacePressed = false; // Space tuþunun basýlý olup olmadýðýný kontrol eder

    void Start()
    {
        if (deTimer == null)
        {
            deTimer = GetComponent<Slider>();
        }

        // Slider'ýn baþlangýçta tamamen dolu olmasýný saðla
        deTimer.maxValue = duration;
        deTimer.value = duration;
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
            deTimer.value -= Time.deltaTime * decreaseSpeed;
            if (deTimer.value <= 0)
            {
                deTimer.value = 0;
                Time.timeScale = 1;
            }
        }
        else
        {
            deTimer.value += Time.deltaTime * increaseSpeed;
            if (deTimer.value >= duration)
            {
                deTimer.value = duration;
            }
        }
    }
}