using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] GameObject SpawnerComponent;
    public GameObject HealthBar;
    public GameObject progresBar;
    Spawner spawner;
    public int maximum;
    private float fillAmount;
    public Image mask;
    void Start()
    {
        spawner = SpawnerComponent.GetComponent<Spawner>();
        mask.material.SetColor("_Color", Color.white);
    }
    void Update()
    {
        GetCurrentFill();
        if (spawner.spawned == 100)
        {
            SpawnerComponent.SetActive(false);
            HealthBar.SetActive(true);
            progresBar.SetActive(false);
        }
    }
    void GetCurrentFill()
    {
        fillAmount = (float)spawner.spawned / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
