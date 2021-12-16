using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceController : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;

    public void EnemyKilled()
    {
        levelManager.EnemyKilled();
    }
    public void PlayerKilled()
    {
        levelManager.PlayerKilled();
    }
}
