using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerController))]
public class PlayerAnimController : MonoBehaviour
{
    [SerializeField]Animator _playerAnim;
    [SerializeField] PlayerController _pc;
    private void Update()
    {
        _playerAnim.SetFloat("Speed",_pc.Ps.y);
    }
}
