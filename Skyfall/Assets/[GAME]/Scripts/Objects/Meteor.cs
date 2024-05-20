using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float fallSpeed = 50f;
    private bool _isGrounded;

    void Update()
    {
        if(!_isGrounded)
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        if (transform.position.y <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            _isGrounded = true;
            Destroy(gameObject);
        }
    }
}
