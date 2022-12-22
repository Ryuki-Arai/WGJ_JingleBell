using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    [SerializeField, Tooltip("ƒTƒEƒ“ƒh‚Ìî•ñ‚ğ‚ÂScriptableObject")]
    SceneManager _soundScriptableObj = null;

    private void Awake()
    {
        if (GameManager.InstanceScene == null)
        {
            GameManager.InstanceScene = _soundScriptableObj;
        }
    }
}