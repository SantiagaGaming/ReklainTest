using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] _itemSprites;
    [SerializeField] private Clicker _clicker;
    private float _secondsBetweenChange = 5f;
    private float _elapsedTime = 0;
    private Player _player;
    private bool _canChange = true;
    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        ChangeItem();
        StartCoroutine(FillAmountC());
    }
    private void Update()
    {
        if(_canChange)
        { 
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _secondsBetweenChange)
        {
            ChangeItem();
            _elapsedTime = 0;
        }
        }
    }
    private void ChangeItem()
    {
        int randomImage = Random.Range(0, _itemSprites.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = _itemSprites[randomImage];
        StartCoroutine(FillAmountC());
        _clicker.currentItem = _itemSprites[randomImage].name;
    }
    private void StopChange()
    {
        _canChange = false;
    }

    private IEnumerator FillAmountC()
    {
        {
            float scale = 1f;
            while (scale >= 0)
            {
                yield return new WaitForSeconds(_secondsBetweenChange/10);
                gameObject.transform.localScale = new Vector3(scale, scale, scale);
                scale -= 0.1f;
            }
        }
    }
    private void OnEnable()
    {
        _player.EndGameEvent += StopChange;
        
    }
    private void OnDisable()
    {
        _player.EndGameEvent -= StopChange;
    }
}
