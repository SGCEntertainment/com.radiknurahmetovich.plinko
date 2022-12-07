using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private float nextClick;
    private const float clickRate = 0.5f;

    public static int BetCount { get; set; }

    private GameObject BallPrefab { get; set; }
    private GameObject HitPrefab { get; set; }
    private Transform EnvironmentRef { get; set; }

    public static UnityAction SendBallAction { get; set; }

    public static UnityAction<int> AddBet { get; set; }

    private void Awake()
    {
        BallPrefab = Resources.Load<GameObject>("ball");
        HitPrefab = Resources.Load<GameObject>("hit");

        EnvironmentRef = GameObject.Find("Environment").transform;
        Instantiate(Resources.Load<GameObject>("game root"), EnvironmentRef);

        SendBallAction = new UnityAction(() =>
        {
            if (Time.time > nextClick)
            {
                Instantiate(BallPrefab, new Vector2(Random.Range(-0.405f, 0.405f), 4), Quaternion.identity, EnvironmentRef);
                nextClick = Time.time + clickRate;
            }
        });

        AddBet = new UnityAction<int>((value) =>
        {
            BetCount += value;
        });

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
}