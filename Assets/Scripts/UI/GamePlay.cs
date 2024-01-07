
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlay : UICanvas
{
    public GameObject muteBtn;
    public GameObject unMuteBtn;
    [SerializeField] TextMeshProUGUI aliveText;
    
    public void SettingButton()
    {
        GameManager.Ins.TogglePause();
        UIManager.Ins.OpenUI<Setting>();
    }

    public void UnMuteButton()
    {

        AudioManager.Ins.ToggleMute();
        unMuteBtn.SetActive(false);
        muteBtn.SetActive(true);

    }

    public void MuteButton()
    {

        AudioManager.Ins.ToggleMute();
        unMuteBtn.SetActive(true);
        muteBtn.SetActive(false);

    }
    public void UpdateAliveText(int alive)
    {
      
        aliveText.text = "Alive: ";
    }
}
