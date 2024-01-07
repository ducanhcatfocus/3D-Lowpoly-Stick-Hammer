using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : UICanvas
{
    public GameObject muteBtn;
    public GameObject unMuteBtn;
    public void ContinueButton()
    {
        GameManager.Ins.TogglePause();
        Close();
    }

    public void ResumeButton()
    {
        GameManager.Ins.TogglePause();
    }

    public void ResetButton()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }

    public void MuteButton()
    {

        AudioManager.Ins.ToggleMute();
        unMuteBtn.SetActive(true);
        muteBtn.SetActive(false);

    }

    public void UnMuteButton()
    {

        AudioManager.Ins.ToggleMute();
        unMuteBtn.SetActive(false);
        muteBtn.SetActive(true);

    }
}
