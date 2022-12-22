using System;
using UniRx;
using UnityEngine;

public class UiPresenter : MonoBehaviour , IDisposable
{
    [SerializeField]
    UiManager _view;

    CompositeDisposable _compositeDisposable = new CompositeDisposable();

    private void Start()
    {
        UiSubscriber();
    }

    void UiSubscriber() 
    {
        GameManager.InstanceGM.TouchCigarettes
            .Subscribe(x =>
            {
                _view.IndicateSmoke();
            }).AddTo(this);

        GameManager.InstanceGM.SumScore
            .Subscribe(x =>
            {
                _view.ScoreInterpolation(x);
            }).AddTo(this);

        GameManager.InstanceGM.FanValue
            .Subscribe(x =>
            {
                _view.FanGaugeInterpolation(x);
            }).AddTo(this);

        GameManager.InstanceGM.FeverValue
            .Subscribe(x =>
            {
                _view.FevarGaugeInterpolation(x);
            }).AddTo(this);

        _view.ChangeState
            .Subscribe(x =>
            {
            GameManager.InstanceGM.ChangeState(x);
            }).AddTo(this);
    }

    public void Dispose()
    {
        _compositeDisposable.Clear();
    }
}
