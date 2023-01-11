using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    [SerializeField] private Text _resultText;
    [SerializeField] private Text _pinText1;
    [SerializeField] private Text _pinText2;
    [SerializeField] private Text _pinText3;

    [SerializeField] private int _toolForPin1 = 5;
    [SerializeField] private int _toolForPin2 = 5;
    [SerializeField] private int _toolForPin3 = 5;


    private int _currectPin1 = 0;
    private int _currectPin2 = 9;
    private int _currectPin3 = 9;

    private float _lastTime;
    private int _fixedTime = 5;
    private float _currectTime;

    private void Start()
    {
        RewriteTheValues();
    }

    private void Update()
    {
        _currectTime = Mathf.Round(_fixedTime - Time.time);
        _timerText.text = _currectTime.ToString();
    }


    public void Change(int pin1, int pin2, int pin3)
    {
        _toolForPin1 += pin1;
        _toolForPin2 += pin2;
        _toolForPin3 += pin3;

        _toolForPin1 = Mathf.Clamp(_toolForPin1, 0, 9);
        _toolForPin2 = Mathf.Clamp(_toolForPin2, 0, 9);
        _toolForPin3 = Mathf.Clamp(_toolForPin3, 0, 9);
        RewriteTheValues();
    }

    private void RewriteTheValues()
    {
        _pinText1.text = $"{_toolForPin1}";
        _pinText2.text = $"{_toolForPin2}";
        _pinText3.text = $"{_toolForPin3}";

        Play();
    }

    private void Play()
    {
        if (_toolForPin1 == _currectPin1 && _currectPin2 == _toolForPin2 && _currectPin3 == _toolForPin3)
        {
            Debug.Log(_resultText.text = "Вы победили");
        }
        else if (_currectTime == 0)
        {
            Debug.Log(_resultText.text = "Поражение");
        }
    }
}
