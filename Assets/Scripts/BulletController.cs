using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 5;
    bool move = true;
    void Update()
    {
        if (move)transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
    }

    public void StopMovement(){move = false;}
}
