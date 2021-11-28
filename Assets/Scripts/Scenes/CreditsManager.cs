using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : SceneController
{
    public List<GameObject> texts = new List<GameObject>();
    public float speed;
    public int actualText = 0;
    public SpriteRenderer actualSprite;
    public Sprite[] sprites;

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
        yield return null;
    }
}
