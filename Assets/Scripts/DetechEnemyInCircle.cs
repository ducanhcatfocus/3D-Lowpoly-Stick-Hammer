using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetechEnemyInCircle : MonoBehaviour
{
    [SerializeField] Character character;


    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hit") && other.gameObject.transform.parent.name != gameObject.transform.parent.name)
        {
            character.enemies.Add(other.gameObject.transform);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hit"))
        {
            character.enemies.Remove(other.gameObject.transform);
            CacheComponent.GetEnemyComponent(other.gameObject.transform.parent)?.targetCircle.SetActive(false);
        }
    }
}
