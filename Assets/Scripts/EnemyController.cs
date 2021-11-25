using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    List<Transform> directions;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = directions[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move(){}

}
