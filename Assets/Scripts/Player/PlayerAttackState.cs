using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : IState<Player>
{
    public void OnEnter(Player player)
    {

        player.ChangeAnim("Attack");
        player.LookAtEnemy();
    }

    public void OnExecute(Player player)
    {

        if (player.input != Vector2.zero)
        {
            player.ChangeState(new PlayerMoveState());
            return;
        }
           
        if (player.enemies.Count <= 0)
        {
            player.ChangeState(new PlayerIdleState());
        }


    }

    public void OnExit(Player player)
    {
        player.throwPos.gameObject.SetActive(true);

    }
}
