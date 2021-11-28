using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
   public float newVelocity;
   public bool changeVelocity = false;
   public bool waitHere = false;
   public float timeToWait;
   public bool shoot;

   public List<EnemyController> puedeDetectar = new List<EnemyController>();

   public void AddEnemy(EnemyController ec){puedeDetectar.Add(ec);}

   private void OnTriggerEnter2D(Collider2D other)
   {
       if (puedeDetectar.Contains(other.GetComponent<EnemyController>()))
       {
           if (changeVelocity)
           {
               other.GetComponent<EnemyController>().moveSpeed = newVelocity;
           }
           if (waitHere)
           {
               other.GetComponent<EnemyController>().StopMovement(timeToWait);
           }
           if(shoot)
           {
               other.GetComponent<EnemyController>().ShootBullet();
           }
       }
   }
}
