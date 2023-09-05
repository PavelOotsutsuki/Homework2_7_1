using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Bar[] _bars;

    private void Start()
    {
        _player.Init();
        InitBars();
    }

    private void InitBars()
    {
        _bars = GetComponentsInChildren<Bar>();

        foreach (Bar bar in _bars)
        {
            bar.Init();
        }
    }
}
