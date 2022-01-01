using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    [SerializeField]
    int indicator;
    [SerializeField]
    List<EnemyManager> enemiesInZone;
    // Start is called before the first frame update
    void Start()
    {
        enemiesInZone = new List<EnemyManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<EnemyManager>())
        {
            //Debug.Log("Enemy entered zone " + indicator);
            enemiesInZone.Add(col.gameObject.GetComponent<EnemyManager>());
        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<EnemyManager>())
        {
            //Debug.Log("Enemy exit zone " + indicator);
            enemiesInZone.Remove(col.gameObject.GetComponent<EnemyManager>());
        }
    }
}
