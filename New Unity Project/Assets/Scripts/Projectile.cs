using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Enemy":
                Destroy(gameObject);
                break;
            case "Finish":
                Destroy(gameObject);
                break;
            case "Boss":
                other.GetComponent<Boss>().health--;
                Destroy(gameObject);
                break;
        }
    }
}
