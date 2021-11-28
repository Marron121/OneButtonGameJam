using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : SceneController
{
    public List<GameObject> texts = new List<GameObject>();
    public float speed;
    public int actualText = 0;
    public List<Image> backgrounds;

    private void Start()
    {
        texts[0].SetActive(true);
    }

    public void UpdateText()
    {
        texts[actualText].SetActive(false);
        actualText++;
        if (actualText == 2) StartCoroutine(DisplayMessage());
        else texts[actualText].SetActive(true);
    }

    IEnumerator DisplayMessage()
    {
        if (actualText > texts.Count-1)
        {
            yield return new WaitForSeconds(10.0f);
            base.LoadScene("StartScene");
        }
        else
        {
            texts[actualText].SetActive(true);
            StartCoroutine(MoveText(texts[actualText]));
            if (actualText == 2) StartCoroutine(FadeBackground(1.0f, 1.0f, backgrounds[1]));
            if (actualText == 3) StartCoroutine(FadeBackground(1.0f, 1.0f, backgrounds[2]));
            
            actualText++;
            yield return new WaitForSeconds(4.0f);
            StartCoroutine(DisplayMessage());
        }
    }

    IEnumerator MoveText(GameObject t)
    {
        while (t.transform.position.y > -400)
        {
            t.transform.position += new Vector3 (0, -speed*Time.deltaTime, 0);
            yield return null;
        }
        yield return null;
    }

    IEnumerator FadeBackground(float aValue, float aTime, Image i)
    {
        float alpha = i.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            i.color = newColor;
            yield return null;
        }
    }
}
