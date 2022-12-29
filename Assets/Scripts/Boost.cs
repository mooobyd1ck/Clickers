using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boost : Boosts
{   
    public override void Update()
    {
        TurnAround();
    }
    public override void OnMouseDown()
    {
        DestroyAll();
    }
    public override void TurnAround()
    {
        float _rotateSpeed = 25;
        transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime);
    }
    public void DestroyAll()
    {
        if (gameObject.CompareTag("Boost"))
        {
            List<GameObject> _enemies = Singleton.instance.allObjects;

            foreach (GameObject obj in _enemies)
            {
                Spawner._updateScoreValue += _enemies.Count;
                Destroy(obj);
            }
            Destroy(gameObject);
        }
    }
}
    