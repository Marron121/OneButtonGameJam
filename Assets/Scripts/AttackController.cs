using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public string currentScene;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        StartCoroutine(Despawn());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy" && !col.GetComponent<EnemyFinalController>())
        {
            Destroy(col.gameObject);
            if (currentScene == "Tutorial") FindObjectOfType<TutoManager>().EnemyKilled();
            else if (currentScene == "Nivel1" && col.GetComponent<EnemyController>() != null)
            {
                FindObjectOfType<Nivel1Manager>().EnemyDefeated();
            }
        }

    }
    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
