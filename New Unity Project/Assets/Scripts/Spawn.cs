using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Obs;
    public GameObject Sp;
    void Start()
    {
        Instantiate(Obs, transform.position, Quaternion.identity);
        Destroy(Sp);
    }
}
