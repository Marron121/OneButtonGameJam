using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinalController : MonoBehaviour
{

    public SpriteRenderer actualSprite;
    public Sprite[] sprites;

    public float moveSpeed = 3f;

    private bool canMove = true;

    private int waypointIndex = 0;
    string sceneName;

    public void ActivateEnemy()
    {
        gameObject.SetActive(true);
        sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        StartCoroutine("Moving");
        StartCoroutine(Animation(1));
    }

    private IEnumerator Moving()
    {
        while (true){Move(); yield return null;}
    }

    private IEnumerator Animation(int i)
    {
        yield return new WaitForSeconds(0.5f);
        actualSprite.sprite = sprites[i];
        i++;
        if (i > 1) i = 0;
        StartCoroutine(Animation(i));
        yield return null;
    }

    // Method that actually make Enemy walk
    private void Move()
    {
        transform.position -= new Vector3(0, moveSpeed*Time.deltaTime, 0);
    }

    public void StopMovement(float t)
    {
        StartCoroutine(StopForATime(t));
    }

    private IEnumerator StopForATime(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }

    private IEnumerator ResetSprite()
    {
        yield return new WaitForSeconds(0.5f);
        actualSprite.sprite = sprites[0];
        yield return null;
    }
}
