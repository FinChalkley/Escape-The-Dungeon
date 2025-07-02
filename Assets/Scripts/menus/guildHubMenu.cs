using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class guildHubMenu : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void enterDungeon()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void enterShop()
    {
          
    }
    public void enterStorage()
    {

    }
    public void SeeQuests()
    {

    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
