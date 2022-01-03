using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : LevelManager
{
    [SerializeField]
    private List<GameObject> texts = new List<GameObject>();
    [SerializeField]
    private float speed;
    [SerializeField]
    private int actualText = 0;
    [SerializeField]
    private List<Image> hands;
    [SerializeField]
    private GameObject button;

    public void UpdateText()
    {
        texts[actualText].SetActive(false);
        actualText++;
        if (actualText == 2)
        {
            StartCoroutine(DisplayMessage());
            Destroy(button);
        }
        else texts[actualText].SetActive(true);
    }

    IEnumerator DisplayMessage()
    {
        if (actualText > texts.Count -1)
        {
            yield return new WaitForSeconds(5.0f);
            base.LoadScene("StartScene");
        }
        else
        {
            Image image = null;
            int color = 1;
            switch (actualText)
            {
                case 2:
                    image = hands[0];
                    break;
                case 3:
                    image = hands[1];
                    break;
                case 5:
                    image = hands[2];
                    break;
                case 9:
                    image = hands[3];
                    color = 0;
                    break;
            }
            if (image != null)
                StartCoroutine(FadeBackground(1.0f, 1.5f, color, image));
            int pos = -100;
            if (actualText == 9)
                pos = 240;
            StartCoroutine(MoveText(texts[actualText], pos));
        }
    }

    IEnumerator MoveText(GameObject t, int yPos)
    {
        bool sent = false;
        while (t.transform.position.y > yPos)
        {
            t.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            if (t.transform.position.y <= 240 && !sent)
            {
                actualText++;
                StartCoroutine(DisplayMessage());
                sent = true;
            }
            yield return null;
        }
        yield return null;
    }

    IEnumerator FadeBackground(float aValue, float aTime, int c, Image i)
    {
        float alpha = i.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(c, c, c, Mathf.Lerp(alpha, aValue, t));
            i.color = newColor;
            yield return null;
        }
    }
}
