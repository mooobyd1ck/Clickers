using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostHold : Boosts
{

    public override void Update()
    {
        TurnAround();
    }
    public override void OnMouseDown()
    {
        HoldPosition();
    }
    public override void TurnAround()
    {
        float _rotateSpeed = 25;
        transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime);
    }
    void HoldPosition()
    {
        if (gameObject.CompareTag("Boost3"))
        {
            Destroy(gameObject);
        }
    }
}
