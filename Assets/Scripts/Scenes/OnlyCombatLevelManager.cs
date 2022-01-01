using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyCombatLevelManager : LevelManager
{
    [SerializeField]
    protected string nextLevel;
    private float currentTime = 0.0f;
    [SerializeField]
    protected bool canSpawn = true;
    [SerializeField]
    protected int spawnedEnemies = 0;

    [SerializeField]
    AudioSource audio;
    [SerializeField]
    bool startedSong = false;

    protected override void Update()
    {
        if (!fadingBackground.raycastTarget)
        {
            if (!startedSong)
            {
                audio.Play();
                startedSong = true;
            }
            
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

    public override void PlayerKilled()
    {
        canSpawn = false;
        audio.Stop();
        base.LoadScene("DeadScreen");
    }
}
