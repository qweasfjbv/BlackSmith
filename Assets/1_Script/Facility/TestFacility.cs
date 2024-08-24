using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFacility : FacilityBase
{
    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("TIMING BUTTON PRESSED!");
        }
    }

    public override int ReturnItem(int itemId1, int itemId2)
    {
        throw new System.NotImplementedException();
    }

    public override void SetFacilityUI()
    {
        throw new System.NotImplementedException();
    }

    public override void ShowWorkUI()
    {
        throw new System.NotImplementedException();
    }
}
