using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isEarthquakeStarted = false;
    public float magnitude = 0;
    public EarthquakeController earthquakeController;
    private Dictionary<float, float[]> magnitudeParameters;

    public GameObject openingScreenSelection;
    public GameObject experimentModeUI;
    public GameObject storylineModeUI;
    public GameObject storylineEnd;

    public GameObject questionOne;
    public GameObject questionTwo;
    public GameObject questionThree;
    public GameObject questionFour;
    public GameObject questionFive;

    private WaitForSeconds delay = new WaitForSeconds(1f);

    private void Start()
    {
        magnitudeParameters = new Dictionary<float, float[]>();

        // Add the parameter values for each magnitude
        magnitudeParameters.Add(0.0f, new float[] { 0.0f, 0.0f, 0.0f });
        magnitudeParameters.Add(3.0f, new float[] { 0.03f, 0.3f, 0.02f });
        magnitudeParameters.Add(4.0f, new float[] { 0.04f, 0.4f, 0.03f });
        magnitudeParameters.Add(5.0f, new float[] { 0.05f, 0.5f, 0.04f });
        magnitudeParameters.Add(6.0f, new float[] { 0.06f, 0.6f, 0.05f });
        magnitudeParameters.Add(7.0f, new float[] { 0.07f, 0.7f, 0.06f });
        magnitudeParameters.Add(8.0f, new float[] { 0.08f, 0.8f, 0.07f });
        magnitudeParameters.Add(9.0f, new float[] { 0.09f, 0.9f, 0.08f });

        openingScreenSelection.SetActive(false);
        experimentModeUI.SetActive(false);
        storylineModeUI.SetActive(false);
        questionOne.SetActive(false);
        questionTwo.SetActive(false);
        questionThree.SetActive(false);
        storylineEnd.SetActive(false);
        questionFour.SetActive(false);
        questionFive.SetActive(false);

        magnitude = 0.0f;
        StartEarthquake();
        ShowOpeningScreenSelection();
    }

    public void StartEarthquakeStoryline()
    {
        magnitude = 4.0f;
        isEarthquakeStarted = true;
        earthquakeController.radiusGrowthRate = magnitudeParameters[magnitude][0];
        earthquakeController.maxHeight = magnitudeParameters[magnitude][1];
        earthquakeController.heightChangeRate = magnitudeParameters[magnitude][2];

        earthquakeController.StartEarthquake();
        Debug.Log("Earthquake Starting.");
    }

    public void StartEarthquake()
    {
        isEarthquakeStarted = true;
        earthquakeController.radiusGrowthRate = magnitudeParameters[magnitude][0];
        earthquakeController.maxHeight = magnitudeParameters[magnitude][1];
        earthquakeController.heightChangeRate = magnitudeParameters[magnitude][2];

        earthquakeController.StartEarthquake();
        Debug.Log("Earthquake Starting.");
    }

    public void StopEarthquake()
    {
        magnitude = 0.0f;
        earthquakeController.StopEarthquake();
    }

    public void ShowOpeningScreenSelection()
    {
        openingScreenSelection.SetActive(true);
        experimentModeUI.SetActive(false);
        storylineModeUI.SetActive(false);
    }
    public void SelectExperimentMode()
    {
        openingScreenSelection.SetActive(false);
        experimentModeUI.SetActive(true);
        storylineModeUI.SetActive(false);
    }

    public void SelectStorylineMode()
    {
        openingScreenSelection.SetActive(false);
        experimentModeUI.SetActive(false);
        storylineModeUI.SetActive(true);
        Debug.Log("Selected Storyline Mode");
    }

    public void BeginStorylineMode()
    {
        openingScreenSelection.SetActive(false);
        experimentModeUI.SetActive(false);
        storylineModeUI.SetActive(false);
        questionOne.SetActive(false);
        questionTwo.SetActive(false);
        questionThree.SetActive(false);
        questionFour.SetActive(false);
        questionFive.SetActive(false);
        storylineEnd.SetActive(false);
        StartEarthquakeStoryline();

        ShowQuestionOne();
        
    }

    public void ShowQuestionOne()
    {
        StartCoroutine(ShowQuestionOneTrue());

    }

    public IEnumerator ShowQuestionOneTrue()
    {
        yield return delay;
        openingScreenSelection.SetActive(false);
        experimentModeUI.SetActive(false);
        storylineModeUI.SetActive(false);
        questionOne.SetActive(true);
        questionTwo.SetActive(false);
        questionThree.SetActive(false);
        questionFour.SetActive(false);
        questionFive.SetActive(false);
        storylineEnd.SetActive(false);

    }


    public void ShowQuestionTwo()
    {
        StartCoroutine(ShowQuestionTwoTrue());
    }

    public IEnumerator ShowQuestionTwoTrue()
    {
        yield return delay;
        openingScreenSelection.SetActive(false);
        experimentModeUI.SetActive(false);
        storylineModeUI.SetActive(false);
        questionOne.SetActive(false);
        questionTwo.SetActive(true);
        questionThree.SetActive(false);
        questionFour.SetActive(false);
        questionFive.SetActive(false);
        storylineEnd.SetActive(false);

    }

    public void ShowQuestionThree()
    {
        StartCoroutine(ShowQuestionThreeTrue());
    }

    public IEnumerator ShowQuestionThreeTrue()
    {
        yield return delay;
        openingScreenSelection.SetActive(false);
        experimentModeUI.SetActive(false);
        storylineModeUI.SetActive(false);
        questionOne.SetActive(false);
        questionTwo.SetActive(false);
        questionThree.SetActive(true);
        questionFour.SetActive(false);
        questionFive.SetActive(false);
        storylineEnd.SetActive(false);
    }

    public void ShowQuestionFour()
    {
        StartCoroutine(ShowQuestionFourTrue());
    }

    public IEnumerator ShowQuestionFourTrue()
    {
        yield return delay;
        openingScreenSelection.SetActive(false);
        experimentModeUI.SetActive(false);
        storylineModeUI.SetActive(false);
        questionOne.SetActive(false);
        questionTwo.SetActive(false);
        questionThree.SetActive(false);
        questionFour.SetActive(true);
        questionFive.SetActive(false);
        storylineEnd.SetActive(false);
    }

    public void ShowQuestionFive()
    {
        StartCoroutine(ShowQuestionFiveTrue());
    }
    public IEnumerator ShowQuestionFiveTrue()
    {
        yield return delay;
        openingScreenSelection.SetActive(false);
        experimentModeUI.SetActive(false);
        storylineModeUI.SetActive(false);
        questionOne.SetActive(false);
        questionTwo.SetActive(false);
        questionThree.SetActive(false);
        questionFour.SetActive(false);
        questionFive.SetActive(true);
        storylineEnd.SetActive(false);
    }

    public void ShowStorylineEnd()
    {
        StartCoroutine(ShowStorylineEndTrue());
    }

    public IEnumerator ShowStorylineEndTrue()
    {
        yield return delay;
        openingScreenSelection.SetActive(false);
        experimentModeUI.SetActive(false);
        storylineModeUI.SetActive(false);
        questionOne.SetActive(false);
        questionTwo.SetActive(false);
        questionThree.SetActive(false);
        questionFour.SetActive(false);
        questionFive.SetActive(false);
        storylineEnd.SetActive(true);
    }

    public void RestartSimulation()
    {
        StartCoroutine(RestartSimulationTrue());
        
    }
    public IEnumerator RestartSimulationTrue()
    {
        yield return delay;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
