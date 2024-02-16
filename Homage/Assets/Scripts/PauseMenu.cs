using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public GameObject PausePanel;
    public GameObject ContinueButton;
    public GameObject ExitButton;
    // Start is called before the first frame update


    // Update is called once per frame

    public void Pause()
    {
        ContinueButton.SetActive(true);
        PausePanel.SetActive(true);
        ExitButton.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        PausePanel.SetActive(false);
        ExitButton.SetActive(false);
        Time.timeScale = 1;
        ContinueButton.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Title Screen");
        Time.timeScale = 1;
    }
}
