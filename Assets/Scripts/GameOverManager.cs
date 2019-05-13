using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private TankHealth _tankHealth;

    private void Awake()
    {
        _restartButton.onClick.AddListener(Restart);
        _exitButton.onClick.AddListener(Exit);

        _tankHealth = FindObjectOfType<TankHealth>();
    }

    private void OnEnable()
    {
        _tankHealth.TankDied += Restart;
    }

    private void OnDisable()
    {
        _tankHealth.TankDied -= Restart;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Exit()
    {
        Application.Quit();
    }
}