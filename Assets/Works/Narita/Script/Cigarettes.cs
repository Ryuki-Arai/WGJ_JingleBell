using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cigarettes : ItemBase
{
    int _touchCount = 1;
    public override void ItemAction()
    {
        GameManager.InstanceGM.AddCigarettes(_touchCount);
        Destroy(gameObject);
        //GameManagerの関数を呼ぶ。
    }
}
