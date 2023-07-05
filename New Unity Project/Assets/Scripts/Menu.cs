using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PlayMenu;
    public GameObject ShopMenu;
    public TextMeshProUGUI Score_Text;
    public TextMeshProUGUI test;
    public string scoreBefore;

    public void Start()
    {
        Time.timeScale = 1;
        MainMenu.SetActive(true);
        PlayMenu.SetActive(false);
        // ShopMenu.SetActive(false);
    }
    void Update()
    {
        Score();
      // test.text = File.ReadAllText(Application.persistentDataPath + "/CoinScore.txt");
    }
    public void OpenPlayMenu()
    {
        MainMenu.SetActive(false);
        PlayMenu.SetActive(true);
        ShopMenu.SetActive(false);
    }
    public void OpenShopMenu()
    {
        MainMenu.SetActive(false);
        PlayMenu.SetActive(false);
        ShopMenu.SetActive(true);
    }
    public void OpenMainMenu()
    {
        MainMenu.SetActive(true);
        PlayMenu.SetActive(false);
        ShopMenu.SetActive(false);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Score()
    {
        if (!File.Exists(Application.persistentDataPath + "/CoinScore.txt"))
        {
            File.WriteAllText(Application.persistentDataPath + "/CoinScore.txt", "0");
            scoreBefore = File.ReadAllText(Application.persistentDataPath + "/CoinScore.txt");
        }

        if (File.ReadAllText(Application.persistentDataPath + "/CoinScore.txt") == "0")
        {
            File.WriteAllText(Application.persistentDataPath + "/CoinScore.txt", "0");
        }
        else
        {
            scoreBefore = File.ReadAllText(Application.persistentDataPath + "/CoinScore.txt");
        }

        Score_Text.text = "Coins : " + scoreBefore;
    }
}
