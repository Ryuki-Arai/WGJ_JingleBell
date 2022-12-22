using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ItemGenerator : MonoBehaviour
{
    [SerializeField,Tooltip("生成の待ち時間"),Header("生成の待ち時間、二回目以降はランダムになります")]
    float _interval = 1f;
    float _timeCount;
    [SerializeField,Tooltip("生成する位置"),Header("生成する位置")]
    Transform _generatePos;
    [SerializeField,Tooltip("生成するもの"),Header("生成するobject")]
    ItemBase[] _allItems;
    [Tooltip("ItemTypeがeggplantの物のみ")]
    ItemBase[] _eggplants;
    [Tooltip("確率の最低値")]
    int _minProbability = 0;
    [Tooltip("確率の最高値")]
    int _maxProbability = 100;
    [SerializeField, Tooltip("秒数の最低値")]
    int _minInterval = 1;
    [SerializeField, Tooltip("秒数の最高値")]
    int _maxInterval = 3;
    private void Start()
    {//フィーバー時に使用する配列。
        _eggplants = _allItems.Where(x => x.ItemType == ItemType.Eggplant).ToArray();
    }
    // Update is called once per frame

    private void Update()//フィーバー時とそうでない時で処理を分けます。
    {

        _timeCount += Time.deltaTime;
        if (GameManager.InstanceGM.State != GameState.Fevar)
        {
            if (_timeCount >= _interval)
            {
                CreateItem();
                _timeCount = 0;
                _interval = Random.Range(_minInterval, _maxInterval);
            }
        }
        else
        {
            if (_timeCount >= _minInterval)
            {
                CreateItemOnFever();
                _timeCount = 0;
            }
            
        }
    }
    /// <summary>
    /// 通常時の生成関数
    /// </summary>
    void CreateItem()
    {
        //0～99
        int _rand = Random.Range(_minProbability, _maxProbability);
        //生成するItemの要素番号
        int _itemNum = Random.Range(0, _allItems.Length);
        if (_rand >= _allItems[_itemNum].Probability)
        {
            Instantiate(_allItems[_itemNum], _generatePos);
            //サウンドを鳴らす
        }
        else
        {
            CreateItem();
        }
    }

    /// <summary>
    /// フィーバータイム時の生成関数
    /// </summary>
    void CreateItemOnFever()
    {
        int _itemNum = Random.Range(_minProbability, _eggplants.Length);
        Instantiate(_eggplants[_itemNum], _generatePos);
    }
}
