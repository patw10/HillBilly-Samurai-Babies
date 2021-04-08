using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject progressBar;
    public GameObject Boss;
    Boss boss;
    public int maximum;
    private float fillAmount;
    public Image mask;
    void Start()
    {
        boss = Boss.GetComponent<Boss>();
    }
    void Update()
    {
        GetCurrentFill();
    }
    void GetCurrentFill()
    {
        fillAmount = (float)boss.health / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
