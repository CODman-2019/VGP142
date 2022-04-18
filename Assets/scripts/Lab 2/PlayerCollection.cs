using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    public int pickupsNeeded;
    int pickupCount = 0;
    void Update()
    {
        try
        {
            checkPickups();
        }
        catch (ArgumentNullException e)
        {
            Debug.LogWarning("Pick ups aquired");
        }
        catch(NotImplementedException e)
        {
            Debug.LogWarning("Pick ups error");
        }
    }

    void checkPickups()
    {
        if(pickupCount == pickupsNeeded)
        {
            throw new ArgumentNullException("pickups aquired");

        }


        if (pickupCount > pickupsNeeded)
        {
            throw new NotImplementedException();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Collectable"))
        {
            pickupCount++;
            Destroy(collision.gameObject);
            Debug.Log(pickupCount);
        }
    }
}
