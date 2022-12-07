using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Start()
    {
        GameObject prefab = Resources.Load<GameObject>("game");
        Instantiate(prefab, GameObject.Find("main").transform);
    }
}