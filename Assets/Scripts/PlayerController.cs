using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum State
    {
        Default = 0,
        Holding = 1,
        Released = 2,
        Hit = 3,
        Die = 4,
    }

    [SerializeField]
    State actualState;
    [SerializeField]
    float timeToCharge = 1.0f;
    int range = 0;

    [SerializeField]
    GameObject attackPrefab = null;

    [SerializeField]
    GameObject firstZone = null;
    Coroutine attack = null;

    public int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        attack = null;
        actualState = State.Default;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(attack is null) attack = StartCoroutine("LoadAttack");
        }

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(DoAttack());
        }
    }

    private IEnumerator LoadAttack()
    {
        actualState = State.Holding;
        while (actualState == State.Holding)
        {
            range++;
            Debug.Log("range: " + range);
            yield return new WaitForSeconds(timeToCharge);
        }
    }

    private Vector3 spawnAttackPos()
    {
        Vector3 pos = firstZone.transform.position;
        Vector3 add = new Vector3(0, attackPrefab.GetComponent<RectTransform>().sizeDelta[1] * (range - 1), 0);
        //Debug.Log("pos: " + pos + " | add: " + add + " | range: " + range);
        return pos + add;
    }
    private IEnumerator DoAttack()
    {
            actualState = State.Released;
            Instantiate(attackPrefab, spawnAttackPos(), Quaternion.identity);
            StopCoroutine(attack);
            attack = null;
            range = 0;
            yield return null;
            actualState = State.Default;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EnemyController>() != null)
        {
            Destroy(other.gameObject);
            lives --;
            if (lives <= 0) UnityEngine.SceneManagement.SceneManager.LoadScene("DeadScreen");
        }
    }

}
