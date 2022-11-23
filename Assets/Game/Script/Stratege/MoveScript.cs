using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    MoveBase move;
    void Start()
    {
        move = new RunScript();
    }

    void Update()
    {
        move.Move();
    }
}
