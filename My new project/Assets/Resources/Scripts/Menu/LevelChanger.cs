using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private int _levelToLoad;
    [SerializeField] private Vector3 _position;
    [SerializeField] private VectorValue _playerStorage;

    public void LoadScene()
    {
        _playerStorage.initialValue = _position;
        SceneManager.LoadScene(_levelToLoad);
        Time.timeScale = 1;
    }
}
