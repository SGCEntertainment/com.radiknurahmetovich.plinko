using UnityEngine;
using TMPro;

public class Coefficient : MonoBehaviour
{
    private float Value
    {
        get => int.Parse(TextComponent.text);
        set => TextComponent.text = $"{value}";
    }

    private TextMeshPro TextComponent { get; set; }
    private SpringJoint2D SpringJoint { get; set; }

    private void Awake()
    {
        SpringJoint = GetComponent<SpringJoint2D>();
        TextComponent = transform.GetChild(0).GetComponent<TextMeshPro>();

        Value = GameManager.coefficients[transform.GetSiblingIndex()];

        GameManager.ChangeRiskAction += (value) =>
        {
            Value = Value < 0 ? Value / Value : Value * value;
        };
    }

    private void Start()
    {
        SpringJoint.connectedAnchor = transform.position;
    }
}
