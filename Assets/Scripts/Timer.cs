using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;

    private float time;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int minute = Mathf.FloorToInt(time / 60);
        int seconde = Mathf.FloorToInt(time % 60);
        timer.text = string.Format("{0:00}:{1:00}", minute, seconde);
    }
}
