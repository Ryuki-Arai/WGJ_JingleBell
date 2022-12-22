using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ResultChange : MonoBehaviour
{
    [SerializeField]
    Sprite _badImage = null;
    [SerializeField]
    Sprite _normalImage = null;
    [SerializeField]
    Sprite _happyImage = null;
    Image _panelImage = null;
    [SerializeField]
    GameObject _panel = null;
    [SerializeField]
    TextMeshProUGUI _scoreText = null;
    [SerializeField]
    int _badScore = 0;
    [SerializeField]
    int _normalScore = 0;
    [SerializeField]
    int _happyScore = 0;

    private void Start()
    {
        _panelImage = _panel.GetComponent<Image>();
    }
    // Update is called once per frame
    public void Result(int score)
    {
        if(_happyScore <= score)
        {
            _panelImage.sprite = _happyImage;
        }
        else if(_normalScore <= score)
        {
            _panelImage.sprite = _normalImage;
        }
        else 
        {
            _panelImage.sprite = _badImage;
        }
        _scoreText.text = "Score" + ":" + score.ToString();
    }
}
