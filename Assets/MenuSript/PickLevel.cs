using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickLevel : MonoBehaviour
{
    public Button yourButton;
    public bool Первый;
    public bool Второй;
    public bool Третий;
    public bool Четвертый;
    public bool Пятый;
    public bool Шестой;
    public bool Седьмой;
    public bool Восьмой;
    public bool LevelSet = false;
    public GameObject два;
    public GameObject три;
    public GameObject четыре;
    public GameObject пять;
    public GameObject шесть;
    public GameObject семь;
    public GameObject восемь;


    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClick()
    {
        if (Первый == true)
        {
            PlayerPrefs.SetInt("Level",1);
            SceneManager.LoadScene("CastScene1");
        }
        if (Второй == true)
        {
            PlayerPrefs.SetInt("Level", 2);
            SceneManager.LoadScene("CastScene2");
        }
        if (Третий == true)
        {
            PlayerPrefs.SetInt("Level", 3);
            SceneManager.LoadScene("CastScene3");
        }
        if (Четвертый == true)
        {
            PlayerPrefs.SetInt("Level", 4);
            SceneManager.LoadScene("CastScene4");
        }
        if (Пятый == true)
        {
            PlayerPrefs.SetInt("Level", 5);
            SceneManager.LoadScene("CastScene5");
        }
        if (Шестой == true)
        {
            PlayerPrefs.SetInt("Level", 6);
            SceneManager.LoadScene("CastScene6");
        }
        if (Седьмой == true)
        {
            PlayerPrefs.SetInt("Level", 7);
            SceneManager.LoadScene("CastScene7");
        }
        if (Восьмой == true)
        {
            PlayerPrefs.SetInt("Level", 8);
            SceneManager.LoadScene("CastScene8");
        }

        if (LevelSet == true)
        {
            switch (PlayerPrefs.GetInt("MaxLevel"))
            {
                case 2:
                    два.SetActive(false);
                    break;
                case 3:
                    два.SetActive(false);
                    три.SetActive(false);
                    break;
                case 4:
                    два.SetActive(false);
                    три.SetActive(false);
                    четыре.SetActive(false);
                    break;
                case 5:
                    два.SetActive(false);
                    три.SetActive(false);
                    четыре.SetActive(false);
                    пять.SetActive(false);
                    break;
                case 6:
                    два.SetActive(false);
                    три.SetActive(false);
                    четыре.SetActive(false);
                    пять.SetActive(false);
                    шесть.SetActive(false);
                    break;
                case 7:
                    два.SetActive(false);
                    три.SetActive(false);
                    четыре.SetActive(false);
                    пять.SetActive(false);
                    шесть.SetActive(false);
                    семь.SetActive(false);
                    break;
                case 8:
                    два.SetActive(false);
                    три.SetActive(false);
                    четыре.SetActive(false);
                    пять.SetActive(false);
                    шесть.SetActive(false);
                    семь.SetActive(false);
                    восемь.SetActive(false);
                    break;

            }
        }
    }
}
