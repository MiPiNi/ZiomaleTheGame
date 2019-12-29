using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject CreditsPanel;
    public void Play()
    {
        SceneManager.LoadScene("GAME");
    }
    public void Credits()
    {
        CreditsPanel.SetActive(!CreditsPanel.activeInHierarchy);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
