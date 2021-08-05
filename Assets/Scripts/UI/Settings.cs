using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        UIManager.Instance.eventSystem.SetActive(true);
    }
}
