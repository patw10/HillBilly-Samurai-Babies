using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui_Script : MonoBehaviour
{
    [SerializeField] private GameObject SpawnerComponent;
    public GameObject PauseManu;
    public GameObject Boss;
    public GameObject HealthBar;
    public GameObject ProgresBar;
    public GameObject Player;
    public GameObject GameOver;
    public GameObject Win;
    private Control player;
    private Spawner spawner;
    private Boss boss;
    public static Ui_Script Coin;
    public Text Coin_text;
    public Image progresBar;
    public Image healthBar;
    public int score;
    public int winScore;
    public int coins;
    public float startWaitTime;
    public bool GamePaused;
    public bool GP;
    public int maximum_ProgressBar;
    private float fillAmount_ProgressBar;
    public int maximum_HealthBar;
    private float fillAmount_HealthBar;

    void Start()
    {
        if (Coin == null)
        {
            Coin = this;
        }

        GP = false;
        GamePaused = false;
        player = Player.GetComponent<Control>();
        spawner = SpawnerComponent.GetComponent<Spawner>();
        boss = Boss.GetComponent<Boss>();
    }
    void Update()
    {
        GetCurrentFill_HelathBar();
        GetCurrentFill_ProgressBar();

        var isDead = player.health == 0;
        var spawnedAll = spawner.spawned == 70;
        var gameIsWon = Player.transform.position.x >= 14;

        if (GamePaused == false)
        {
            PauseManu.SetActive(false);
            Time.timeScale = 1;
        }

        if (spawnedAll)
        {
            SpawnerComponent.SetActive(false);
            HealthBar.SetActive(true);
            ProgresBar.SetActive(false);
        }

        if (GamePaused || isDead || gameIsWon)
        {
            Time.timeScale = 0;

            if (GamePaused)
            {
                PauseManu.SetActive(true);
            }
            else if (isDead)
            {
                GameOver.SetActive(true);
            }
            else if (gameIsWon)
            {
                Win.SetActive(true);
                coins = int.Parse(File.ReadAllText(Application.persistentDataPath + "/CoinScore.txt"));
                winScore = coins + score;
            }
            else if (GamePaused && isDead)
            {
                PauseManu.SetActive(true);
                GameOver.SetActive(false);
            }

            return;
        }
        else
        {
            if (spawner.spawned < 70)
            {
                Time.timeScale = (1f + (spawner.spawned / 100f));
            }
            if (spawner.spawned == 70)
            {
                Time.timeScale = (1f + ((2.9f + boss.Bosshealth) / -7.9f + 1f));
            }
        }
    }
    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        Coin_text.text = "x " + score.ToString();
    }
    private void GetCurrentFill_HelathBar()
    {
        fillAmount_HealthBar = (float)boss.Bosshealth / (float)maximum_HealthBar;
        healthBar.fillAmount = fillAmount_HealthBar;
    }
    private void GetCurrentFill_ProgressBar()
    {
        fillAmount_ProgressBar = (float)spawner.spawned / (float)maximum_ProgressBar;
        progresBar.fillAmount = fillAmount_ProgressBar;
    }
    public void PauseGame()
    {
        GamePaused = true;
    }
    public void ResumeGame()
    {
        GamePaused = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        GamePaused = false;
    }
    public void LoadMenuWin()
    {
        SceneManager.LoadScene("Menu");
        GamePaused = false;
        File.WriteAllText(Application.persistentDataPath + "/CoinScore.txt", winScore.ToString());
    }
}
