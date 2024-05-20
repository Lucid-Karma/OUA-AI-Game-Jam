using UnityEngine;

public class Meteor : MonoBehaviour
{
    
    public float fallSpeed = 50f; // Meteorun düþme hýzý 
    private bool _isGrounded; // Meteor yere çarpýp durmuþ mu?

    void Update()
    {
        // Eðer yere çarpmadýysa aþaðý doðru hareket ettir
        if (!_isGrounded)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        }
        // Y eksenindeki konumu 0'dan küçük veya eþitse yok et
        if (transform.position.y <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Çarpýþtýðý obje "Ground" etiketliyse yere çarpýp durmuþ olarak iþaretle ve yok et
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            Destroy(gameObject);
        }
        // Çarpýþtýðý obje "Player" etiketliyse yok et
        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
