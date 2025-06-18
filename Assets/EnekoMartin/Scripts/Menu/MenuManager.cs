using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
        // Cargar idioma guardado
        int savedLang = PlayerPrefs.GetInt("language", 0);
        languageDropdown.value = savedLang;
        ChangeLanguage(savedLang);

        // Cargar puntuaci�n guardada
        int savedScore = PlayerPrefs.GetInt("puntObj", 10);
        if (savedScore == 20) scoreDropdown.value = 1;
        else if (savedScore == 30) scoreDropdown.value = 2;
        else scoreDropdown.value = 0;
    }

    public void OnOkPressed()
    {
        // Guardar idioma
        int lang = languageDropdown.value;
        PlayerPrefs.SetInt("language", lang);
        ChangeLanguage(lang);

        // Guardar puntuaci�n objetivo
        int dropdownValue = scoreDropdown.value;
        if (dropdownValue == 1) targetScore = 20;
        else if (dropdownValue == 2) targetScore = 30;
        else targetScore = 10;

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
            titleText.text = "Men� Principal";
            scoreLabel.text = "Puntuaci�n Objetivo";
            languageLabel.text = "Idioma";
            okButtonText.text = "OK";
            easyButtonText.text = "Modo F�cil";
            hardButtonText.text = "Modo Dif�cil";
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
        SceneManager.LoadScene("NivelFacil");
    }

    public void PlayHardMode()
    {
        SceneManager.LoadScene("NivelDificil");
    }
}
