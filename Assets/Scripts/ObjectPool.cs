using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    private List<GameObject> _pool = new List<GameObject>();
    protected void Initialize(GameObject prefub)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefub, _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }
    protected void Initialize(GameObject[] prefubs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, prefubs.Length);
            GameObject spawned = Instantiate(prefubs[randomIndex], _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }
    protected bool TryGetObject(out GameObject result)
    {
        int randomObject = Random.Range(0, _pool.Count);
        while (_pool[randomObject].activeSelf != false)
        {
            randomObject = Random.Range(0, _pool.Count);
        }
        result = _pool[randomObject];
        return result != null;
    }

}