using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private float nextClick;
    private const float clickRate = 0.5f;

    private GameObject BallPrefab { get; set; }
    private GameObject HitPrefab { get; set; }
    private Transform EnvironmentRef { get; set; }

    public static UnityAction SendBallAction { get; set; }

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
                Instantiate(BallPrefab, new Vector2(Random.Range(0.03f, 0.055f), 4), Quaternion.identity, EnvironmentRef);
                nextClick = Time.time + clickRate;
            }
        });

        Ball.OnCollided += (_gameObject) =>
        {
            if (_gameObject.CompareTag("point"))
            {
                Instantiate(HitPrefab, _gameObject.transform.position, Quaternion.identity, EnvironmentRef);
            }
            else
            {
                Destroy(_gameObject);
            }
        };
    }
}