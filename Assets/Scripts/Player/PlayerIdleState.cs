using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IState<Player>
{
    float timer;
    float cdTime = 0.4f;
    public void OnEnter(Player player)
    {

        player.ChangeAnim("Idle");
        timer = 0;
    }

    public void OnExecute(Player player)
    {

        timer += Time.deltaTime;
        if (timer > cdTime && player.enemies.Count > 0)
        {
            player.ChangeState(new PlayerAttackState());
            return;
        }

        if (player.input.Equals(Vector2.zero))
            return;
        player.ChangeState(new PlayerMoveState());
    }

    public void OnExit(Player player)
    {

    }


}

