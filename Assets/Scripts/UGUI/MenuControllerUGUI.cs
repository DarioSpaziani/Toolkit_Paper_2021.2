using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControllerUGUI : MonoBehaviour
{
    public Animation anim;
    public GameObject leftSection;
    public GameObject settingsUI;
    public TMP_Text textButton;
    private bool isUnmuted;
    public Sprite unmuted;
    public Sprite muted;
    public Image imageSound;

    private void Awake()
    {
        settingsUI.SetActive(false);
        leftSection.SetActive(true);
    }

    public void PlayButton()
    {
        textButton.fontStyle = FontStyles.Bold;
        SceneManager.LoadScene("Environment_Free");
    }

    public void SettingsButton()
    {
        leftSection.SetActive(false);
        settingsUI.SetActive(true);
    }

    public void BackButton()
    {
        settingsUI.SetActive(false);
        leftSection.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SoundButton()
    {
        isUnmuted = !isUnmuted;

        imageSound.sprite = isUnmuted ? muted : unmuted;
        
        AudioListener.volume = isUnmuted ? 0 : 1;
    }

    private void OnMouseOver()
    {
        textButton.fontStyle = FontStyles.Bold;
        anim.Play("ButtonMenuUGUI");
    }

    private void OnMouseExit()
    {
        textButton.fontStyle = FontStyles.Normal;
        anim.Stop("ButtonMenuUGUI");
    }
}