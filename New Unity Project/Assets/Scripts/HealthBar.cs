using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject progressBar;
    public GameObject Boss;
    private Boss boss;
    public int maximum;
    private float fillAmount;
    public Image mask;

    private void Start()
    {
        boss = Boss.GetComponent<Boss>();
    }

    private void Update()
    {
        GetCurrentFill();
    }

    private void GetCurrentFill()
    {
        fillAmount = (float)boss.health / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}