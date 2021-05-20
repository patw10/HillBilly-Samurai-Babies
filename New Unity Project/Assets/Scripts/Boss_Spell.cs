using UnityEngine;

public class Boss_Spell : MonoBehaviour
{
    public GameObject[] obstacle;
    public GameObject Spawn;
    private Animator anim;
    public int speed;
    private int rand1;
    private int rand2;
    private Vector2 pos;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rand1 = Random.Range(4, 10);
        rand2 = Random.Range(0, obstacle.Length);
        pos = new Vector2(rand1, -2.65f);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, pos) < 0.2f)
        {
            anim.SetTrigger("Spawn");
            Instantiate(obstacle[rand2], Spawn.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}