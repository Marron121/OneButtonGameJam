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
    private LifeCounterController lifeCounter;

    [Header("Sounds")]
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip playerDie;
    //Others
    private Coroutine attack;
    [SerializeField]
    private LevelManager currentLevelManager;

    [SerializeField]
    private CameraShake shake;

    private bool dying = false;


    // Start is called before the first frame update
    void Start()
    {
        attack = null;
        actSprite.sprite = sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!dying)
        {
            if (Input.GetMouseButton(0))
            {
                if (shake != null) shake.StartCharge();
                if (attack is null) attack = StartCoroutine("LoadAttack");
            }

            if (Input.GetMouseButtonUp(0))
            {
                StartCoroutine(DoAttack());
            }
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
        GameObject atk = Instantiate(attackPrefab, spawnAttackPos(), Quaternion.identity);
        atk.GetComponent<AttackController>().LevelManager = currentLevelManager;
        StopCoroutine(attack);
        attack = null;
        rangeOfAttack = 0;
        actSprite.sprite = sprites[0];
        if (shake != null) shake.Attack();
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (other.GetComponent<EnemyManager>()) currentLevelManager.EnemyKilled();
            Destroy(other.gameObject);
            lives--;
            if (lives <= 0 && !dying)
            {
                dying = true;
                currentLevelManager.PlayerKilled();
                audioSource.clip = playerDie;
            }
            else
            {
                StartCoroutine(Damaged());
            }
            audioSource.Play();
            if (lifeCounter != null && lives >= 0) lifeCounter.HeartBroken(lives);
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
