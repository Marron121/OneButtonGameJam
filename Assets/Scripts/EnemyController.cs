using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<Transform> directions;

    public SpriteRenderer actualSprite;
    public Sprite[] sprites;
    public bool canShoot;

    public float moveSpeed = 2f;

    private bool canMove = true;

    private int waypointIndex = 0;

    public GameObject bullet;

    public void ActivateEnemy()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = directions[0].position;
        StartCoroutine("Moving");
        if (!canShoot)StartCoroutine(Animation(1));
    }

    private IEnumerator Moving()
    {
        while (true){Move();}
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
        if (waypointIndex <= directions.Count - 1 && canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position,
               directions[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);
            if (transform.position == directions[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
        else if (waypointIndex > directions.Count -1)
        {
            Destroy(this.gameObject);
        }
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

    public void ShootBullet()
    {
        if (canShoot)
        {
            actualSprite.sprite = sprites[1];
            Instantiate(bullet, transform.position, transform.rotation);
            StartCoroutine("ResetSprite");
        }
    }

    private IEnumerator ResetSprite()
    {
        yield return new WaitForSeconds(0.5f);
        actualSprite.sprite = sprites[0];
        yield return null;
    }

}
