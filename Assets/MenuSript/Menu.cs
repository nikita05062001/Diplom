using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int Level;

    public Image lowimg;
    public Image normalimg;
    public Image highimg;

    public GameObject NewGameUI;
    public GameObject MenuUI;
    public GameObject OptionUI;
    public GameObject AuthorUI;
    public GameObject ChooseMenuUI;
    public GameObject OptionGraphicUI;
    public GameObject ChooseLevelUI;

    public Button yourButton;
    public GameObject Camera1love;
    public Camera CameraTest;

    public bool NewGame = false;
    public bool Continue = false;
    public bool ChooseLevel = false;
    public bool Seting = false;
    public bool exit = false;
    public bool author = false;
    public bool BackChooseLevelUI = false;

    public bool GraphicOption = false;
    public bool backChooseMenu = false;
    public bool ChooseMenu = false;
 
    public bool back = false;
    public bool low = false;
    public bool normal = false;
    public bool hidh = false;
    public bool backAuthor = false;

    public bool Yes = false;
    public bool No = false;

    private void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        if (!PlayerPrefs.HasKey("Level")) PlayerPrefs.SetInt("Level", 1);
        Level = PlayerPrefs.GetInt("Level");
        Debug.Log("Уровень=" + PlayerPrefs.GetInt("Level"));

        if (!PlayerPrefs.HasKey("MaxLevel")) PlayerPrefs.SetInt("MaxLevel", 0);
        if (!PlayerPrefs.HasKey("Graphic")) PlayerPrefs.SetInt("Graphic", 1);

        switch (PlayerPrefs.GetInt("Graphic"))
        {
            case 1:
                QualitySettings.SetQualityLevel(1);
                break;
            case 2:
                QualitySettings.SetQualityLevel(2);
                break;
            case 3:
                QualitySettings.SetQualityLevel(4);
                break;
        }
    }

    void TaskOnClick()
    {
     

        if (Seting == true)
        {

            //  CameraTest.transform.position = new Vector3(58.27f, 0, -477.3256f);
            //  SceneManager.LoadScene("Option");
            ChooseMenuUI.SetActive(false);
            OptionUI.SetActive(true);
        }

        if (Continue == true) //уровни
        {
            switch (PlayerPrefs.GetInt("MaxLevel"))
            {
                case 0:
                    {
                        SceneManager.LoadScene("CastScene1"); 
                        PlayerPrefs.SetInt("MaxLevel", 1);
                    }
                    break;
                case 1:
                    SceneManager.LoadScene("Game");
                    break;
                case 2:
                    SceneManager.LoadScene("level2");
                    break;
                case 3:
                    SceneManager.LoadScene("level3");
                    break;
                case 4:
                    SceneManager.LoadScene("level4");
                    break;
                case 5:
                    SceneManager.LoadScene("level5");
                    break;
                case 6:
                    SceneManager.LoadScene("level6");
                    break;
                case 7:
                    SceneManager.LoadScene("level7");
                    break;
                case 8:
                    SceneManager.LoadScene("level8");
                    break;

            }
          //  Application.LoadLevel(4); 
            
        }
        if (exit == true)
        {
            Application.Quit();
        }
        if (NewGame == true)
        {
            NewGameUI.SetActive(true);
        }
        if (author == true)
        {
            // CameraTest.transform.position = new Vector3(94.9f, 0, -477.3256f);
            //  SceneManager.LoadScene("Author");
            ChooseMenuUI.SetActive(false);
            AuthorUI.SetActive(true);
        }
        ////////////////////////////////////////////////////         //////////////////////////////////////////////////////////////////////////
        if (back == true)
        {
            // CameraTest.transform.position = new Vector3(29.76f, 0, -477.3256f);
            //  SceneManager.LoadScene("Menu");
            OptionUI.SetActive(false);
            ChooseMenuUI.SetActive(true);
        }

        if (low == true)
        {
            QualitySettings.SetQualityLevel(1);
            PlayerPrefs.SetInt("Graphic", 1);
            lowimg.color = new Color32(124, 255,107,255);
            normalimg.color = new Color32(255, 255, 255, 255);
            highimg.color = new Color32(255, 255, 255, 255);
        }
        if (normal == true)
        {
            QualitySettings.SetQualityLevel(2);
            PlayerPrefs.SetInt("Graphic", 2);
            lowimg.color = new Color32(255, 255, 255, 255);
            normalimg.color = new Color32(124, 255, 107, 255);
            highimg.color = new Color32(255, 255, 255, 255);
        }
        if (hidh == true)
        {
            QualitySettings.SetQualityLevel(4);
            PlayerPrefs.SetInt("Graphic", 3);
            lowimg.color = new Color32(255, 255, 255, 255);
            normalimg.color = new Color32(255, 255, 255, 255);
            highimg.color = new Color32(124, 255, 107, 255);
        }
        if (backAuthor == true)
        {
            // SceneManager.LoadScene("Option");
            AuthorUI.SetActive(false);
            ChooseMenuUI.SetActive(true);
        }
        if (ChooseMenu == true)
        {
            MenuUI.SetActive(false);
            ChooseMenuUI.SetActive(true);
        }
        if (GraphicOption == true)
        {
            ChooseMenuUI.SetActive(false);
            OptionGraphicUI.SetActive(true);
            switch (PlayerPrefs.GetInt("Graphic"))
            {
                case 1:
                    lowimg.color = new Color32(124, 255, 107, 255);
                    break;
                case 2:
                    normalimg.color = new Color32(124, 255, 107, 255);
                    break;
                case 3:
                    highimg.color = new Color32(124, 255, 107, 255);
                    break;
            }
        }
        if (backChooseMenu == true)
        {
            ChooseMenuUI.SetActive(false);
            MenuUI.SetActive(true);
        }
        if (No == true)
        {
            NewGameUI.SetActive(false);
        }
        if (Yes == true)
        {
           // PlayerPrefs.SetInt("Level", 0);
           // Debug.Log("Уровень=" + PlayerPrefs.GetInt("Level"));
           // Level = PlayerPrefs.GetInt("Level");
            SceneManager.LoadScene("CastScene1"); ;
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.SetInt("MaxLevel", 1);
        }
        if (ChooseLevel == true)
        {
            MenuUI.SetActive(false);
            ChooseLevelUI.SetActive(true);
        }
        if (BackChooseLevelUI == true)
        {
            MenuUI.SetActive(true);
            ChooseLevelUI.SetActive(false);
        }
    }
}
