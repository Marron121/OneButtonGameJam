using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raton : MonoBehaviour
{
    public Image image;
    public Sprite[] sprites;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CambiarIcono());
    }

    IEnumerator CambiarIcono()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            i++;
            if (i > 1) i = 0;
            image.sprite = sprites[i];
        }
    }
}
