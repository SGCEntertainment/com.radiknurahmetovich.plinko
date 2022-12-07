using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Button resetPriceBtn;
    private Button sendBallBtn;

    private Button _1xBtn;
    private Button _2xBtn;

    private Text betCountText;
    private Text balanceText;

    private Button lowRiskBtn;
    private Button mediumRiskBtn;
    private Button hightRiskBtn;

    private void Awake()
    {
        GameObject prefab = Resources.Load<GameObject>("game");
        Instantiate(prefab, GameObject.Find("main").transform);

        sendBallBtn = GameObject.Find("sendBallBtn").GetComponent<Button>();
        resetPriceBtn = GameObject.Find("resetPriceBtn").GetComponent<Button>();

        _1xBtn = GameObject.Find("1x").GetComponent<Button>();
        _2xBtn = GameObject.Find("2x").GetComponent<Button>();

        lowRiskBtn = GameObject.Find("lowRiskBtn").GetComponent<Button>();
        mediumRiskBtn = GameObject.Find("mediumRiskBtn").GetComponent<Button>();
        hightRiskBtn = GameObject.Find("hightRiskBtn").GetComponent<Button>();

        betCountText = GameObject.Find("betCountText").GetComponent<Text>();
        balanceText = GameObject.Find("balanceText").GetComponent<Text>();
    }

    private void Start()
    {
        sendBallBtn.onClick.AddListener(GameManager.SendBallAction);
        resetPriceBtn.onClick.AddListener(GameManager.ResetPriceAction);

        _1xBtn.onClick.AddListener(() => GameManager.AddBetAction(50));
        _2xBtn.onClick.AddListener(() => GameManager.AddBetAction(100));

        lowRiskBtn.onClick.AddListener(() => GameManager.ChangeRiskAction(1));
        mediumRiskBtn.onClick.AddListener(() => GameManager.ChangeRiskAction(0.5f));
        hightRiskBtn.onClick.AddListener(() => GameManager.ChangeRiskAction(1.5f));

        sendBallBtn.onClick.AddListener(GameManager.SendBallAction);

        GameManager.OnBetChanged += (value) =>
        {
            betCountText.text = $"{value}";
        };

        GameManager.OnBalanceChanged += (value) =>
        {
            balanceText.text = $"{value}";
        };
    }
}