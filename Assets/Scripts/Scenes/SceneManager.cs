using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void LoadScene(string n)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(n);
    }
}