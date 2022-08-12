using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private int level;


    private void Start()
    {
        level = PlayerPrefs.GetInt("Level");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && level == 8)
        {
            SceneManager.LoadScene("Diplom");
        }
        if (other.gameObject.tag == "Player" && level == 7)
        {
            if (PlayerPrefs.GetInt("MaxLevel") == PlayerPrefs.GetInt("Level"))
            {
                PlayerPrefs.SetInt("MaxLevel", PlayerPrefs.GetInt("MaxLevel") + 1);
            }
            SceneManager.LoadScene("CastScene8");
            PlayerPrefs.SetInt("Level", 8);
        }
        if (other.gameObject.tag == "Player" && level == 6)
        {
            if (PlayerPrefs.GetInt("MaxLevel") == PlayerPrefs.GetInt("Level"))
            {
                PlayerPrefs.SetInt("MaxLevel", PlayerPrefs.GetInt("MaxLevel") + 1);
            }
            SceneManager.LoadScene("CastScene7");
            PlayerPrefs.SetInt("Level", 7);
        }
        if (other.gameObject.tag == "Player" && level == 5)
        {
            if (PlayerPrefs.GetInt("MaxLevel") == PlayerPrefs.GetInt("Level"))
            {
                PlayerPrefs.SetInt("MaxLevel", PlayerPrefs.GetInt("MaxLevel") + 1);
            }
            SceneManager.LoadScene("CastScene6");
            PlayerPrefs.SetInt("Level", 6);
        }
        if (other.gameObject.tag == "Player" && level == 4)
        {
            if (PlayerPrefs.GetInt("MaxLevel") == PlayerPrefs.GetInt("Level"))
            {
                PlayerPrefs.SetInt("MaxLevel", PlayerPrefs.GetInt("MaxLevel") + 1);
            }
            SceneManager.LoadScene("CastScene5");
            PlayerPrefs.SetInt("Level", 5);
        }

        if (other.gameObject.tag == "Player" && level == 3)
        {
            if (PlayerPrefs.GetInt("MaxLevel") == PlayerPrefs.GetInt("Level"))
            {
                PlayerPrefs.SetInt("MaxLevel", PlayerPrefs.GetInt("MaxLevel") + 1);
            }
            SceneManager.LoadScene("CastScene4");
            PlayerPrefs.SetInt("Level", 4);
        }

        if (other.gameObject.tag == "Player" && level == 2)
        {
            if (PlayerPrefs.GetInt("MaxLevel") == PlayerPrefs.GetInt("Level"))
            {
                PlayerPrefs.SetInt("MaxLevel", PlayerPrefs.GetInt("MaxLevel") + 1);
            }
            SceneManager.LoadScene("CastScene3");
            PlayerPrefs.SetInt("Level", 3);
        }
        if (other.gameObject.tag == "Player" && level==1)
        {
            if (PlayerPrefs.GetInt("MaxLevel") == PlayerPrefs.GetInt("Level"))
            {
                PlayerPrefs.SetInt("MaxLevel", PlayerPrefs.GetInt("MaxLevel") + 1);
            }
            SceneManager.LoadScene("CastScene2"); 
            PlayerPrefs.SetInt("Level", 2);
        }
        
    }
}
