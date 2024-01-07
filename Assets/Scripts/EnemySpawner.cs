using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{

    [SerializeField] int totalEnemies = 49;
    [SerializeField] GetDestinationPos spawnDestination;
    [SerializeField] GamePlay gamePlayUI;






    public void SpawnEnemy()
    {
        if (totalEnemies <= 0) return;
        GameObject enemy = ObjectPool.Ins.Spawn("Enemy");
        WeaponAndSkinManager.Ins.GetRandomEnemyWeaponAndSkin(enemy);
        enemy.name += totalEnemies;
        enemy.transform.position = GetDestinationPos.Ins.GetRandomPos(transform, 30);
        totalEnemies--;

    }


   public  void StartSpawnEnemy()
    {
        for (int i = 0; i < 10; i++)
        {
            Invoke(nameof(SpawnEnemy), 2f); 
        }
    }

}
