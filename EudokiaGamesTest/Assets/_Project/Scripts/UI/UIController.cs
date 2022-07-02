using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] Game _game;
    [SerializeField] GameObject _startButton;

    public void GameStart()
    {
        _game.Status = Game.GameState.Playing;
        _startButton.SetActive(false);
    }
}
