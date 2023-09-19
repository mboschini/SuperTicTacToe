using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerTT : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _drawScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private Image _winnerPlayerImg;
    [SerializeField] private Image _drawImg;

    public static UIManagerTT Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void ShowWinScreen()
    {
        _winScreen.SetActive(true);
        _gameScreen.SetActive(false);
        _winnerPlayerImg.sprite = GameManagerTT.Instance.GetActivePlayerImage();
    }

    public void ShowDrawScreen()
    {
        _drawScreen.SetActive(true);
        _gameScreen.SetActive(false);
        _drawImg.sprite = GameManagerTT.Instance._nullSprite;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

}
