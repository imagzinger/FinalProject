using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenController : MonoBehaviour
{
    [SerializeField] Slider sensSlider;
    [SerializeField] Text sensText;
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject optionsCanvas;
    bool inOptions = false;

    // Start is called before the first frame update
    void Start()
    {
        sensSlider.value = PlayerPrefs.GetFloat("Sens");
        if (sensSlider.value == .1) {
            sensSlider.value = 2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        sensText.text = "" + sensSlider.value;
        PlayerPrefs.SetFloat("Sens", sensSlider.value);
    }

    public void StartGame() {
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back() {
        optionsCanvas.SetActive(false);
        mainCanvas.SetActive(true);
        inOptions = false;
    }

    public void Options() {
        mainCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
        inOptions = true;
    }
}
