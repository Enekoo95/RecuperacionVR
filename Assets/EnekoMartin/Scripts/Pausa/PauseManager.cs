using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseManager : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenu;
    public TMP_Text pauseTitleText;
    public TMP_Text resumeButtonText;
    public TMP_Text exitButtonText;

    private string currentLanguage;

    void Start()
    {
        pauseMenu.SetActive(false);
        int langInt = PlayerPrefs.GetInt("language", 0);
        currentLanguage = langInt == 0 ? "es" : "en";
        UpdateLanguageText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitToMenu()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuInicial");
    }

    void UpdateLanguageText()
    {
        if (currentLanguage == "es")
        {
            pauseTitleText.text = "Juego en Pausa";
            resumeButtonText.text = "Continuar";
            exitButtonText.text = "Salir";
        }
        else
        {
            pauseTitleText.text = "Game Paused";
            resumeButtonText.text = "Resume";
            exitButtonText.text = "Exit";
        }
    }
}
