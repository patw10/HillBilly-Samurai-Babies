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
    private Spawner spawner;

    private void Start()
    {
        anim = GetComponent<Animator>();
        spawner = Spawner.GetComponent<Spawner>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    private void Update()
    {
        if (spawner.spawned == 100)
        {
            switch (spell)
            {
                default:
                    Fight();
                    break;

                case 5:
                    transform.position = Vector2.MoveTowards(transform.position, Killspot.position, speed * Time.deltaTime);
                    break;

                case 11:
                    transform.position = Vector2.MoveTowards(transform.position, Killspot.position, speed * Time.deltaTime);
                    break;

                case 17:
                    transform.position = Vector2.MoveTowards(transform.position, Killspot.position, speed * Time.deltaTime);
                    break;

                case 23:
                    transform.position = Vector2.MoveTowards(transform.position, Killspot.position, speed * Time.deltaTime);
                    break;

                case 29:
                    transform.position = Vector2.MoveTowards(transform.position, Killspot.position, speed * Time.deltaTime);
                    break;
            }
        }
        if (health == 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void Fight()
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