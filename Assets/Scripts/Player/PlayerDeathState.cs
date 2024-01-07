using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : IState<Player>
{
    public void OnEnter(Player player)
    {
        player.ChangeAnim("Death");
    
    }

    public void OnExecute(Player player) { 
   
    }

    public void OnExit(Player player)
    {
    }
}
