using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private float nextClick;
    private const float clickRate = 0.5f;

    public int Balance { get; set; } = 1000;
    private int BetCount { get; set; }

    private GameObject BallPrefab { get; set; }
    private GameObject HitPrefab { get; set; }
    private Transform EnvironmentRef { get; set; }

    public static UnityAction SendBallAction { get; set; }
    public static UnityAction ResetPriceAction { get; set; }
    public static UnityAction<int> AddBetAction { get; set; }
    public static UnityAction<float> ChangeRiskAction { get; set; }
    public static UnityAction<int> OnBetChanged { get; set; }
    public static UnityAction<int> OnBalanceChanged { get; set; }

    private void Awake()
    {
        BallPrefab = Resources.Load<GameObject>("ball");
        HitPrefab = Resources.Load<GameObject>("hit");

        EnvironmentRef = GameObject.Find("Environment").transform;
        Instantiate(Resources.Load<GameObject>("game root"), EnvironmentRef);

        SendBallAction += () =>
        {
            if (Time.time > nextClick && Balance >= BetCount)
            {
                Balance -= BetCount;
                OnBalanceChanged?.Invoke(Balance);

                Instantiate(BallPrefab, new Vector2(Random.Range(-0.405f, 0.405f), 4), Quaternion.identity, EnvironmentRef);
                nextClick = Time.time + clickRate;
            }
        };

        AddBetAction += (value) =>
        {
            BetCount += value;
            OnBetChanged?.Invoke(BetCount);
        };

        ResetPriceAction += () =>
        {
            BetCount = 0;
            AddBetAction?.Invoke(0);
        };

        Ball.OnCollided += (_gameObject, ball) =>
        {
            if(_gameObject.CompareTag("Player"))
            {
                return;
            }

            if (_gameObject.CompareTag("point"))
            {
                GameObject hit = Instantiate(HitPrefab, _gameObject.transform.position, Quaternion.identity, EnvironmentRef);
                Destroy(hit, 0.25f);
            }
            else
            {
                Destroy(ball);
            }
        };
    }

    private IEnumerator Start()
    {
        yield return null;
        OnBalanceChanged?.Invoke(Balance);
    }
}