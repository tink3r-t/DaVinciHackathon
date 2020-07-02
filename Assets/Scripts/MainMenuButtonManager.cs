using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuButtonManager : MonoBehaviour
{
    public List<string> texts_deutsch;
    public List<string> texts_english;
    public AudioSource ass;

    public GameObject cL, cR;

    public List<TextMeshPro> textMesh;

    private void Start()
    {
        cR.transform.DOMoveX(11.76f, 2.0f);
        cL.transform.DOMoveX(-11.56f, 2.0f);

        texts_deutsch.Add("Fortsetzen");
        texts_deutsch.Add("Neus Speil");
        texts_deutsch.Add("Sprache : Deutsch");
        texts_deutsch.Add("Musik");
        texts_deutsch.Add("Besetzung");
        texts_deutsch.Add("Einstellungen :");

        texts_english.Add("Continue");
        texts_english.Add("New Game");
        texts_english.Add("Language : English");
        texts_english.Add("Music");
        texts_english.Add("Cast");
        texts_english.Add("Settings");

        UpdateLanguage();

    }

    public void NewGame() {
        cR.transform.DOMoveX(4.59f,2.0f);
        cL.transform.DOMoveX(-4.26f, 2.0f).OnComplete( ()=> { SceneManager.LoadScene(1); }) ;
    }

    public void MusicToggle() {
        ass.enabled = !ass.enabled;
        textMesh[3].fontStyle = !ass.enabled ? FontStyles.Bold | FontStyles.Strikethrough | FontStyles.SmallCaps  : FontStyles.Bold | FontStyles.SmallCaps;

    }

    public void LanguageChange()
    {
        UpdateLanguage();
    }

    void UpdateLanguage() {
        if (Preferences.LanguageInt == (int)LANGUAGE.EN)
        {
            Preferences.LanguageInt = (int)LANGUAGE.DE;
            for (int i = 0; i < textMesh.Count; i++)
            {
                textMesh[i].text = texts_deutsch[i];
            }
        }
        else {
            Preferences.LanguageInt = (int)LANGUAGE.EN;
            for (int i = 0; i < textMesh.Count; i++)
            {
                textMesh[i].text = texts_english[i];
            }
        }

    }

}
