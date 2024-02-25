using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SwitchSceneCoroutine());
    }

    IEnumerator SwitchSceneCoroutine()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);

    }
}
