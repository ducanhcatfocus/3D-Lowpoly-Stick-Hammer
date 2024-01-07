using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWeapon : Singleton<ThrowWeapon>
{
    Vector3 direction;

    [SerializeField] GameObject weaponPrefab;



    public void Throw(Vector3 throwPos, Vector3 targetPos, string tag, Character owner, float modifyValue)
    {
       direction = new Vector3(targetPos.x, throwPos.y, targetPos.z) - throwPos;
        GameObject weapon = ObjectPool.Ins.Spawn(tag);
        weapon.transform.position = throwPos;
        //weapon.transform.localScale += Vector3.one * modifyValue;
        CacheComponent.GetWeaponComponent(weapon).SetTarget(targetPos, direction, owner);
     
    }






}
