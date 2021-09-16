using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clicker : MonoBehaviour
{
   [HideInInspector] public string currentItem;
    private int _score = 100;
    private bool _canClick = true;
    private Player _player;
    private void Awake()
    {
        _player = gameObject.GetComponent<Player>();
    }
    void Update()
    {
      if (_canClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 100f);
                if (hit.collider != null)
                {
                    CheckItemTag(hit);
                    hit.collider.gameObject.SetActive(false);

                }
            }
        }
    }
    private void CheckItemTag(RaycastHit2D hit)
    {
        if(hit.collider.gameObject.tag == currentItem)
        {
            _player.RecountScore(_score);
        }
        else if(hit.collider.gameObject.tag != currentItem)
        {
            _player.RecountScore(-_score);
        }
    }
    private void StopClick()
    {
        _canClick = false;
    }
    private void OnEnable()
    {
        _player.EndGameEvent += StopClick;
    }
    private void OnDisable()
    {
        _player.EndGameEvent -= StopClick;
    }

}
