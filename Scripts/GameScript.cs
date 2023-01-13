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

    [SerializeField] private int _currectPin1 = 0;
    [SerializeField] private int _currectPin2 = 9;
    [SerializeField] private int _currectPin3 = 9;

    private bool _inPlayMode = true;

    private float _specifiedTime = 60;
    private float _currectTime;

    private int _pin1;
    private int _pin2;
    private int _pin3;

    private void Start()
    {
        RewriteTheValues();
    }

    private void Update()
    {
        if (_inPlayMode)
        {
            WorkingTime();
        }
    }

    private void WorkingTime()
    {
        _currectTime = Mathf.Round(_specifiedTime - Time.time);
        _timerText.text = _currectTime.ToString();
    }

    public void UseDriil()
    {
        _pin1 += +1;
        _pin2 += -1;
        _pin3 += 0;
        ChekOutPin();
        RewriteTheValues();
        Play();
    }

    public void UseHammer()
    {
        _pin1 += -1;
        _pin2 += 2;
        _pin3 += -1;
        ChekOutPin();
        RewriteTheValues();
        Play();
    }

    public void UseLockPick()
    {
        _pin1 += -1;
        _pin2 += 1;
        _pin3 += 1;
        ChekOutPin();
        RewriteTheValues();
        Play();
    }

    public void ChekOutPin()
    {
        _pin1 = Mathf.Clamp(_pin1, 0, 9);
        _pin2 = Mathf.Clamp(_pin2, 0, 9);
        _pin3 = Mathf.Clamp(_pin3, 0, 9);
        RewriteTheValues();
    }

    private void RewriteTheValues()
    {
        _pinText1.text = $"{_pin1}";
        _pinText2.text = $"{_pin2}";
        _pinText3.text = $"{_pin3}";
    }

    private void Play()
    {
        if (_pin1 == _currectPin1 && _currectPin2 == _pin2 && _currectPin3 == _pin3)
        {
            _resultText.text = "Вы победили";
            _inPlayMode = false;
        }
        else if (_currectTime == 0)
        {
            _resultText.text = "Вы проиграли";
            _inPlayMode = false;
        }
    }

    public void ResetGame()
    {
        _inPlayMode = true;
        _resultText.text = " ";

        _pin1 = 0;
        _pin2 = 0;
        _pin3 = 0;

        RewriteTheValues();
    }
}
