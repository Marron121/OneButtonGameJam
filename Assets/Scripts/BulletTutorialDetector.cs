using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTutorialDetector : MonoBehaviour
{
    public bool waitHere = false;
   public float timeToWait;
   public bool shoot;

   public bool textAppear = false;

   public GameObject text;
   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.GetComponent<BulletController>())
       {
           if (waitHere)
           {
               other.GetComponent<BulletController>().StopMovement();
           }
           if(textAppear) text.SetActive(true);
       }
   }
}
