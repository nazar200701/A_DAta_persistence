using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI InputField;
    public int score = 1;
    public int HighScore = 0;
    public string nameOfBoi;
    public static UIManager Instance;
    public GameObject eventSystem;
    public TextMeshProUGUI nameandScore;
    public GameObject HighScoreText;

    // First what to do 
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(GameObject.FindWithTag("Manager"));
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();

        TextForName();
    }
    public void TextForName()
    {
        
        nameOfBoi = InputField.text;
        nameandScore.text = $"{nameOfBoi}:{HighScore}";
    }
    public void BestScore()
    {
        HighScoreText = GameObject.FindGameObjectWithTag("Text");
        HighScoreText.GetComponent<Text>().text = $"BestScore: {nameOfBoi} : {HighScore}";
    }

    //Buttons
    public void StartButton(){
        SceneManager.LoadScene(1);
        Save();
    }
    public void QuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit(); // original code to quit Unity player
#endif
    }
    public void SettingsButton()
    {
        eventSystem.SetActive(false);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }


   

    public void Save()
    {
       SaveSystem.SavePlayer(this);
       
    }
    public void Rewrite()
    {
        SaveSystem.SavePlayer(this);
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/playerdata.chill";
        Debug.Log(path);
        if (File.Exists(path))
        {
            PlayerData data = SaveSystem.LoadData();
            HighScore = data.score;
            nameOfBoi = data.nameOfBoi;

            // Change a text field if file exists
            InputField.text = nameOfBoi;
        }
    }
}
