using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCoins : MonoBehaviour
{
    private string filePath;
    void Start()
    {
       filePath = Application.persistentDataPath + "/settings.txt";
    }

}
