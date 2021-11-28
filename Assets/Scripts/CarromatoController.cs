using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarromatoController : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer actualSprite;
    public int spriteIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        actualSprite.sprite = sprites[0];
        StartCoroutine(ChangeSprite());
    }

    private IEnumerator ChangeSprite()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            spriteIndex++;
            if (spriteIndex > sprites.Length-1) spriteIndex = 0;
            actualSprite.sprite = sprites[spriteIndex];
        }
    }
}
