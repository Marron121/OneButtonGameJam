using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("Transitions")]
    [SerializeField]
    protected Image fadingBackground;
    [SerializeField]
    protected float fadingTime = 0.5f;

    bool isFadingOut = false;
    bool isFadingIn = false;

    bool loading = false;

    [Header("Player")]
    [SerializeField]
    Animator player; 

    [Header("Combat")]
    [SerializeField]
    protected List<GameObject> enemies;
    [SerializeField]
    protected List<float> spawnTimes;

    [SerializeField]
    protected List<GameObject> paths;
    protected int killedEnemies = 0;
    // Start is called before the first frame update
    virtual protected void Start()
    {
        StartCoroutine(FadeOut());
        if (player != null) StartCoroutine(EnterPlayer());
    }

    virtual protected void Update()
    {
        
    }

    virtual protected IEnumerator FadeIn()
    {
        if (player != null) StartCoroutine(LeavePlayer());
        isFadingIn = true;
        while (fadingBackground.color.a < 1.0f)
        {
            fadingBackground.color += new Color(0,0,0, fadingTime*Time.deltaTime);
            yield return null;
        }
        isFadingIn = false;
        yield return null;
    }

    private IEnumerator EnterPlayer()
    {
        yield return new WaitWhile(() => isFadingOut);
        player.SetBool("enter", true);
    }

    private IEnumerator LeavePlayer()
    {
        player.SetBool("leave", true);
        yield return null;
    }
    virtual protected IEnumerator FadeOut()
    {
        isFadingOut = true;
        while (fadingBackground.color.a > 0.0f)
        {
            fadingBackground.color -= new Color(0,0,0, fadingTime*Time.deltaTime);
            yield return null;
        }
        isFadingOut = false;
        fadingBackground.raycastTarget = false;
        yield return null;
    }

    protected virtual IEnumerator NextSceneWithFadeIn(string n)
    {
        StartCoroutine(FadeIn());
        yield return new WaitUntil(() => !isFadingIn);
        UnityEngine.SceneManagement.SceneManager.LoadScene(n);
    }
    public virtual void LoadScene(string n)
    {
        if (!loading)
        {
            loading = true;
            StartCoroutine(NextSceneWithFadeIn(n));
        }
    }

    public virtual void EnemyKilled(){}
    public virtual void PlayerKilled(){}
    public virtual void SpecialEffect(){}
}
