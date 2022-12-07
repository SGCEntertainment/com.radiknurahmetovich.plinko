using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Button sendBallBtn;

    private Button _1xBtn;
    private Button _2xBtn;

    private Text betCountText;

    private void Awake()
    {
        GameObject prefab = Resources.Load<GameObject>("game");
        Instantiate(prefab, GameObject.Find("main").transform);

        sendBallBtn = GameObject.Find("sendBallBtn").GetComponent<Button>();

        _1xBtn = GameObject.Find("1x").GetComponent<Button>();
        _2xBtn = GameObject.Find("2x").GetComponent<Button>();

        betCountText = GameObject.Find("2x").GetComponent<Text>();
    }

    private void Start()
    {
        sendBallBtn.onClick.AddListener(GameManager.SendBallAction);

        _1xBtn.onClick.AddListener(() => GameManager.AddBet(50));
        _2xBtn.onClick.AddListener(() => GameManager.AddBet(100));

        sendBallBtn.onClick.AddListener(GameManager.SendBallAction);
    }
}