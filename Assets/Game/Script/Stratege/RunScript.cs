using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunScript : MoveBase
{
    private void Update()
    {
        Debug.Log("走っている");
    }

    public override void Move() 
    {
        Debug.Log("走っている");
    }
}
