using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{

    [SerializeField] GameObject levelCanvas;
    [SerializeField] GameObject characterCanvas;
    string name;

    public void SelectLevel(string levelName) {
        name = levelName;
        levelCanvas.SetActive(false);
        characterCanvas.SetActive(true);
    }

    public void CharacterSelect(int characterClass) {
        PlayerPrefs.SetInt("Class", characterClass);
        SceneManager.LoadScene(name);
    }

    public void Back() {
        characterCanvas.SetActive(false);
        levelCanvas.SetActive(true);
    }

    public void Title() {
        SceneManager.LoadScene("Title");
    }
}
