using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoManager : SceneController
{
    
    public List<GameObject> enemigosASpawnear = new List<GameObject>();
    public List<GameObject> paths;
    public List<GameObject> texts;
    public int killedEnemies = 0;
    float currentTime = 0.0f;
    public List<int> eventos = new List<int>();
    private void Update()
    {
        if (eventos[0] == 0) FirstEnemy();
        else if (eventos[1] == 0) SecondEnemy();
        else if (eventos[2] == 0) ThirdEnemy();
        else if (eventos[3] == 0) Bala();
    }

    public void EnemyKilled()
    {
        killedEnemies++;
        switch (killedEnemies)
        {
            case 1:
                eventos[1] = 0;
                Destroy(texts[killedEnemies-1]);
                break;
            case 2:
                eventos[2] = 0;
                Destroy(texts[killedEnemies-1]);
                break;
            case 3:
                eventos[3] = 0;
                Destroy(texts[killedEnemies-1]);
                break;
            case 4:
                base.LoadScene("Nivel1");
                break;
        }
    }
    void FirstEnemy()
    {
        eventos[0] = 1;
        SpawnEnemy();
    }

    void SecondEnemy()
    {
        eventos[1] = 1;
        SpawnEnemy();
    }

    void ThirdEnemy()
    {
        eventos[2] = 1;
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        var enemy = Instantiate(enemigosASpawnear[killedEnemies], Vector3.zero, Quaternion.identity);
        List<Transform> pos = new List<Transform>(paths[killedEnemies].GetComponentsInChildren<Transform>());
        pos.RemoveAt(0);
        enemy.GetComponent<EnemyController>().directions = pos;
        paths[killedEnemies].GetComponent<PathController>().AssignEnemyToWaypoints(enemy.GetComponent<EnemyController>());
        enemy.GetComponent<EnemyController>().ActivateEnemy();
    }

    void Bala()
    {
        eventos[3] = 1;
        SpawnEnemy();
    }

}
