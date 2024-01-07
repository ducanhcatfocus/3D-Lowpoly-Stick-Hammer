
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : Character
{


    public NavMeshAgent agent;
    private IState<Enemy> currentState;
    Vector3 des;
    public Transform target;
    [SerializeField] SkinnedMeshRenderer pantRendered;
    public SkinnedMeshRenderer skinRendered;

    [SerializeField] MeshFilter weaponFilter;
    [SerializeField] MeshRenderer weaponRenderer;

    public GameObject targetCircle;



    



    protected override void Start()
    {
        base.Start();
        ChangeState(new EnemyIdleState());

    }

    void Update()
    {
        currentState?.OnExecute(this);
        RemoveEnemy();
    }

    public void ChangeState(IState<Enemy> state)
    {
        currentState?.OnExit(this);

        currentState = state;

        currentState?.OnEnter(this);
    }

    public bool Check()
    {
        if (agent.remainingDistance < 0.1f)
        {
            return true;
        }
        return false;
    }

    public void SetDestination()
    {
        des = GetDestinationPos.Ins.GetRandomPos(transform);
        agent.SetDestination(des);
    }

    public void LookAtEnemy()
    {
        if (enemies.Count <= 0)
            return;
        target = GetEnemy();
        if (target != null)
        {
            transform.LookAt(target.position);
        }
    }

    Transform GetEnemy()
    {
        foreach (var enemy in enemies)
        {
            if(enemy.parent.gameObject.activeSelf == true)
            {
                return enemy;
            }
        } 
        return null;
    }

 


    public void ThrowWeaponTrigger()
    {
        throwPos.gameObject.SetActive(false);                 
        if(target != null)
        {
            ThrowWeapon.Ins.Throw(throwPos.position, target.position, weaponTag, this, modifierValue);
        }
    }

    public void FinishAttackTrigger()
    {   
        ChangeState(new EnemyMoveState());      
    }

    public void ChangeSkin(Material pantMarterial, Material skinMaterial, string tag)
    {
        pantRendered.material = pantMarterial;
        skinRendered.material = skinMaterial;
        weaponTag = tag;
     
    }

    public void ChangeWeaponSkin(MeshFilter _weaponFilter, MeshRenderer _weaponRenderer)
    {
        weaponFilter.mesh = _weaponFilter.sharedMesh;
        weaponRenderer.materials = _weaponRenderer.sharedMaterials;
        
    }

}
