using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : IState<Enemy>
{


    public void OnEnter(Enemy enemy)
    {
        enemy.ChangeAnim("Attack");
     
    }

    public void OnExecute(Enemy enemy)
    {
        enemy.LookAtEnemy();

    }

    public void OnExit(Enemy enemy)
    {
        enemy.throwPos.gameObject.SetActive(true);
    }
}
