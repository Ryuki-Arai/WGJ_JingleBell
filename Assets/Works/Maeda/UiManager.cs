using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;

public class UiManager : MonoBehaviour
{
    [SerializeField, Header("スコアを表示するテキスト")]
    Text _scoreText;

    [SerializeField, Header("ゲームの制限時間を表示するテキスト")]
    Text _timeText;

    [SerializeField, Header("タバコのイメージ画像")]
    Image _smongImage;

    [SerializeField, Header("フィーバーのイメージ画像")]
    Image _fevarImage;

    [SerializeField, Header("扇ゲージのスライダー")]
    Slider _fanGaugeSlider;

    [SerializeField, Header("フィーバーゲージのスライダー")]
    Slider _fevarGaugeSlider;

    [SerializeField, Header("スコアの変化にかける時間")]
    float _changeValueInterval;

    [SerializeField, Header("扇ゲージの変化にかける時間")]
    float _changeFanGaugeInterval;

    [SerializeField, Header("フィーバーゲージの変化にかける時間")]
    float _changeFevarGaugeInterval;

    [SerializeField, Header("ゲームの制限時間")]
    float _gameTime;

    [SerializeField, Header("煙草を表示する時間")]
    float _smongTime;

    [SerializeField, Header("フィーバーの時間")]
    float _fevarTime;

    ReactiveProperty<GameState> _changeState = new ReactiveProperty<GameState>();

    //扇ゲージの最大
    const float _fanSliderValueMax = 100;

    //フィーバーゲージの最大
    const float _fevarSliderValueMax = 100;

    //ゲーム時間の計測用
    float _timer;

    //画像を表示する時間
    float _imageInterval;

    //画像表示の計測用
    float _imgTimer;

    public IReadOnlyReactiveProperty<GameState> ChangeState => _changeState;

    private void Start()
    {
        //_fevarGaugeSlider.maxValue = _fevarSliderValueMax;
        //_fanGaugeSlider.maxValue = _fanSliderValueMax;

        _timer = _gameTime;
        _timeText.text = _timer.ToString("00");

        StartCoroutine(GameTime());
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
    public void FanGaugeInterpolation(float gaugeValue)
    {
        if (gaugeValue > _fanSliderValueMax) { gaugeValue = _fanSliderValueMax; }
        else if (gaugeValue == _fanSliderValueMax) { return; }

        DOTween.To(() => _fanGaugeSlider.value, // 連続的に変化させる対象の値
            x => _fanGaugeSlider.value = x, // 変化させた値 x をどう処理するかを書く
            gaugeValue, // x をどの値まで変化させるか指示する
            _changeFanGaugeInterval);
    }

    /// <summary>
    /// フィーバーゲージをDotweenで動的に表示する
    /// </summary>
    public void FevarGaugeInterpolation(float gaugeValue)
    {
        if (_changeState.Value != GameState.Fevar)
        {
            if (gaugeValue > _fevarSliderValueMax) { gaugeValue = _fevarSliderValueMax; }
            
            DOTween.To(() => _fevarGaugeSlider.value, // 連続的に変化させる対象の値
                x => _fevarGaugeSlider.value = x, // 変化させた値 x をどう処理するかを書く
                gaugeValue, // x をどの値まで変化させるか指示する
                _changeFevarGaugeInterval).OnComplete(() => IndicateFevar());
        }
    }

    /// <summary>
    /// 煙草の演出を表示する
    /// </summary>
    public void IndicateSmoke()
    {
        if (_changeState.Value != GameState.Fevar && _changeState.Value != GameState.Finish) 
        {
            if (_imgTimer > 0) { StartCoroutine(ImageTime()); }

            _imageInterval = _smongTime;
            _imgTimer = 0;
            //_smongImageのアニメーションを再生
        }
    }

    /// <summary>
    /// フィーバーの演出を表示する
    /// </summary>
    public void IndicateFevar()
    {
        if (_fevarGaugeSlider.value == _fevarSliderValueMax)
        {
            if (_imgTimer > 0) { StartCoroutine(ImageTime()); }

            _imageInterval = _fevarTime;
            _imgTimer = 0;

            if (_smongImage.enabled)
            {
                //消すアニメーションを再生
            }
            //_fevarImageのアニメーションを再生
        }
    }

    public void Fan() 
    {
        if (_smongImage.enabled)
        {
            FanGaugeInterpolation(0);

            //消すアニメーションを再生
        }
    }

    private IEnumerator GameTime() 
    {
        while(_changeState.Value != GameState.Finish) 
        {
            yield return new WaitForSeconds(1);

            _timer--;
            _timeText.text = _timer.ToString("00");
        }
    }

    private IEnumerator ImageTime()
    {
        while (_changeState.Value != GameState.Finish && _imageInterval > _imgTimer)
        {
            yield return new WaitForEndOfFrame();

            _imgTimer += Time.deltaTime;
        }

        if (_imageInterval < _imgTimer) 
        {
            _imgTimer = 0;

            if (_smongImage.enabled)
            {
                //煙草を消すアニメーションを再生
            }
            else 
            {
                //フィーバーを終えるアニメーションを再生
            }
        }
    }
}
