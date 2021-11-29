using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalStandController : MonoBehaviour
{
    public Nivel3Manager manager;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EnemyFinalController>())
        {
            manager.EnemyWentThroughSignal();
        }
    }
}
