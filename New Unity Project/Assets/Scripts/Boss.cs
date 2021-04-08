using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health;
    public float speed;
    public int spell = 0;
    private float waitTime;
    public float startWaitTime;
    private int randomSpot;
    private Animator anim;
    public Transform[] moveSpots;
    public Transform Killspot;
    public GameObject Spawner;
    public GameObject Spell;
    public GameObject SpellSpawner;
    Spawner spawner;
    void Start()
    {
        anim = GetComponent<Animator>();
        spawner = Spawner.GetComponent<Spawner>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }
    void Update()
    {
        
        if (spawner.spawned == 100 && spell != 1 && spell != 4 && spell != 7 && spell != 10 && spell != 13)
        {
            Fight();
        }
        if (spawner.spawned == 100 && spell == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, Killspot.position, speed * Time.deltaTime);
        }
        if (spawner.spawned == 100 && spell == 4)
        {
            transform.position = Vector2.MoveTowards(transform.position, Killspot.position, speed * Time.deltaTime);
        }
        if (spawner.spawned == 100 && spell == 7)
        {
            transform.position = Vector2.MoveTowards(transform.position, Killspot.position, speed * Time.deltaTime);
        }
        if (spawner.spawned == 100 && spell == 10)
        {
            transform.position = Vector2.MoveTowards(transform.position, Killspot.position, speed * Time.deltaTime);
        }
        if (spawner.spawned == 100 && spell == 13)
        {
            transform.position = Vector2.MoveTowards(transform.position, Killspot.position, speed * Time.deltaTime);
        }
        if (health == 0)
        {
            gameObject.SetActive(false);
        }
    }
    void Fight()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                anim.SetTrigger("Attack");
                Instantiate(Spell, SpellSpawner.transform.position, Quaternion.identity);
                spell++;
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Projectile":
                spell++;
                break;
        }
    }
}
