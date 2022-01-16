using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackController : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;
    public LevelManager LevelManager
    {
        set{levelManager = value;}
    }
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private BoxCollider2D collider;
    [SerializeField]
    private SpriteRenderer image;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Despawn());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy" && !col.name.Contains("EnemyFinal"))
        {
            Destroy(col.gameObject);
            if (col.GetComponent<EnemyManager>() || col.GetComponent<BulletController>().CountAsKill) levelManager.EnemyKilled();
        }

    }
    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(0.1f);
        collider.enabled = false;
        image.sprite = null;
        yield return new WaitForSeconds(audio.clip.length-0.1f);
        Destroy(gameObject);
    }
}
