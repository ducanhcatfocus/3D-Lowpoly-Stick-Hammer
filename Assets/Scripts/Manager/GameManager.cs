
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : Singleton<GameManager>
{
    private bool isPaused = false;
    [SerializeField] GamePlay gamePlayUI;
    [SerializeField] int enemies = 50;
    private bool isLose = false;

    

    protected void Awake()
    {
        //TogglePause();
        UIManager.Ins.OpenUI<MainMenu>();
     
    }

  
    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }
    public void GetName(string name)
    {
        Debug.Log(name);
    }
    public void DisplayWinPanel()
    {
      
        UIManager.Ins.OpenUI<Win>();
        UIManager.Ins.CloseUI<GamePlay>();
    }
    public void DisplayLosePanel()
    {
        isLose = true;
        UIManager.Ins.OpenUI<Lose>();
        UIManager.Ins.CloseUI<GamePlay>();
    }

    public void UpdateAlive()
    {
 
        enemies--;
        
 
        gamePlayUI.UpdateAliveText(enemies);
        if(enemies <= 0 && !isLose)
        {
            DisplayWinPanel();
        }
    }
}
