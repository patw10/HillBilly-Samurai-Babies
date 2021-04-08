using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Coin : MonoBehaviour
{
    public static Ui_Coin instance;
    public Text text;
    int score;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = "x " + score.ToString();
    }
}
