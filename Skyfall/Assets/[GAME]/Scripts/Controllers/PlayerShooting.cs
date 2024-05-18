using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Camera _playerCamera;
    public float shootingRange = 100f;

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

    //void Shoot()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, shootingRange))
    //    {
    //        if (hit.collider != null)
    //        {
    //            if (hit.collider.CompareTag("Meteor"))
    //            {
    //                Destroy(hit.collider.gameObject);
    //            }
    //        }
    //    }
    //}

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
                }
            }
        }
    }
}
