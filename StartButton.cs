using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button startButton;
    public Slider magSlider;
    public GameManager gameManager;

    private void Start()
    {
        magSlider = magSlider.GetComponent<Slider>();
        startButton.onClick.AddListener(StartEarthquake);

    }

    public void StartEarthquake()
    {
        Debug.Log("START BUTTON CLICKED");
        gameManager.magnitude = magSlider.value;
        gameManager.StartEarthquake();
    }
}


