using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckEnemies());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy") Destroy(col.gameObject);
    }
    private IEnumerator CheckEnemies()
    {
        /*
        Collider2D [] colliders = new Collider2D[3];
        this.GetComponent<BoxCollider2D>().GetContacts(colliders);
        foreach(Collider2D col in colliders)
        {
            Debug.Log(col);
            if (col != null && col.gameObject.GetComponent<EnemyController>()) Destroy(col);
        }
        */
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
