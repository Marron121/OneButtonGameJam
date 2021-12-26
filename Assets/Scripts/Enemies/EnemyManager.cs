using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    protected List<Transform> directions;
    public List<Transform> Directions
    {
        get { return directions; }
        set { directions = value; }
    }
    [SerializeField]
    protected int waypointIndex = 0;

    [SerializeField]
    protected float moveSpeed = 2.0f;
    public float MoveSpeed
    {
        set { moveSpeed = value; }
    }

    [SerializeField]
    protected SpriteRenderer actSprite;
    [SerializeField]
    protected Sprite[] sprites;

    [Header("Actions")]
    [SerializeField]
    protected bool canShoot;
    [SerializeField]
    protected bool canMove;

    [Header("Others")]
    [SerializeField]
    protected GameObject bullet;

    [SerializeField]
    protected LevelManager levelManager;

    public LevelManager LevelManager
    {
        get{return levelManager;}
        set{levelManager = value;}
    }
    public void ActivateEnemy()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = directions[0].position;
        StartCoroutine(Animation(1));
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        if (canMove)
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
            else if (waypointIndex > directions.Count - 1)
            {
                Destroy(gameObject);
            }
        }
    }

    virtual protected IEnumerator Animation(int i)
    {
        yield return new WaitForSeconds(0.5f);
        actSprite.sprite = sprites[i];
        i++;
        if (i > 1) i = 0;
        StartCoroutine(Animation(i));
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
            Instantiate(bullet, transform.position, transform.rotation);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
