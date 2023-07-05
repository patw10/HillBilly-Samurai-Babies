using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!File.Exists(Application.persistentDataPath + "/CoinScore.txt"))
        {
            File.WriteAllText(Application.persistentDataPath + "/CoinScore.txt", "0");
        }
        SceneManager.LoadScene("Menu");
    }
}
