using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
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
                other.GetComponent<SwipeJump>().health = 0;
                break;
        }
    }
}
