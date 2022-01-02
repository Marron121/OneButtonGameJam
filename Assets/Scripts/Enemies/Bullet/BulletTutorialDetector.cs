using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTutorialDetector : MonoBehaviour
{
    [SerializeField]
    private bool waitHere = false;
    [SerializeField]
    private float timeToWait;
    [SerializeField]
    private bool shoot;
    [SerializeField]
    private bool changeBulletState = false;
    [SerializeField]
    private bool textAppear = false;
    [SerializeField]
    private GameObject text;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BulletController>())
        {
            if (waitHere)
            {
                other.GetComponent<BulletController>().StopMovement();
            }
            if (textAppear) text.SetActive(true);
            if (changeBulletState) other.GetComponent<BulletController>().CountAsKill = true;
        }
    }
}
