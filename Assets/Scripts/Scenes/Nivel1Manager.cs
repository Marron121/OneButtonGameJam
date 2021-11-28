using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel1Manager : SceneController
{
    public List<GameObject> enemigosASpawnear;
    public List<GameObject> paths;
    public List<float> timingSpawn;

    public int spawnedEnemies = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (spawnedEnemies < enemigosASpawnear.Count -1)
        {
            yield return new WaitForSeconds(timingSpawn[spawnedEnemies]);
            //Instantiate()
        }
    }
}
