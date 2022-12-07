using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Button sendBallBtn;

    private void Awake()
    {
        GameObject prefab = Resources.Load<GameObject>("game");
        Instantiate(prefab, GameObject.Find("main").transform);

        sendBallBtn = GameObject.Find("sendBallBtn").GetComponent<Button>();
    }

    private void Start()
    {
        sendBallBtn.onClick.AddListener(GameManager.SendBallAction);
    }
}