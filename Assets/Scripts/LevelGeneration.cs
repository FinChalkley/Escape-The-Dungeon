using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Threading;


public class LevelGeneration : MonoBehaviour
{
    public List<GameObject> roomPrefabs;

    GameObject currentRoom;
    GameObject oldRoom;
    GameObject evenOlderRoom;

    bool isNorth;
    bool isWest;
    int olderCount = 0;

    List<GameObject> madeRooms = new List<GameObject>();


    System.Random rng = new System.Random();

    private void createDoors()
    {
        //checking if there is ajoining rooms
        if (oldRoom == null)
        {
            oldRoom = currentRoom;
            // Only add the first room once
            madeRooms.Add(currentRoom);
            return;
        }

        if (isNorth == true)
        {
            //deciding how many path ways to have
            int southDoorCount = rng.Next(1, 4);

            List<int> removed = new List<int>();
            for (int i = 0; i < southDoorCount; i++)
            {
                int doorToRemove;
                do
                {
                    doorToRemove = rng.Next(1, 11); 
                } while (removed.Contains(doorToRemove));
                removed.Add(doorToRemove);

                string removal = doorToRemove.ToString();
                RemoveGrandchildWithTag(currentRoom, "South", removal);
                RemoveGrandchildWithTag(oldRoom, "North", removal);
            }
        }
        if (isWest == true)
        {
            
            //deciding how many path ways to have
            int westDoorCount = rng.Next(1, 4);

            List<int> removed = new List<int>();
            for (int i = 0; i < westDoorCount; i++)
            {
                int doorToRemove;
                do
                {
                    doorToRemove = rng.Next(1, 11);
                } while (removed.Contains(doorToRemove));
                removed.Add(doorToRemove);

                string removal = doorToRemove.ToString();
                RemoveGrandchildWithTag(currentRoom, "East", removal);
                RemoveGrandchildWithTag(evenOlderRoom, "West", removal);
            }
            olderCount++;
        }




        //setting rooms to a list
        madeRooms.Add(currentRoom);

        oldRoom = currentRoom;
        evenOlderRoom = madeRooms[olderCount];
    }


    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (j >= 1)
                {
                    isNorth = true;
                }
                else
                {
                    isNorth = false;
                }
                if (i >= 1)
                {
                    isWest = true;
                }
                else
                {
                    isWest = false;
                }
                currentRoom = Instantiate(roomPrefabs[rng.Next(0, roomPrefabs.Count)]);
                createDoors();
                
            }
        }

        int count = 0;
        int roomSize = 50;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                madeRooms[count].transform.position = new Vector3(j * roomSize, 0, i * roomSize);
                madeRooms[count].transform.rotation = Quaternion.identity;
                madeRooms[count].SetActive(true);
                count++;
            }
        }
    }

    private void RemoveGrandchildWithTag(GameObject parent, string tag1, string tag2)
    {
        foreach (Transform child in parent.transform)
        {
            if (!child.CompareTag(tag1))
            {
                continue;
            }
            foreach (Transform grandchild in child)
            {
                if (grandchild.CompareTag(tag2))
                {
                    // Only destroy if the object is not an asset
                    if (Application.isPlaying)
                    {
                        GameObject.Destroy(grandchild.gameObject);
                    }
                    return; // Remove this if you want to delete all matching grandchildren
                }
            }
        }
    }
}
