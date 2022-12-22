using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
/// <summary>
/// �A�C�e�����Œ�����@�\
/// </summary>
public abstract class ItemBase : MonoBehaviour
{
    [SerializeField, Tooltip("�m��")]
    float _probability = 0f;
    [SerializeField, Tooltip("�A�C�e���̎��")]
    ItemType _itemType = ItemType.None;
    public float Probability { get => _probability; }
    public ItemType ItemType { get => _itemType; }

    Rigidbody2D _rb = null;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        LateralMovement();
    }
    void LateralMovement()
    {//�E�Ɉړ�����
        _rb.velocity = Vector2.left;
    }
    public abstract void ItemAction();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.InstanceSM.CallSound(SoundType.SE,1);
        Destroy(gameObject);
    }
}
