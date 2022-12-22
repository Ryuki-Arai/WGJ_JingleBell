using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
/// <summary>
/// Playerの移動とアイテム取得時の動作を管理するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerController : MonoBehaviour
{
    
    [Tooltip("プレイヤーの縦入力値")]
    float _v = default;
    [SerializeField, Header("プレイヤーの移動速度調整用値"), Range(1, 100)]
    float _speed = 10;
    [SerializeField]Rigidbody2D _rb;
    Vector2 _ps;
    ReactiveProperty<bool> _isPushed = new ReactiveProperty<bool>();

    public IReadOnlyReactiveProperty<bool> IsPushed => _isPushed;
    public Vector2 Ps { get => _ps;}

    void Start()
    {
        
    }
    void Update()
    {
        _v = Input.GetAxisRaw("Vertical");
        _isPushed.Value = Input.GetButtonDown("Jump");
    }
    void FixedUpdate()
    {
        PlayerMove();
    }
    /// <summary>
    /// Playerの移動を行う関数 FixedUpdateで動かすように
    /// </summary>
    void PlayerMove()
    {
        _ps.y = _v * _speed;
        _rb.velocity = Ps.normalized;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ItemBase持ちだけに反応しActionを呼ぶ
        if(collision.TryGetComponent<ItemBase>(out var item))
        {
            item.ItemAction();
        }
    }

    void OnDisable()
    {
        _isPushed.Dispose();
    }
}
