using System.Collections;
using UnityEngine;

public class EarthquakeController : MonoBehaviour
{
    public float startRadius = 100.0f;
    public float endRadius = 500.0f;
    public float radiusGrowthRate = 0.1f;
    public float maxHeight = 5.0f;
    public float minHeight = -5.0f;
    public float heightChangeRate = 0.1f;
    public float duration = 10.0f;

    public float startTime;

    private Coroutine earthquakeCoroutine;

    public IEnumerator WaitAndStartEarthquake(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        StartEarthquake();
    }

    public void StartEarthquake()
    {
        if (!GameManager.isEarthquakeStarted)
        {
            return;
        }

        startTime = Time.time;
        float currentRadius = startRadius;
        float currentHeight = transform.position.y;

        earthquakeCoroutine = StartCoroutine(UpdateEarthquake(currentRadius, currentHeight));
    }

    public void StopEarthquake()
    {
        if (earthquakeCoroutine != null)
        {
            StopCoroutine(earthquakeCoroutine);
            earthquakeCoroutine = null;
        }
    }
    public IEnumerator UpdateEarthquake(float currentRadius, float currentHeight)
    {
        while (true)
        {
            currentRadius += radiusGrowthRate;
            float speed = 1.0f - (currentRadius - startRadius) / (endRadius - startRadius);
            currentHeight += Random.Range(-heightChangeRate, heightChangeRate) * speed;
            currentHeight = Mathf.Clamp(currentHeight, minHeight, maxHeight);

            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

            yield return null;
        }
    }
}
