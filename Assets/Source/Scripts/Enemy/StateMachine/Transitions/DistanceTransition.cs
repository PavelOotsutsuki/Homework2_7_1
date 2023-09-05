using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangetSpread;

    private void Start()
    {
        _transitionRange += Random.Range(-1f * _rangetSpread, _rangetSpread);
    }

    private void Update()
    {
        if (NeedTransit == true)
        {
            return;
        }

        if (Vector2.Distance(transform.position, Target.transform.position) < _transitionRange)
        {
            NeedTransit = true;
        }
    }
}
