using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private bool move = true;
    [SerializeField]
    [Tooltip("If true, +1 to enemiesKilled.")]
    private bool countAsKill = false;
    public bool CountAsKill
    {
        set { countAsKill = value; }
        get { return countAsKill; }
    }
    void Update()
    {
        if (move) transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
    }
    public void StopMovement() { move = false; }
}
