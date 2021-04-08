using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacle;

    private float spawntime;
    public float spawn;
    public float decreseTime;
    public float mintime = 0.70f;
    public int spawned = 0;
    //[Range(0, 1)]
    //public float CrateChance = 0.15f;
    //[Range(0, 1)]
    //public float CoinChance = 0.05f;


    private void Update()
    {
        if (spawntime <= 0)
        {
            int rand1 = Random.Range(0, obstacle.Length);

            //if (Random.value <= CrateChance && Random.value > CoinChance)
            //{
            //    Instantiate(obstacle[3], transform.position, Quaternion.identity);
            //}
            //if (Random.value <= CoinChance)
            //{
            //    Instantiate(obstacle[rand2], transform.position, Quaternion.identity);
            //}
            //if (Random.value <= 0.8)
            //{
            Instantiate(obstacle[rand1], transform.position, Quaternion.identity);
            //}
            spawntime = spawn;
            if (spawn > mintime)
            {
                spawn -= decreseTime;
            }
            if (spawned != 100 && obstacle[rand1] != obstacle[3] && obstacle[rand1] != obstacle[4] && obstacle[rand1] != obstacle[5])
            {
                spawned += 1;
            }
        }
        else
        {
            spawntime -= Time.deltaTime;
        }
    }
}
