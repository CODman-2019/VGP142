using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] pickups;
    MeshFilter mFilter;
    MeshRenderer mRenderer;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(pickups[Random.Range(0, pickups.Length)], this.transform);
    }

}
