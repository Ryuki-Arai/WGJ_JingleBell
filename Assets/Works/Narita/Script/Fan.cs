﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : ItemBase
{
    float _gageScore = 0;
    public override void ItemAction()
    {
        GameManager.InstanceGM.AddFanValue(_gageScore);
        //GameManagerのゲージ加算関数を呼び、引数に自身が持つ値セット。
    }
}
