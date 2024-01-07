
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : UICanvas
{
    [SerializeField] Camera _camera;


    public void PlayButton()
    {
        UIManager.Ins.OpenUI<GamePlay>();
        CameraController.Ins.MoveCameraStart();
        EnemySpawner.Ins.StartSpawnEnemy();
        Close();
    }

    public void WeaponButton()
    {
        UIManager.Ins.OpenUI<Weapon>();
        WeaponAndSkinManager.Ins.ChangeLayerOfCamera("UIHammer", "Pant", "Hat");
        Close();
    }

    public void SkinButton()
    {
        UIManager.Ins.OpenUI<Skin>();
        CameraController.Ins.MoveCameraSkin();
        WeaponAndSkinManager.Ins.ChangeLayerOfCamera("Hat", "UIHammer", "Pant");
        Close();
    }


  
}
