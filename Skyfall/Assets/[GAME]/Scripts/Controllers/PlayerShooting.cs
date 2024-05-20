using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Camera _playerCamera;
    public float shootingRange = 100f;
    ZombieController _zombieController;

    void Start()
    {
        _playerCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = _playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, shootingRange))
        {
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Meteor"))
                {
                    Destroy(hit.collider.gameObject);
                    MeteorManager.OnMeteorDestroy.Invoke();
                }
                else if (hit.collider.CompareTag("Enemy"))
                {
                    _zombieController = hit.collider.gameObject.GetComponent<ZombieController>();
                    _zombieController.KillZombie();
                }
            }
        }
    }
}
