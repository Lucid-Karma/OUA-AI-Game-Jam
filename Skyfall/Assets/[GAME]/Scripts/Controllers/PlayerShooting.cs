using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Oyuncu kamerasý
    private Camera _playerCamera;
    // Atýþ menzili 
    public float shootingRange = 200f;
    // Zombi kontrol script'i 
    private ZombieController _zombieController;
    // Meteor patlama efekti 
    public GameObject meteorExplode;

    void Start()
    {
        // Oyuncu kamerasýný bul
        _playerCamera = Camera.main;

        // Fare imlecini gizle ve sabitle
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Sol fare tuþuna basýldýðýnda ateþ et
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Kamera merkezinden çýkan ýþýn
        Ray ray = _playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        // Iþýn çarpýþmasý bilgisi
        RaycastHit hit;

        // Iþýn atýþý ve çarpýþma kontrolü (menzil dahilinde)
        if (Physics.Raycast(ray, out hit, shootingRange))
        {
            // Çarpýþan bir obje varsa
            if (hit.collider != null)
            {
                // Çarpýþan obje "Meteor" etiketliyse
                if (hit.collider.CompareTag("Meteor"))
                {
                    // Patlama efektini oluþtur ve çalýþtýr
                    GameObject _meteorExplode = Instantiate(meteorExplode, hit.collider.gameObject.transform.position, Quaternion.identity);
                    _meteorExplode.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                    StartCoroutine(DestroyParticleObject(_meteorExplode));

                    // Çarpýþan meteoru yok et
                    Destroy(hit.collider.gameObject);
                    // Meteor yok edilme olayýný tetikle (eðer varsa)
                    MeteorManager.OnMeteorDestroy.Invoke();
                }
                // Çarpýþan obje "Enemy" (düþman) etiketliyse
                else if (hit.collider.CompareTag("Enemy"))
                {
                    // Düþman kontrol script'ini al
                    _zombieController = hit.collider.gameObject.GetComponent<ZombieController>();
                    // Düþmaný öldür fonksiyonunu çaðýr
                    _zombieController.KillZombie();
                }
            }
        }
    }

    IEnumerator DestroyParticleObject(GameObject meteorObject)
    {
        // 1 saniye bekle sonra patlama efektini yok et
        yield return new WaitForSeconds(1);
        Destroy(meteorObject);
    }
}
