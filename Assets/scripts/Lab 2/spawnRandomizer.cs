using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRandomizer : MonoBehaviour
{
    public int spawnNum;
    public GameObject spawner;
    GameObject[] spawns;
    GameObject[] selectedSpawns;

    // Start is called before the first frame update
    void Start()
    {
        spawns = GameObject.FindGameObjectsWithTag("Spawner");
        selectedSpawns = new GameObject[spawnNum];

        for(int x = 0; x < spawnNum; x++)
        {
            int position = Random.Range(0, spawns.Length);
            
            for(int y = 0; y < spawnNum; y++)
            {
                if(selectedSpawns[y] == null)
                {
                    selectedSpawns[y] = spawns[position];
                    break;
                }
                else if(selectedSpawns[y] == spawns[position])
                {
                    x--;
                    break;
                }
            }
        }

        for (int z = 0; z < spawnNum; z++)
        {
            Instantiate(spawner, selectedSpawns[z].transform);
        }
    }

   
}
