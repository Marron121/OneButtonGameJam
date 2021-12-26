using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : LevelManager
{
    [SerializeField]
    private List<GameObject> texts;

    [SerializeField]
    private List<int> eventos = new List<int>();
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if (eventos[0] == 0) NewEvent(0);
        else if (eventos[1] == 0) NewEvent(1);
        else if (eventos[2] == 0) NewEvent(2);
        else if (eventos[3] == 0) NewEvent(3);
    }

    private void NewEvent(int activatedEvent)
    {
        eventos[activatedEvent] = 1;
        SpawnEnemy();
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
        switch (killedEnemies)
        {
            case 1:
                eventos[1] = 0;
                Destroy(texts[killedEnemies - 1]);
                break;
            case 2:
                eventos[2] = 0;
                Destroy(texts[killedEnemies - 1]);
                break;
            case 3:
                eventos[3] = 0;
                Destroy(texts[killedEnemies - 1]);
                break;
            case 4:
                base.LoadScene("Nivel1");
                break;
        }
    }
}
