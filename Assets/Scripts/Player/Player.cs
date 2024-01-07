
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;



public class Player : Character
{
    private IState<Player> currentState;
    Vector3 moveAmount;
    public Vector2 input;
    [SerializeField] private InputActionReference inputAction;
    public NavMeshAgent agent;

    public Transform target;
    



    protected override void Start()
    {
       
        ChangeState(new PlayerIdleState());
        
    }

    void Update()
    {
        currentState?.OnExecute(this);
        input = inputAction.action.ReadValue<Vector2>();
        RemoveEnemy();

    }

    public void ChangeState(IState<Player> state)
    {
        currentState?.OnExit(this);

        currentState = state;

        currentState?.OnEnter(this);
    }

    public void Moving()
    {
        
        moveAmount = agent.speed * Time.deltaTime * new Vector3(input.x, 0, input.y);
        agent.Move(moveAmount);
        anim.transform.LookAt(anim.transform.position + moveAmount, Vector3.up);
    }





    public void LookAtEnemy()
    {
        if (enemies.Count <= 0)
            return;
        target = GetEnemy();
        if (target != null)
        {
            anim.transform.LookAt(target.position);
            CacheComponent.GetEnemyComponent(target.parent).targetCircle.SetActive(true);
        }
    }

    public void ThrowWeaponTrigger()
    {
      
        throwPos.gameObject.SetActive(false);
        AudioManager.Ins.PlayNemVuKhiEffect();
        ThrowWeapon.Ins.Throw(throwPos.position, target.position, weaponTag, this, modifierValue);
    }

    public void SetWeaponTag(string tag)
    {
        weaponTag = tag;
    }

    public void FinishAttackTrigger()
    {
        ChangeState(new PlayerIdleState());
    }

    Transform GetEnemy()
    {
        foreach (var enemy in enemies)
        {
            if (enemy.parent.gameObject.activeSelf == true)
            {
                return enemy;
            }
        }
        return null;
    }

}

