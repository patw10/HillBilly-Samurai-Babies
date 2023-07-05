using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private float lifetime = 0;
    private void Update()
    {
        if (lifetime >= 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            lifetime += Time.deltaTime;
        }
        if (lifetime >= 1.6f)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        Destroy(this.gameObject, 1.8f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Floor":
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