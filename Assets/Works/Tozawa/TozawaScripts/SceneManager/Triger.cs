using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triger : MonoBehaviour
{
    public static bool _fadeDone = false;
    private void Start()
    {
        _fadeDone = false;
    }
    public void TrigerAnimEvent()
    {
        _fadeDone = true;
    }
}
