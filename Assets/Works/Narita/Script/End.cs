using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class End : MonoBehaviour
{
    float timer = 0;
    float interval = 60f;
    [SerializeField]
    Canvas _canvas = null;
    [SerializeField]
    TextMeshProUGUI _text = null;
    // Start is called before the first frame update
    void Start()
    {
        _canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        interval -= Time.deltaTime;
        if(timer >= interval)
        {
            _canvas.enabled = true;
            interval = 0;
        }
        _text.text = interval.ToString();
    }
}
