using UnityEngine;
using UnityEngine.AI;

public class FirstPersonController : MonoBehaviour
{
    // Oyuncunun hareketini kontrol eden NavMeshAgent bileþeni
    private NavMeshAgent _agent;

    // Oyuncunun hareket hýzý 
    public float moveSpeed = 5f;
    // Kamera dönüþ hýzý 
    public float lookSpeed = 2f;

    // Oyuncu kamerasý
    private Camera _playerCamera;
    // Kamera dönüþ açýsý 
    private float _rotationX = 0f;

    void Start()
    {
        // GameObject'den NavMeshAgent bileþenini al
        _agent = GetComponent<NavMeshAgent>();
        // Sahnedeki ana kamerayý bul
        _playerCamera = Camera.main;
    }

    void Update()
    {
        // Yatay (sola-saða) hareket miktarý
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        // Dikey (ileri-geri) hareket miktarý
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Hareket vektörü oluþtur (sað/ileri hareket için)
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        // NavMeshAgent'a hareket emri ver
        _agent.Move(move);

        // Fare yatay hareket miktarý (kamera dönüþü için)
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        // Fare dikey hareket miktarý (kamera dönüþü için)
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;
        // Kamera dönüþ açýsýný hesapla
        _rotationX -= mouseY;
        // Kamera dönüþ açýsýný sýnýrla (-90 ile 90 derece arasý)
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

        // Kamera dönüþünü uygula
        _playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
        // Karakterin yatay dönüþünü uygula (fare ile)
        transform.Rotate(Vector3.up * mouseX);
    }
}

