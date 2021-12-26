using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyCombatLevelManager : LevelManager
{
    [SerializeField]
    private string nextLevel;
    private float currentTime = 0.0f;
    private bool canSpawn = true;
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
                    canSpawn = false;
            }
                
        }
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(enemies[killedEnemies], Vector3.zero, Quaternion.identity);
        List<Transform> pos = new List<Transform>(paths[killedEnemies].GetComponentsInChildren<Transform>());
        pos.RemoveAt(0);
        enemy.GetComponent<EnemyManager>().Directions = pos;
        enemy.GetComponent<EnemyManager>().LevelManager = this;
        paths[killedEnemies].GetComponent<PathController>().AssignEnemyToWaypoints(enemy.GetComponent<EnemyManager>());
        enemy.GetComponent<EnemyManager>().ActivateEnemy();
    }

    public override void EnemyKilled()
    {
        killedEnemies++;
        if (killedEnemies >= spawnedEnemies && !canSpawn) base.LoadScene(nextLevel);
    }
}
