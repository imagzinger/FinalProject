using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] PlayerController player;
    GameObject gameManager;
    int characterClass;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController");
        characterClass = gameManager.GetComponent<GameManager>().GetClass();
        if (characterClass == 0)
        {
            characterClass = 1;
        }
        if (characterClass == 1)
        {
            slider.maxValue = 500f;
        }
        if (characterClass == 2)
        {
            slider.maxValue = 800f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.health;
    }
}
