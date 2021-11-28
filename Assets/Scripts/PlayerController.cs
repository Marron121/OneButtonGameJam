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

    public SpriteRenderer actualSprite;

    public Sprite[] sprites;

    [SerializeField]
    GameObject firstZone = null;
    Coroutine attack = null;

    public int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        attack = null;
        actualState = State.Default;
        actualSprite.sprite = sprites[0];
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
            if (range > 3) range = 3;
            actualSprite.sprite = sprites[range];
            yield return new WaitForSeconds(timeToCharge);
        }
        yield return null;
    }

    private Vector3 spawnAttackPos()
    {
        Vector3 pos = firstZone.transform.position;
        Vector3 add = new Vector3(0, attackPrefab.GetComponent<RectTransform>().sizeDelta[1] * (range - 1), 0);
        return pos + add;
    }
    private IEnumerator DoAttack()
    {
            actualState = State.Released;
            gameObject.GetComponent<AudioSource>().Play();
            Instantiate(attackPrefab, spawnAttackPos(), Quaternion.identity);
            StopCoroutine(attack);
            attack = null;
            range = 0;
            actualState = State.Default;
            actualSprite.sprite = sprites[0];
            yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            lives --;
            if (lives <= 0) UnityEngine.SceneManagement.SceneManager.LoadScene("DeadScreen");
            else StartCoroutine(Damaged());
        }
    }

    private IEnumerator Damaged()
    {
        actualSprite.color = new Color(1,1,1,0);
        yield return new WaitForSeconds(0.25f);
        actualSprite.color = new Color(1,1,1,1);
        yield return new WaitForSeconds(0.25f);
        actualSprite.color = new Color(1,1,1,0);
        yield return new WaitForSeconds(0.25f);
        actualSprite.color = new Color(1,1,1,1);
        yield return null;
    }

}
