using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<Transform> directions;
    public bool canShoot;

    public float moveSpeed = 2f;

    private bool canMove = true;

    private int waypointIndex = 0;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = directions[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }

}
