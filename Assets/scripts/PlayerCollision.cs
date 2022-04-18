using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject[] chests;
    public Text txt;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }   
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Collectable")
        {
            other.gameObject.SetActive(false);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            bool missed = false;
            foreach(GameObject chest in chests)
            {
                if(chest.active)
                {
                    missed = true;
                }
            }

            if (missed)
            {
                txt.text = "COLLECT ALL THE CHESTS TO ESCAPE. LOOK FOR THE BEACONS";
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }

    }
}
