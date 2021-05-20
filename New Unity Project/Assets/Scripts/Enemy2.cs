using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    private int health = 2;
    public float speed;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (health == 1)
        {
            heart1.SetActive(false);
            heart2.SetActive(true);
        }
        if (health == 0)
        {
            heart2.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Finish":
                Destroy(gameObject);
                break;

            case "Player":
                other.GetComponent<Control>().health = 0;
                break;

            case "Projectile":
                health--;
                break;
        }
    }
}