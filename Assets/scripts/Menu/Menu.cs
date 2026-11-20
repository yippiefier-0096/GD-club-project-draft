using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private static int BackToWhere;
    public void GameStart()
    {
        GetWhere();
        gameManager.loadFromFile();
    }

    public void SettingMenu()
    {
        GetWhere();
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene(BackToWhere);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//press esc to setting
        {
            if (Where() == 0)
                return;
            else if (Where() == 1)
            {
                GetWhere();
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(BackToWhere);
            }
        }
    }
    private void GetWhere()
    {
        BackToWhere = Where();
    }


    private int Where()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        return i;
    }
    public void DeleteSave()
    {
        PlayerPrefs.SetString("Save", "");
    }
}