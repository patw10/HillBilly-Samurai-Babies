using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}