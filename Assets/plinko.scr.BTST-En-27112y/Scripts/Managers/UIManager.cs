using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject _last;

    private const string colorString = "#F05A22";

    [SerializeField] GameObject howToPlay;
    [SerializeField] GameObject game;

    [Space(10)]
    [SerializeField] Text scoreText;

    private void Awake()
    {
        LoadingGO.OnLoadingStarted += () =>
        {
            howToPlay.SetActive(false);
            game.SetActive(false);
        };

        LoadingGO.OnLoadingFinished += () =>
        {
            howToPlay.SetActive(true);
            howToPlay.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                OpenWindow(1);
                GameManager.Instance.RestartGame();
            });
        };

        GameManager.OnGameFinsihed += (score) =>
        {
            Instantiate(Resources.Load<Popup>("popup"), GameObject.Find("screen").transform).SetData(scoreText.text, () =>
            {
                GameManager.Instance.RestartGame();
            });
        };

        _last = howToPlay;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && FindObjectOfType<Popup>() == null)
        {
            OpenWindow(0);
            GameManager.Instance.ExitToMenu();
        }

        scoreText.text = $"Score <color={colorString}>{Mathf.FloorToInt(GameManager.Instance.Score)}</color>";
    }

    public void OpenWindow(int i)
    {
        if(_last)
        {
            _last.SetActive(false);
        }

        switch(i)
        {
            case 0: _last = howToPlay; break;
            case 1: _last = game; break;
        }

        _last.SetActive(true);
    }
}