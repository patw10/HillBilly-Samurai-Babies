using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private GameObject SpawnerComponent;
    public GameObject HealthBar;
    public GameObject progresBar;
    private Spawner spawner;
    public int maximum;
    private float fillAmount;
    public Image mask;

    private void Start()
    {
        spawner = SpawnerComponent.GetComponent<Spawner>();
        mask.material.SetColor("_Color", Color.white);
    }

    private void Update()
    {
        GetCurrentFill();
        if (spawner.spawned == 100)
        {
            SpawnerComponent.SetActive(false);
            HealthBar.SetActive(true);
            progresBar.SetActive(false);
        }
    }

    private void GetCurrentFill()
    {
        fillAmount = (float)spawner.spawned / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}