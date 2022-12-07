using UnityEngine;

public class Coefficient : MonoBehaviour
{
    private SpringJoint2D SpringJoint { get; set; }

    private void Awake()
    {
        SpringJoint = GetComponent<SpringJoint2D>();

        GameManager.ChangeRiskAction += (value) =>
        {
            Debug.Log(value * Random.Range(1.0f, 20.0f));
        };
    }

    private void Start()
    {
        SpringJoint.connectedAnchor = transform.position;
    }
}
