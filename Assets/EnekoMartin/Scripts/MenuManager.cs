using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; // Si usas TextMeshPro

public class MenuManagerXR : MonoBehaviour
{
    public Dropdown scoreDropdown;
    public Dropdown languageDropdown;

    public Text titleText;
    public Text scoreLabel;
    public Text languageLabel;
    public TMP_Text okButtonText;
    public Text easyButtonText;
    public Text hardButtonText;

    private int targetScore;
    private string currentLanguage = "es";

    void Start()
    {
        int savedLang = PlayerPrefs.GetInt("language", 0);
        languageDropdown.value = savedLang;
        ChangeLanguage(savedLang);

        int savedScore = PlayerPrefs.GetInt("puntObj", 5);
        if (savedScore == 10) scoreDropdown.value = 1;
        else if (savedScore == 15) scoreDropdown.value = 2;
        else scoreDropdown.value = 0;
    }

    public void OnOkPressed()
    {
        // Guardar idioma
        int lang = languageDropdown.value;
        PlayerPrefs.SetInt("language", lang);
        ChangeLanguage(lang);

        // Guardar puntuación objetivo
        int dropdownValue = scoreDropdown.value;
        if (dropdownValue == 1) targetScore = 10;
        else if (dropdownValue == 2) targetScore = 15;
        else targetScore = 5;
        PlayerPrefs.SetInt("puntObj", targetScore);
    }

    public void changeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ChangeLanguage(int lang)
    {
        currentLanguage = lang == 0 ? "es" : "en";

        if (currentLanguage == "es")
        {
            titleText.text = "Menú Principal";
            scoreLabel.text = "Puntuación Objetivo";
            languageLabel.text = "Idioma";
            okButtonText.text = "OK";
            easyButtonText.text = "Modo Fácil";
            hardButtonText.text = "Modo Difícil";
        }
        else
        {
            titleText.text = "Main Menu";
            scoreLabel.text = "Target Score";
            languageLabel.text = "Language";
            okButtonText.text = "OK";
            easyButtonText.text = "Easy Mode";
            hardButtonText.text = "Hard Mode";
        }
    }

    public void PlayEasyMode()
    {
        SceneManager.LoadScene("EscenaFacil");
    }

    public void PlayHardMode()
    {
        SceneManager.LoadScene("EscenaDificil");
    }
}
