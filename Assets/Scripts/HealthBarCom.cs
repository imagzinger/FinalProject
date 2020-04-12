using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarCom : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Target com;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = com.health;
    }
}
