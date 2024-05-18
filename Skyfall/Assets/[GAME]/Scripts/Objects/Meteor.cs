using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float fallSpeed = 50f;

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        if (transform.position.y <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
