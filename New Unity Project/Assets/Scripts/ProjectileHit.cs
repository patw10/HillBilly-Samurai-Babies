using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
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
