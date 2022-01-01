using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WaypointController : MonoBehaviour
{
   public float newVelocity;
   public bool changeVelocity = false;
   public bool waitHere = false;
   public float timeToWait;
   public bool shoot;
   public bool textAppear = false;

   public bool specialEffect = false;

   public GameObject text;

   public List<EnemyManager> puedeDetectar = new List<EnemyManager>();

   public void AddEnemy(EnemyManager ec){puedeDetectar.Add(ec);}

   private void OnTriggerEnter2D(Collider2D other)
   {
       if (puedeDetectar.Contains(other.GetComponent<EnemyManager>()))
       {
           if (changeVelocity)
           {
               other.GetComponent<EnemyManager>().MoveSpeed = newVelocity;
           }
           if (waitHere)
           {
               other.GetComponent<EnemyManager>().StopMovement(timeToWait);
           }
           if(shoot)
           {
               other.GetComponent<EnemyManager>().ShootBullet();
           }
           if(textAppear)
           {
               text.SetActive(true);
           }
           if(specialEffect)
           {
               other.GetComponent<EnemyManager>().LevelManager.SpecialEffect();
           }
       }
   }
}
