using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Finish":
                Destroy(gameObject);
                break;
            case "Enemy":
                Destroy(gameObject);
                break;
            case "Boss":
                Destroy(gameObject);
                break;
        }
    }
}