
using UnityEngine;


public class EnemyMoveState : IState<Enemy>
{
    float timer;
    float randomTime;

    public void OnEnter(Enemy enemy)
    {
        enemy.ChangeAnim("Run");
        enemy.SetDestination();
        enemy.agent.isStopped = false;
        timer = 0;
        randomTime = Random.Range(1f, 2f);
    }
    public void OnExecute(Enemy enemy)
    {
        timer += Time.deltaTime;
        if(enemy.enemies.Count > 0 && timer > randomTime)
        {
            enemy.ChangeState(new EnemyAttackState());
            return;
        }
        if (enemy.Check())
        {
            enemy.ChangeState(new EnemyIdleState());
        }

    }

    public void OnExit(Enemy enemy)
    {
        enemy.agent.isStopped = true;

    }
}

