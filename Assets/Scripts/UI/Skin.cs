using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Skin : UICanvas
{
    [SerializeField] GameObject PantPanel;
    [SerializeField] GameObject SetSkinPanel;
    [SerializeField] GameObject clickBorder;
    public void CloseButton()
    {

        UIManager.Ins.OpenUI<MainMenu>();
        CameraController.Ins.MoveCameraSkinBack();
        PantPanel.SetActive(false);
        SetSkinPanel.SetActive(true);
        Close();

    }

    public void DisplayPantPanel()
    {
        PantPanel.SetActive(true);
        SetSkinPanel.SetActive(false);
        WeaponAndSkinManager.Ins.ChangeLayerOfCamera("Pant", "UIHammer", "Hat");

    }

    public void DisplaySkinPanel()
    {
        PantPanel.SetActive(false);
        SetSkinPanel.SetActive(true);
        WeaponAndSkinManager.Ins.ChangeLayerOfCamera("Hat", "UIHammer", "Pant");

    }


    public void SelectButton()
    {
        UIManager.Ins.OpenUI<MainMenu>();
        CameraController.Ins.MoveCameraSkinBack();
        PantPanel.SetActive(false);
        SetSkinPanel.SetActive(true);
        Close();
    }
}
