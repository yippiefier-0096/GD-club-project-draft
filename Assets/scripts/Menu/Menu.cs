using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private static int BackToWhere;
    public void GameStart()
    {
        gameManager.loadFromFile(0);
    }

    public void SettingMenu()
    {
        BackToWhere=0;
        SceneManager.LoadScene(1);
    }

    public void SoundMenu()
    {
        SceneManager.LoadScene(3);
    }

    public void ExitGame()
    {   
        Application.Quit();
    }
    public void DeleteSave()
    {
        PlayerPrefs.SetString("Save","");
    }
    public void Back()
    {
        if (BackToWhere == 0)
        {
            SceneManager.LoadScene(0);
        }
        if (BackToWhere == 1)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//press esc to setting
        {
            BackToWhere = 1;
            SceneManager.LoadScene(1);
        }
    }
}
