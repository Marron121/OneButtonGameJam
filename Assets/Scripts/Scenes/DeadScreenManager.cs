using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadScreenManager : LevelManager
{
    [Header("Stone animations")]
    [SerializeField]
    private List<Transform> stones;
    [SerializeField]
    [Range(0.5f,1.5f)]
    private List<float> yVelocity;

    [Header("Hand images")]
    [SerializeField]
    private List<GameObject> hands;

    [Header("Text")]
    [SerializeField]
    private List<GameObject> texts;
    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    InformationHolder infoHolder;

    protected override void Update()
    {
        if (isFadingIn)
        {
            for (int i = 0; i < stones.Count; i++)
            {
                stones[i].position += new Vector3(0, yVelocity[i], 0);
            }
        }
    }

    public override void LoadScene(string n)
    {
        if (!audio.isPlaying && !isFadingIn)
        {
            audio.Play();
            foreach (GameObject text in texts) text.SetActive(false);
            hands[0].SetActive(false);
            hands[1].SetActive(true);

        }
        base.LoadScene(infoHolder.currentScene);
    }
}
