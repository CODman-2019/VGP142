using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooAI : MonoBehaviour
{
    enum states
    {
        moving,
        stopping
    };

    public GameObject projectile;
    public GameObject skin;
    public Transform player, playerEyes, projectileEntryPoint;
    public float speed, detectionDistance, stopDistance, shotTimer;
    public LayerMask AI;
    Vector3 direction;
    RaycastHit hit;

    float shotTimeCounter = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        direction.x = transform.rotation.x;
        direction.y = transform.rotation.y;
        direction.z = transform.rotation.z;
        //Debug.DrawRay(playerEyes.position, playerEyes.forward, Color.green);
        //if (Time.time > shotTimer + shotTimeCounter)
        //{
        //    shotTimeCounter += shotTimer;
        //}

        if (Physics.Raycast(player.position, playerEyes.forward, out hit, detectionDistance, AI.value))
        {
            if (skin.active)
            {
                skin.SetActive(false);
            }
            //Debug.Log(hit);
        }
        else
        {
            if (!skin.active)
            {
                skin.SetActive(true);
            }
            // Debug.Log("missed");
            if(Vector3.Distance(transform.position, player.position) > stopDistance)
            {
                transform.Translate(new Vector3(0, 0, (Time.deltaTime * speed)));
            }

            if (Time.time > shotTimer + shotTimeCounter)
            {
                StartCoroutine(FireBall());
                shotTimeCounter += shotTimer;
            }
            
        }
    }

    IEnumerator FireBall()
    {
        Debug.Log("shot set up");
        yield return new WaitForSeconds(shotTimer);
        Instantiate(projectile, projectileEntryPoint);
        Debug.Log("");
        Debug.Log("shot fired");
        projectileEntryPoint.DetachChildren();
    }
}
