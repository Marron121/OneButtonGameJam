using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 5;
    void Update()
    {
        transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
    }
}
