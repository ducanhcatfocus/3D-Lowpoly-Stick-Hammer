using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Weapon : UICanvas
{
    [SerializeField] TextMeshProUGUI weaponName;
    public void CloseButton()
    {

        UIManager.Ins.OpenUI<MainMenu>();
        Close();

    }
    
    public void SelectButton()
    {
        WeaponAndSkinManager.Ins.SelectWeapon();
        UIManager.Ins.OpenUI<MainMenu>();
        Close();
    }

    public void NextButton()
    {
        string name = WeaponAndSkinManager.Ins.GetNextWeapon();
        weaponName.text = name.ToUpper();
    }

    public void BackButton()
    {
        string name = WeaponAndSkinManager.Ins.GetBackWeapon();
        weaponName.text = name.ToUpper();

    }
}
