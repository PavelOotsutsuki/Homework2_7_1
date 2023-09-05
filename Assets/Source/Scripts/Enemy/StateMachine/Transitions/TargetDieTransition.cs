using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDieTransition : Transition
{
    private void Update()
    {
        if (NeedTransit == true)
        {
            return;
        }

        if (Target == null)
        {
            NeedTransit = true;
        }
    }
}
