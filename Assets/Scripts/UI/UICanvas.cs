using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{

    public bool IsDestroyOnClose = false;

    protected RectTransform m_RectTransform;
    [SerializeField] protected Animator m_Animator;


    private void Start()
    {
        Init();
    }

    protected void Init()
    {
        m_RectTransform = GetComponent<RectTransform>();
        //m_Animator = GetComponent<Animator>();

    }

    public virtual void Setup()
    {
        UIManager.Ins.AddBackUI(this);
        UIManager.Ins.PushBackAction(this, BackKey);
    }

    public virtual void BackKey()
    {

    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        //anim
        //m_Animator.SetBool("isClose", false);

    }

    public virtual void Close()
    {
        UIManager.Ins.RemoveBackUI(this);
        gameObject.SetActive(false);

        //m_Animator.SetBool("isClose", true);
        //Invoke(nameof(PlayAnim), 1f);
        if (IsDestroyOnClose)
        {
            Destroy(gameObject);
        }

    }

    void PlayAnim()
    {
        gameObject.SetActive(false);

    }


}
