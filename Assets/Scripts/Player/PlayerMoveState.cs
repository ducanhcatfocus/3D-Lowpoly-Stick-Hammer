using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : IState<Player>
{
    public void OnEnter(Player player)
    {

        player.ChangeAnim("Run");

    }

    public void OnExecute(Player player)
    {
        if (player.input.Equals(Vector2.zero))
        {
            player.ChangeState(new PlayerIdleState());
            return;
        }
        player.Moving();


    }

    public void OnExit(Player player)
    {

    }
}

