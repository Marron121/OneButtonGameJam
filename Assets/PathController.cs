using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public List<WaypointController> waypoints = new List<WaypointController>();

    public void AssignEnemyToWaypoints(EnemyController ec)
    {
        foreach (WaypointController script in waypoints)
        {
            script.AddEnemy(ec);
        }
    }
}
