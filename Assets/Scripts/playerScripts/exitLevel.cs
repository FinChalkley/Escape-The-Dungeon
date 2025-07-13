using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitLevel : MonoBehaviour
{

    public Camera fpsCam;
    public RaycastHit rayHit;
    public LayerMask whatIsExit;
    //[HideInInspector] public PlayerDataManager save;

    int range = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && IsExitInRange() == true)
        {
            //save = FindAnyObjectByType<PlayerDataManager>();
            //save.SaveGame();
            SceneManager.LoadSceneAsync(2);
        }
    }

    private bool IsExitInRange()
    {
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, range, whatIsExit))
        {
            Debug.Log("true");
            return true;
        }
        else
        {
            Debug.Log("false");
            return false;
        }
    }
}
