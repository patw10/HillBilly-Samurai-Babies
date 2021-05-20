using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PlayMenu;
    public GameObject ShopMenu;

    private void Start()
    {
        MainMenu.SetActive(true);
        PlayMenu.SetActive(false);
        ShopMenu.SetActive(false);
    }
    void Update()
    {
        
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
}
