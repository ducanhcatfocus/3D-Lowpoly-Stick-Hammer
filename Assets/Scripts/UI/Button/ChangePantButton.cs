using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePantButton : MonoBehaviour
{
    public Material pantMaterial;
    public GameObject buttonBorderOnclick;


 

    public void ChangePant()
    {
        
        WeaponAndSkinManager.Ins.ChangePant(pantMaterial);
        AudioManager.Ins.PlayButtonclick();

        buttonBorderOnclick.transform.SetParent(transform);
        buttonBorderOnclick.transform.position = transform.position;
        buttonBorderOnclick.SetActive(true);
    }
}
