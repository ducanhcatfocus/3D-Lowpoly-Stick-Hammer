
using UnityEngine;

public class EnemyIdleState : IState<Enemy>
{
    float timer;
    float randomTime;

    public void OnEnter(Enemy enemy)
    {
        enemy.ChangeAnim("Idle");
        timer = 0;
        randomTime = Random.Range(0.5f, 1f);
    }

    public void OnExecute(Enemy enemy)
    {
        timer += Time.deltaTime;
        if (timer > randomTime)
        {    
            enemy.ChangeState(new EnemyMoveState());
        }
    }

    public void OnExit(Enemy enemy)
    {

    }
}
