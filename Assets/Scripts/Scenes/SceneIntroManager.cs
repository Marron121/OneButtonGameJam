using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneIntroManager : SceneController
{
    [TextArea(1,3)]
    public List<string> introductionTexts;

    public int textNumber;
    public string scene;

    public Text textOnScreen;

    private void Start()
    {
        textNumber = 0;
        textOnScreen.text = introductionTexts[0];
    }

    public void NextLine()
    {
        textNumber++;
        if (textNumber < introductionTexts.Count)
        {
            textOnScreen.text = introductionTexts[textNumber];
        }
        else
        {
            base.LoadScene(scene);
        }
    }
}
