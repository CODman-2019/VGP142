using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public bool X, Y, Z;
    public float speed;


    // Update is called once per frame
    void Update()
    {
        if (X)
        {
            transform.Translate(new Vector3(Time.deltaTime * speed, 0, 0));
        }
        if (Y)
        {
            transform.Translate(new Vector3(0, Time.deltaTime * speed, 0));
        }
        if (Z)
        {
            transform.Translate(new Vector3(0, 0, Time.deltaTime * speed));
        }
    }
}
