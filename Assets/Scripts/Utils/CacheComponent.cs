using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CacheComponent : MonoBehaviour
{
    

   Dictionary<Collider, string> cacheName = new Dictionary<Collider, string>();
    public static Dictionary<Transform, Enemy> cacheEnemyComponent = new Dictionary<Transform, Enemy>();
    public static Dictionary<GameObject, WeaponMove> cacheWeaponComponent = new Dictionary<GameObject, WeaponMove>();
    public static Dictionary<GameObject, MeshFilter> cacheMeshFilter = new Dictionary<GameObject, MeshFilter>();
    public static Dictionary<GameObject, MeshRenderer> cacheMeshRenderer = new Dictionary<GameObject, MeshRenderer>();

 



    string GetName(Collider go)
    {
        if(cacheName.ContainsKey(go))
        {
            return cacheName[go];
        }
        //cacheName.Add(go, go.transform.parent.name);
        return go.name;
    }


    public static Enemy GetEnemyComponent(Transform go)
    {
        if (cacheEnemyComponent.ContainsKey(go))
        {
            return cacheEnemyComponent[go];
        }
        if (go.TryGetComponent(out Enemy enemy))
        {
            cacheEnemyComponent.Add(go, enemy);
            return cacheEnemyComponent[go];
        }
        return null;
   
    }

    public static WeaponMove GetWeaponComponent(GameObject go)
    {
        if (cacheWeaponComponent.ContainsKey(go))
        {
            return cacheWeaponComponent[go];
        }
        cacheWeaponComponent.Add(go, go.GetComponent<WeaponMove>());
        return cacheWeaponComponent[go];
    }


    public static MeshFilter GetMeshFilter(GameObject go)
    {
        if (cacheMeshFilter.ContainsKey(go))
        {
            return cacheMeshFilter[go];
        }
        cacheMeshFilter.Add(go, go.GetComponent<MeshFilter>());
        return cacheMeshFilter[go];
    }


    public static MeshRenderer GetMeshRenderer(GameObject go)
    {
        if (cacheMeshRenderer.ContainsKey(go))
        {
            return cacheMeshRenderer[go];
        }
        cacheMeshRenderer.Add(go, go.GetComponent<MeshRenderer>());
        return cacheMeshRenderer[go];
    }
}
