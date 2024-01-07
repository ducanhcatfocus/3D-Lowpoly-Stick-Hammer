
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource musicSource;



    [SerializeField] private AudioClip winSource;
    [SerializeField] private AudioClip loseSource;



    [SerializeField] private AudioClip ButtonClick;
    [SerializeField] private AudioClip NemVuKhi;
    [SerializeField] private AudioClip VuKhiVaCham;
    [SerializeField] private AudioClip StickManDie;

   
  

    public bool isMuted;

    public void PlayButtonclick()
    {
        musicSource.PlayOneShot(ButtonClick);
    }

    public void PlayNemVuKhiEffect()
    {
        musicSource.PlayOneShot(NemVuKhi);
    }

    public void PlayHitEffect(Transform tranform)
    {
        AudioSource.PlayClipAtPoint(VuKhiVaCham, tranform.position);
    }

    public void PlayWinEffect()
    {
        musicSource.PlayOneShot(winSource);
    }
    public void PlayLoseEffect()
    {
        musicSource.PlayOneShot(loseSource);
    }


    public void DieSound()
    {
        musicSource.PlayOneShot(StickManDie);
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            musicSource.volume = 0f;
            //UIManager.Instance.SetMuteBtn();
        }
        else
        {
            musicSource.volume = 1f;
            //UIManager.Instance.SetUnMuteBtn();

        }
    }


    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
