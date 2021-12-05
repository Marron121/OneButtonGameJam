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
        while (fadingBackground.color.a < 1.0f)
        {
            fadingBackground.color += new Color(0,0,0, fadingTime*Time.deltaTime);
            Debug.Log(fadingBackground.color);
            yield return null;
        }
    }

    virtual protected IEnumerator FadeOut()
    {
        while (fadingBackground.color.a > 0.0f)
        {
            fadingBackground.color -= new Color(0,0,0, fadingTime*Time.deltaTime);
            Debug.Log(fadingBackground.color);
            yield return null;
        }
    }
}
