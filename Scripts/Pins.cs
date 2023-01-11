using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pins : MonoBehaviour
{
    public GameScript gameScript;

    [SerializeField] private int _pin1;
    [SerializeField] private int _pin2;
    [SerializeField] private int _pin3;

    public void Use()
    {
        gameScript.Change(_pin1,_pin2,_pin3);
    }
}
