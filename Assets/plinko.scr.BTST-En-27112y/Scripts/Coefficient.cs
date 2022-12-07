using UnityEngine;

public class Coefficient : MonoBehaviour
{
    private SpringJoint2D SpringJoint { get; set; }

    private void Awake()
    {
        SpringJoint = GetComponent<SpringJoint2D>();
    }

    private void Start()
    {
        SpringJoint.connectedAnchor = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
}
