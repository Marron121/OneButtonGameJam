using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounterController : MonoBehaviour
{
    [SerializeField]
    List<Image> heartIcons;
    [SerializeField]
    Sprite brokenHeartSprite;

    public void HeartBroken(int pos)
    {
        heartIcons[pos].sprite = brokenHeartSprite;
    }
}
