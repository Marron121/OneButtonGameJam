using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : SceneController
{
    public GameObject background2;
    public Image flashofWhite;

    public void Restart()
    {
        background2.SetActive(true);
        StartCoroutine(FadeBackground(1.0f, 2.0f, flashofWhite));
    }

    IEnumerator FadeBackground(float aValue, float aTime, Image i)
    {
        gameObject.GetComponent<AudioSource>().Play();
        float alpha = i.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            i.color = newColor;
            yield return null;
        }
        base.LoadScene("Nivel1");
    }
}
