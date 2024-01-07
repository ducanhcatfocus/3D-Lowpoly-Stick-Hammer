using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    public LayerMask targetLayer;

    [SerializeField] Rigidbody rb;
    Vector3 target;
    Vector3 direction;
    Character owner;

    float timer;
    [SerializeField] float deactiveTime = 1.5f;


    private void OnEnable()
    {
        timer = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > deactiveTime)
        {
            gameObject.SetActive(false);
        }
        if (target != null)
        {
            rb.velocity = direction.normalized * speed;
            transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);
        }
    }

    public void SetTarget(Vector3 _target, Vector3 _direction, Character _owner) 
    {
        target = _target;
        direction = _direction;
        owner = _owner;
        transform.LookAt(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.transform.parent;
 

        if (other.CompareTag("Hit") && parent.name != owner.gameObject.name)
        {
            owner.ModifyBody();
            if(parent.name == "player")
            {

                parent.GetComponent<Player>().ChangeState(new PlayerDeathState());
         
                //AudioManager.Ins.PlayHitEffect(parent.transform);

                GameManager.Ins.DisplayLosePanel();
                gameObject.SetActive(false);
                return;
            }
            CacheComponent.GetEnemyComponent(parent).ChangeState(new EnemyDeathState());
            gameObject.SetActive(false);   
        }   
    }

}
