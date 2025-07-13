using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 5;

    private void Update()
    {
        if (health <= 0.0f)
        {
            SceneManager.LoadSceneAsync(2);
        }
    }
    public void playerDie()
    {
        health = 0.0f;

    }
}
