using System.Collections;
using System.Collections.Generic;
//using System.Security.Cryptography;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class enemyCreation : MonoBehaviour
{
    public List<GameObject> gunsList;
    public List<GameObject> armorList;
    public List<GameObject> itemList;
    public List<GameObject> enemyItems;
    private System.Random rng = new System.Random();

    // Start is called before the first frame update
    public void CreateEnemy()
    {
        int HowManyItems = rng.Next(0, 6);
        List<GameObject> myList;

        for(int i = 0; i < HowManyItems; i++)
        {
            int choise = rng.Next(0, 3);
            switch (choise)
            {
                case 0:
                    myList = gunsList;
                    break;
                case 1:
                    myList = armorList;
                    break;
                case 2:
                    myList = itemList;
                    break;
                default:
                    myList = itemList;
                    break;
            }

            enemyItems.Add(myList[rng.Next(myList.Count)]);
        }
        //Debug.Log("Items added to enemy: " + enemyItems.Count);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
