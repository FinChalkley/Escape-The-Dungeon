using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShootingAi : MonoBehaviour
{
    public int Health;
    //public GameObject lootBox;
    //[HideInInspector] public lootBox box;
    //[HideInInspector] public enemyCreation enemy;

    private void Start()
    {
        //box = FindObjectOfType<lootBox>();
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine(Health);
        Despawn();
    }

    private void Despawn()
    {
        if (Health <= 0)
        {
            //spawn lootbox
            //enemy = GetComponent<enemyCreation>();
            //lootBox.GetComponent<lootBox>().items = new List<GameObject>(enemy.enemyItems);
            //Debug.Log(enemy.enemyItems.Count);
            //GameObject spawnedLootBox = Instantiate(lootBox, transform.position, Quaternion.identity);
            //remove object
            Destroy(gameObject);
        }
    }
}
