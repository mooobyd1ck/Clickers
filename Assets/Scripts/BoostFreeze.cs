using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoostFreeze : Boost
{
    public override void Update()
    {
        TurnAround();
    }
    public override void OnMouseDown()
    {
        FreezeBoost();
    }
    public override void TurnAround()
    {
        float rotateSpeed = 25;
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
    private void FreezeBoost()
    {
        if (gameObject.CompareTag("Boost1"))
        {
            SpawnBoosts._reloadIsGameActive = true;
            Spawner._isGameActive = false;
            Destroy(gameObject);
        }
    }
    private void OnButtonClick()
    {

    }
}
