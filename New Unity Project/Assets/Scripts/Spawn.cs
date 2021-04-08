using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Obs;
    public GameObject Sp;

    private void Start()
    {
        Instantiate(Obs, transform.position, Quaternion.identity);
        Destroy(Sp);
    }
}