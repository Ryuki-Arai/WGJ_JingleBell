using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public static SoundManager _instance = new SoundManager();
    // Start is called before the first frame update
    void Start()
    {
        _instance.CallSound(SoundType.BGM, 0);
    }
}
