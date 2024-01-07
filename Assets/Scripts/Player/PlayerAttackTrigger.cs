using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerAttackTrigger : MonoBehaviour
{
    [SerializeField] Player player;
    public void ThrowWeaponTrigger()
    {
        player.ThrowWeaponTrigger();
    }

    public void FinishAttackTrigger()
    {
        player.FinishAttackTrigger();
    }

}
