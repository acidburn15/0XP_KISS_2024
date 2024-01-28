using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class FadeEffect : MonoBehaviour
{
    public PostProcessVolume volume;
    private ColorGrading colorGrading;

    public float fadeDuration = 2.0f;

    [SerializeField] private static FadeEffect s_Instance;

    public static FadeEffect Instance
    {
        get { return s_Instance; }
    }

    private void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        volume.profile.TryGetSettings(out colorGrading);
    }
    public void FadeStart()
    {
        StartCoroutine(FadeIn());
        colorGrading.postExposure.value = -12f;
        Debug.Log("FADE");
    }
    IEnumerator FadeIn()
    {
        float startExposure = colorGrading.postExposure.value;
        float endExposure = 0f; // valeur normale

        float elapsedTime = 0f;
        startExposure = -12f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newExposure = Mathf.Lerp(startExposure, endExposure, elapsedTime / fadeDuration);
            colorGrading.postExposure.value = newExposure;
            yield return null;
        }
    }
}
