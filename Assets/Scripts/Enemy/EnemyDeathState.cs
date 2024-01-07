using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : IState<Enemy>
{
    float timer;
    float randomTime = 1.5f;

    public void OnEnter(Enemy enemy)
    {
        enemy.isDead = true;
        enemy.ChangeAnim("Death");
        enemy.targetCircle.SetActive(false);
        enemy.enemies.Clear();
        timer = 0;
        GameManager.Ins.UpdateAlive();
    
    }

    public void OnExecute(Enemy enemy)
    {
        timer += Time.deltaTime;
        if (timer > randomTime)
        {
            EnemySpawner.Ins.SpawnEnemy();

            enemy.gameObject.SetActive(false);
            enemy.ChangeState(new EnemyIdleState());
        }
    }

    public void OnExit(Enemy enemy)
    {
        enemy.isDead = false;

    }


}
