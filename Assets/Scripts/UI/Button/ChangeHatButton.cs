using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHatButton : MonoBehaviour
{
    public MeshFilter hairMeshFilter;
    public MeshRenderer hairRenderer;
    public GameObject buttonBorderOnclick;
    public Vector3 scale = Vector3.one;
    public Vector3 pos = Vector3.zero;
    public float rotationX = 0;



    public void ChangeHat()
    {

        WeaponAndSkinManager.Ins.ChangeHair(hairMeshFilter, hairRenderer, scale,pos, rotationX);
        AudioManager.Ins.PlayButtonclick();
        buttonBorderOnclick.transform.SetParent(transform);
        buttonBorderOnclick.transform.position = transform.position;
        buttonBorderOnclick.SetActive(true);
    }
}
