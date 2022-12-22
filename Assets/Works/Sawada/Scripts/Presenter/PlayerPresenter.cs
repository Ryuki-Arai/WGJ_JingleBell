using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerPresenter : MonoBehaviour
{
    [SerializeField,Tooltip("Model•”•ª")]
    PlayerController _playerController;
    [SerializeField, Tooltip("View•”•ª")]
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
                if(x && GameManager.InstanceGM.FanValue.Value >= )
                {
                    _uiManager.Fan();
                }
            });
    }
}
