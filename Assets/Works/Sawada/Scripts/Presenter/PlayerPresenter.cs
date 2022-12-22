using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


//扇の挙動を購読するUIManagerにアタッチ
public class PlayerPresenter : MonoBehaviour
{
    [SerializeField,Tooltip("Model部分")]
    PlayerController _playerController;
    [SerializeField, Tooltip("View部分")]
    UiManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        Player();
    }

    void Player()
    {
        _playerController.IsPushed
            .Subscribe(x =>
            {
                if(x && GameManager.InstanceGM.FanValue.Value >= _uiManager.FanSliderValueMax)
                {
                    _uiManager.Fan();
                }
            });
    }
}
