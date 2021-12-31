using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;
    public LevelManager LevelManager
    {
        set{levelManager = value;}
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Despawn());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy" && !col.GetComponent<EnemyFinalController>())
        {
            Destroy(col.gameObject);
            if (col.GetComponent<EnemyManager>()) levelManager.EnemyKilled();
        }

    }
    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
