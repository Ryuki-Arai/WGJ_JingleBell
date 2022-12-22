using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    [SerializeField , Header("�X�R�A��\������e�L�X�g")]
    Text _scoreText;

    [SerializeField , Header("�^�o�R�̃C���[�W�摜")]
    Image _smongImage;

    [SerializeField�@, Header("�t�B�[�o�[�̃C���[�W�摜")]
    Image _fevarImage;

    [SerializeField , Header("��Q�[�W�̃X���C�_�[")]
    Slider _gaugeSlider;

    [SerializeField, Header("�X�R�A�̕ω��ɂ����鎞��")]
    float _changeValueInterval;

    [SerializeField, Header("��Q�[�W�̕ω��ɂ����鎞��")]
    float _changeGaugeInterval;

    //�摜��\�����鎞��
    float _imageInterval;

    //�摜�\���̌v���p
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
                    //�����A�j���[�V�������Đ�
                }
                else 
                { 
                    //�t�B�[�o�[���~�߂�A�j���[�V�������Đ�
                }

                _imageInterval = 0;
                _timer = 0;
            }
        }
    }

    /// <summary>
    /// �X�R�A��Dotween�œ��I�ɕ\������
    /// </summary>
    public void ScoreInterpolation(float scoreValue) 
    {
        float sliderValue = float.Parse(_scoreText.text);

        DOTween.To(() => sliderValue, // �A���I�ɕω�������Ώۂ̒l
            x => sliderValue = x, // �ω��������l x ���ǂ��������邩������
            scoreValue, // x ���ǂ̒l�܂ŕω������邩�w������
            _changeValueInterval)
            .OnUpdate(() => _scoreText.text = sliderValue.ToString("000"));
    }

    /// <summary>
    /// ��Q�[�W��Dotween�œ��I�ɕ\������
    /// </summary>
    public void GaugeInterpolation(float gaugeValue) 
    {
        DOTween.To(() => _gaugeSlider.value, // �A���I�ɕω�������Ώۂ̒l
            x => _gaugeSlider.value = x, // �ω��������l x ���ǂ��������邩������
            gaugeValue, // x ���ǂ̒l�܂ŕω������邩�w������
            _changeGaugeInterval);
    }

    /// <summary>
    /// 
    /// </summary>
    public void IndicateSmoke(float interval) 
    {
        _imageInterval = interval;
        _timer = 0;
        //_smongImage�̃A�j���[�V�������Đ�
    }

    /// <summary>
    /// 
    /// </summary>
    public void IndicateFevar(float interval) 
    {
        if (_smongImage.enabled)
        {
            //�����A�j���[�V�������Đ�
        }
        _imageInterval = interval;
        _timer = 0;
        //_fevarImage�̃A�j���[�V�������Đ�
    }
}
