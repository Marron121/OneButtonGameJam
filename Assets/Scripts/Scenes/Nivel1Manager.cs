using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel1Manager : SceneController
{
    
    public List<GameObject> enemigosASpawnear = new List<GameObject>();
    public List<GameObject> paths;
    public List<float> timingSpawn;

    public int spawnedEnemies = 0;
    float currentTime = 0.0f;
    bool canSpawn = true;
    void Update()
    {
        currentTime += Time.deltaTime;
        //Debug.Log(currentTime);
        if (canSpawn && currentTime >= timingSpawn[spawnedEnemies])
        {
            Debug.Log("Toca spawnear");
            var enemy = Instantiate(enemigosASpawnear[spawnedEnemies], Vector3.zero, Quaternion.identity);
            List<Transform> pos = new List<Transform>(paths[spawnedEnemies].GetComponentsInChildren<Transform>());
            pos.RemoveAt(0);
            enemy.GetComponent<EnemyController>().directions = pos;
            paths[spawnedEnemies].GetComponent<PathController>().AssignEnemyToWaypoints(enemy.GetComponent<EnemyController>());
            enemy.GetComponent<EnemyController>().ActivateEnemy();
            spawnedEnemies++;
            if(spawnedEnemies >= enemigosASpawnear.Count)
            {
                Debug.Log("Hasta aquí hemos llegado");
                canSpawn = false;
            }
        }
    }
}
