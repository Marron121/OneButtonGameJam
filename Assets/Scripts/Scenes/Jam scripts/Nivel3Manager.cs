using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nivel3Manager : SceneController
{
    
    public GameObject enemigoFinal;
    public Transform spawnPoint;
    public List<float> timingSpawn;
    public Image golpeFinal;

    public int spawnedEnemies = 0;
    public int killedEnemies = 0;
    float currentTime = 0.0f;
    bool canSpawn = true;
    void Update()
    {
        currentTime += Time.deltaTime;
        //Debug.Log(currentTime);
        if (canSpawn && currentTime >= timingSpawn[spawnedEnemies])
        {
            Debug.Log("Toca spawnear");
            var enemy = Instantiate(enemigoFinal, spawnPoint.position, Quaternion.identity);
            enemy.GetComponent<EnemyFinalController>().ActivateEnemy();
            spawnedEnemies++;
            if(spawnedEnemies >= 3)
            {
                Debug.Log("Hasta aquí hemos llegado");
                canSpawn = false;
            }
        }
    }

    public void EnemyWentThroughSignal()
    {
        killedEnemies++;
        if (killedEnemies >= spawnedEnemies && !canSpawn) StartCoroutine(FadeBackground(1.0f, 2.5f, golpeFinal));
    }

    IEnumerator FadeBackground(float aValue, float aTime, Image i)
    {
        float alpha = i.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            i.color = newColor;
            yield return null;
        }
        base.LoadScene("EndScene");
    }
}
