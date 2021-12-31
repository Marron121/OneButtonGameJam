using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyCombatLevelManager : LevelManager
{
    [SerializeField]
    private string nextLevel;
    private float currentTime = 0.0f;
    [SerializeField]
    private bool canSpawn = true;
    [SerializeField]
    private int spawnedEnemies = 0;

    protected override void Update()
    {
        if (!fadingBackground.raycastTarget)
        {
            currentTime += Time.deltaTime;
            if(canSpawn && currentTime >= spawnTimes[spawnedEnemies])
            {
                SpawnEnemy();
                spawnedEnemies++;
                if(spawnedEnemies >= enemies.Count)
                {
                    //Debug.Log("No more enemies left!");
                    canSpawn = false;
                }
            }
                
        }
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(enemies[spawnedEnemies], Vector3.zero, Quaternion.identity);
        List<Transform> pos = new List<Transform>(paths[spawnedEnemies].GetComponentsInChildren<Transform>());
        pos.RemoveAt(0);
        enemy.GetComponent<EnemyManager>().Directions = pos;
        enemy.GetComponent<EnemyManager>().LevelManager = this;
        paths[spawnedEnemies].GetComponent<PathController>().AssignEnemyToWaypoints(enemy.GetComponent<EnemyManager>());
        enemy.GetComponent<EnemyManager>().ActivateEnemy();
    }

    public override void EnemyKilled()
    {
        killedEnemies++;
        //Debug.Log("killedEnemies("+killedEnemies+"), spawnedEnemies("+spawnedEnemies+")");
        if (killedEnemies >= spawnedEnemies && !canSpawn) base.LoadScene(nextLevel);
    }
}
