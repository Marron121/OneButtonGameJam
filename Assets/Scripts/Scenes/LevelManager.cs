using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("Transitions")]
    [SerializeField]
    Image fadingBackground;
    [SerializeField]
    float fadingTime = 0.5f;

    bool isFadingOut = false;
    bool isFadingIn = false;
    // Start is called before the first frame update
    virtual protected void Start()
    {
        StartCoroutine(FadeOut());
    }

    virtual protected void Update()
    {
        
    }

    virtual protected IEnumerator FadeIn()
    {
        isFadingIn = true;
        while (fadingBackground.color.a < 1.0f)
        {
            fadingBackground.color += new Color(0,0,0, fadingTime*Time.deltaTime);
            //Debug.Log(fadingBackground.color);
            yield return null;
        }
        isFadingIn = false;
        yield return null;
    }

    virtual protected IEnumerator FadeOut()
    {
        isFadingOut = true;
        while (fadingBackground.color.a > 0.0f)
        {
            fadingBackground.color -= new Color(0,0,0, fadingTime*Time.deltaTime);
            //Debug.Log(fadingBackground.color);
            yield return null;
        }
        isFadingOut = false;
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
        StartCoroutine(NextSceneWithFadeIn(n));
    }

    public virtual void EnemyKilled(){}
    public virtual void PlayerKilled(){}
}
