using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public float speed;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Finish":
                Destroy(gameObject);
                break;

            case "Player":
                Ui_Script.Coin.ChangeScore(coinValue);
                break;
        }
    }
}