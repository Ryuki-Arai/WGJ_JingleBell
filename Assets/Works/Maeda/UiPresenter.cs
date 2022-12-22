using System;
using UniRx;
using UnityEngine;

public class UiPresenter : MonoBehaviour , IDisposable
{
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
            }).AddTo(_compositeDisposable);

        GameManager.InstanceGM.SumScore
            .Subscribe(x =>
            {
                _view.ScoreInterpolation(x);
            }).AddTo(_compositeDisposable);

        GameManager.InstanceGM.FanValue
            .Subscribe(x =>
            {
                _view.FanGaugeInterpolation(x);
            }).AddTo(_compositeDisposable);

        GameManager.InstanceGM.FeverValue
            .Subscribe(x =>
            {
                _view.FevarGaugeInterpolation(x);
            }).AddTo(_compositeDisposable);

        _view.ChangeState
            .Subscribe(x =>
            {
            GameManager.InstanceGM.ChangeState(x);
            }).AddTo(_compositeDisposable);
    }

    public void Dispose()
    {
        _compositeDisposable.Clear();
    }
}
