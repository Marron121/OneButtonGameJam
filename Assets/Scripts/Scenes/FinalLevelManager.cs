using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelManager : OnlyCombatLevelManager
{
    [SerializeField]
    private int enemiesBeforeFade = 2;
    public override void SpecialEffect()
    {
        if (killedEnemies >= enemiesBeforeFade)
        {
            base.LoadScene(nextLevel);
        }
    }
}