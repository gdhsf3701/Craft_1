using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private Player _player;
    public Player Player
    {
        get
        {
            if (_player == null)
                _player = FindObjectOfType<Player>();
            if (_player == null)
                Debug.LogWarning("noPlayer");
            return _player;
        }
    }
    public Transform PlayerTrm => Player.transform;
}
