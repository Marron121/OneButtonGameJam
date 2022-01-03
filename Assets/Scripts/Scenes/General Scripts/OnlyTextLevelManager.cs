using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlyTextLevelManager : LevelManager
{
    [Header("Text")]
    [SerializeField]
    [TextArea(1,3)]
    private List<string> texts;
    [SerializeField]
    private Text textOnScreen;
    [SerializeField]
    private string nextLevel;
    private int textNumber;

    protected override void Start()
    {
        base.Start();
        textNumber = 0;
        textOnScreen.text = texts[0];
    }

    public void NextLine()
    {
        textNumber++;
        if (textNumber < texts.Count)
        {
            textOnScreen.text = texts[textNumber];
        }
        else
        {
            base.LoadScene(nextLevel);
        }
    }
}
