using UnityEngine;
using TMPro;

public class Coefficient : MonoBehaviour
{
    private float InitValue { get; set; }

    private float Value
    {
        get => float.Parse(TextComponent.text);
        set => TextComponent.text = $"{value}";
    }

    private TextMeshPro TextComponent { get; set; }
    private SpringJoint2D SpringJoint { get; set; }

    private void Awake()
    {
        SpringJoint = GetComponent<SpringJoint2D>();
        TextComponent = transform.GetChild(0).GetComponent<TextMeshPro>();

        InitValue = GameManager.coefficients[transform.GetSiblingIndex()];
        Value = InitValue;

        GameManager.ChangeRiskAction += (value) =>
        {
            Value = InitValue < 0 ? InitValue / value : InitValue * value;
        };
    }

    private void Start()
    {
        SpringJoint.connectedAnchor = transform.position;
    }
}
