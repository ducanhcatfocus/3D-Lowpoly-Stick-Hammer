using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GetDestinationPos : Singleton<GetDestinationPos>
{
    [SerializeField] float range;
    Vector3 randomPoint;


    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            randomPoint = center + (Random.insideUnitSphere * range);
        
            if(NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }

        result = center;
        return false;
    }

    public Vector3 GetRandomPos(Transform center)
    {
        if(RandomPoint(center.position, range, out Vector3 _point))
        {
            return _point;
        }

        return _point;
    }


    public Vector3 GetRandomPos(Transform center, float range)
    {
        if (RandomPoint(center.position, range, out Vector3 _point))
        {
            return _point;
        }

        return _point;
    }
}
