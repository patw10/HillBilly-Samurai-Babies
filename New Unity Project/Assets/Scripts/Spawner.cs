using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacle;
    private float spawntime;
    public float spawn;
    public float decreseTime;
    public float mintime = 0.80f;
    public int spawned = 0;

    private void Update()
    {
        if (spawntime <= 0)
        {
            int rand1 = Random.Range(0, obstacle.Length);
            Instantiate(obstacle[rand1], transform.position, Quaternion.identity);
            spawntime = spawn;
            if (spawn > mintime)
            {
                spawn -= decreseTime;
            }
            if (spawned != 70 && obstacle[rand1] != obstacle[4] && obstacle[rand1] != obstacle[5])
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
