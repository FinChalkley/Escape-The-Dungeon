using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingsMenu : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
