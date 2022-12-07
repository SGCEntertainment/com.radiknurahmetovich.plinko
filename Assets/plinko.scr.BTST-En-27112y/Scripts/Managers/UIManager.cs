using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Button sendBallBtn;

    private Button _1xBtn;
    private Button _2xBtn;

    private Text betCountText;

    private Button lowRiskBtn;
    private Button mediumRiskBtn;
    private Button hightRiskBtn;

    private void Awake()
    {
        GameObject prefab = Resources.Load<GameObject>("game");
        Instantiate(prefab, GameObject.Find("main").transform);

        sendBallBtn = GameObject.Find("sendBallBtn").GetComponent<Button>();

        _1xBtn = GameObject.Find("1x").GetComponent<Button>();
        _2xBtn = GameObject.Find("2x").GetComponent<Button>();

        lowRiskBtn = GameObject.Find("1x").GetComponent<Button>();
        mediumRiskBtn = GameObject.Find("2x").GetComponent<Button>();
        hightRiskBtn = GameObject.Find("2x").GetComponent<Button>();

        betCountText = GameObject.Find("2x").GetComponent<Text>();
    }

    private void Start()
    {
        sendBallBtn.onClick.AddListener(GameManager.SendBallAction);

        _1xBtn.onClick.AddListener(() => GameManager.AddBetAction(50));
        _2xBtn.onClick.AddListener(() => GameManager.AddBetAction(100));

        lowRiskBtn.onClick.AddListener(() => GameManager.ChangeRiskAction(2));
        mediumRiskBtn.onClick.AddListener(() => GameManager.ChangeRiskAction(4));
        hightRiskBtn.onClick.AddListener(() => GameManager.ChangeRiskAction(6));

        sendBallBtn.onClick.AddListener(GameManager.SendBallAction);
    }
}