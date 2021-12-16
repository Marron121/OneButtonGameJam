using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField]
    private SpriteRenderer actSprite;
    [SerializeField]
    private Sprite[] sprites;

    [Header("Attack")]
    [SerializeField]
    private float timeToCharge = 0.5f;
    [SerializeField]
    private GameObject attackPrefab;

    [SerializeField]
    private GameObject firstZone;
    private int rangeOfAttack = 0;

    [Header("Health")]
    [SerializeField]
    private int lives = 3;
    [SerializeField]
    private GameObject lifeCounter;

    //Others
    private Coroutine attack;


    // Start is called before the first frame update
    void Start()
    {
        attack = null;
        actSprite.sprite = sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (attack is null) attack = StartCoroutine("LoadAttack");
        }

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(DoAttack());
        }
    }
    private IEnumerator LoadAttack()
    {
        while (true)
        {
            rangeOfAttack++;
            if (rangeOfAttack > 3) rangeOfAttack = 3;
            actSprite.sprite = sprites[rangeOfAttack];
            yield return new WaitForSeconds(timeToCharge);
        }
    }

    private Vector3 spawnAttackPos()
    {
        Vector3 pos = firstZone.transform.position;
        Vector3 add = new Vector3(0, attackPrefab.GetComponent<RectTransform>().sizeDelta[1] * (rangeOfAttack - 1), 0);
        return pos + add;
    }
    private IEnumerator DoAttack()
    {
        StopCoroutine(LoadAttack());
        gameObject.GetComponent<AudioSource>().Play();
        Instantiate(attackPrefab, spawnAttackPos(), Quaternion.identity);
        StopCoroutine(attack);
        attack = null;
        rangeOfAttack = 0;
        actSprite.sprite = sprites[0];
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            lives--;
            if (lives <= 0)
            {
                //sceneController.LoadScene("DeadScreen");
            }
            else StartCoroutine(Damaged());
        }
    }

    private IEnumerator Damaged()
    {
        actSprite.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.25f);
        actSprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.25f);
        actSprite.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.25f);
        actSprite.color = new Color(1, 1, 1, 1);
        yield return null;
    }
}
