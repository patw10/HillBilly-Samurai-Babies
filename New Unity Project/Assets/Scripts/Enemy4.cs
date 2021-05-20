using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    public float speed;
    public GameObject Coin;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Projectile":
                Destroy(gameObject);
                Instantiate(Coin, transform.position, Quaternion.identity);
                break;

            case "Finish":
                Destroy(gameObject);
                break;

            case "Player":
                other.GetComponent<Control>().health = 0;
                break;
        }
    }
}