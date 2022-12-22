using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggplant : ItemBase
{
    [SerializeField]
    float _score = 0f;
    [SerializeField]
    float _feverScore = 0f;
    public override void ItemAction()
    {
        GameManager.InstanceGM.AddScore(_score);
        GameManager.InstanceGM.AddFevarValue(_feverScore);
        Destroy(gameObject);
        //GameManagerのスコア加算関数を呼び、引数に自身が持つ値セット。
    }
}
