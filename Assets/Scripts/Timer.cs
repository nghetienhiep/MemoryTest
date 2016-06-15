using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    void Start()
    {
        GameManager.main.CallTimer();
    }
}
