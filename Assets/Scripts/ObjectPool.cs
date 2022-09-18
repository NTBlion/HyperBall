using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;
    [SerializeField] private float _disableOffsetZ;

    private Camera _camera;
    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawnedGameoject = Instantiate(prefab, _container);
            spawnedGameoject.SetActive(false);

            _pool.Add(spawnedGameoject);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectAboardScreeen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0.5f, 0));

        foreach (var item in _pool)
        {
            if(item.activeSelf == true)
            {
                if(item.transform.position.z < disablePoint.z + _disableOffsetZ)
                {
                    item.SetActive(false);
                }
            }
        }
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
