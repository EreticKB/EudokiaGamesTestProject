using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Game _game;
    [SerializeField] float _xMaxLimit;
    [SerializeField] float _xMinLimit;
    [SerializeField] float _zMaxLimit;
    [SerializeField] float _zMinLimit;
    [SerializeField] float _speed;
    Vector3 _mousePreviousPosition;
    bool firstTouch;


    void Update()
    {
        if (_game.Status != Game.GameState.Playing) return;
        if (Input.GetMouseButton(0))
        {

            Vector3 delta = Input.mousePosition - _mousePreviousPosition;
            Vector3 newPosition = transform.position;
            newPosition.x = Mathf.Clamp(newPosition.x + delta.y * _speed, _xMinLimit, _xMaxLimit);
            newPosition.z = Mathf.Clamp(newPosition.z - delta.x * _speed, _zMinLimit, _zMaxLimit);
            if (firstTouch) firstTouch = false;
            else transform.position = newPosition;
        }
        else firstTouch = true;
        _mousePreviousPosition = Input.mousePosition;
    }
}
