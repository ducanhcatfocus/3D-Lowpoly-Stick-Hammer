using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected Animator anim;
    public bool isDead;
    public Transform throwPos;
    public int lv = 0;

    public List<Transform> enemies;
    protected List<Transform> removeEnemies =new List<Transform>();

    protected string weaponTag = "Hammer";




    [SerializeField] LayerMask targetLayer;
    [SerializeField] protected float radius = 5f;
    [SerializeField] protected float modifierValue = 1;

    private string currentAnimName;



    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
      
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(animName);
        }
    }

    public void ModifyBody()
    {
        lv++;
        modifierValue+= 0.1f;
        anim.transform.localScale = Vector3.one * modifierValue;
        radius = radius * modifierValue;
    }
    protected void RemoveEnemy()
    {
        if (enemies.Count <= 0) return;
        enemies.RemoveAll(item => item.parent.gameObject.activeSelf == false || CacheComponent.GetEnemyComponent(item.parent)?.isDead == true);

    }

}


