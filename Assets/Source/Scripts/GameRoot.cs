using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Restart restartButton;

    private Bar[] _bars;

    private void Start()
    {
        _player.Init();
        InitBars();

        _player.Dying += OnPlayerDying;
    }

    private void InitBars()
    {
        _bars = GetComponentsInChildren<Bar>();

        foreach (Bar bar in _bars)
        {
            bar.Init();
        }
    }

    private void OnPlayerDying()
    {
        ShowRestartButton();

        _player.Dying -= OnPlayerDying;
    }

    private void ShowRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }

}
