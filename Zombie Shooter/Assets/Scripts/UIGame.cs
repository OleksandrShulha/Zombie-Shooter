using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGame : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    [SerializeField] Health playrHealth;

    [SerializeField] TextMeshProUGUI scroreText;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }


    void Start()
    {
        hpSlider.maxValue = playrHealth.GetHealt();
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = playrHealth.GetHealt();
        scroreText.text = scoreKeeper.GetCurentScore().ToString();
    }
}
