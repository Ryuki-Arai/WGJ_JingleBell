using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    [SerializeField , Header("スコアを表示するテキスト")]
    Text _scoreText;

    [SerializeField , Header("タバコのイメージ画像")]
    Image _smongImage;

    [SerializeField　, Header("フィーバーのイメージ画像")]
    Image _fevarImage;

    [SerializeField , Header("扇ゲージのスライダー")]
    Slider _gaugeSlider;

    [SerializeField, Header("スコアの変化にかける時間")]
    float _changeValueInterval;

    [SerializeField, Header("扇ゲージの変化にかける時間")]
    float _changeGaugeInterval;

    //画像を表示する時間
    float _imageInterval;

    //画像表示の計測用
    float _timer;

    Tweener tween;

    private void Update()
    {
        if (_imageInterval > 0) 
        {
            _timer += Time.deltaTime;

            if (_timer > _imageInterval) 
            {
                if (_smongImage.enabled) 
                {
                    //消すアニメーションを再生
                }
                else 
                { 
                    //フィーバーを止めるアニメーションを再生
                }

                _imageInterval = 0;
                _timer = 0;
            }
        }
    }

    /// <summary>
    /// スコアをDotweenで動的に表示する
    /// </summary>
    public void ScoreInterpolation(float scoreValue) 
    {
        float sliderValue = float.Parse(_scoreText.text);

        DOTween.To(() => sliderValue, // 連続的に変化させる対象の値
            x => sliderValue = x, // 変化させた値 x をどう処理するかを書く
            scoreValue, // x をどの値まで変化させるか指示する
            _changeValueInterval)
            .OnUpdate(() => _scoreText.text = sliderValue.ToString("000"));
    }

    /// <summary>
    /// 扇ゲージをDotweenで動的に表示する
    /// </summary>
    public void GaugeInterpolation(float gaugeValue) 
    {
        DOTween.To(() => _gaugeSlider.value, // 連続的に変化させる対象の値
            x => _gaugeSlider.value = x, // 変化させた値 x をどう処理するかを書く
            gaugeValue, // x をどの値まで変化させるか指示する
            _changeGaugeInterval);
    }

    /// <summary>
    /// 
    /// </summary>
    public void IndicateSmoke(float interval) 
    {
        _imageInterval = interval;
        _timer = 0;
        //_smongImageのアニメーションを再生
    }

    /// <summary>
    /// 
    /// </summary>
    public void IndicateFevar(float interval) 
    {
        if (_smongImage.enabled)
        {
            //消すアニメーションを再生
        }
        _imageInterval = interval;
        _timer = 0;
        //_fevarImageのアニメーションを再生
    }
}
