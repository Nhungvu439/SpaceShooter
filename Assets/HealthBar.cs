using UnityEngine;
using System.Reflection;

public class HealthBar : MonoBehaviour
{
    public RectTransform mask;
    public Health health;

    private float originalWidth;

    void Start()
    {
        originalWidth = mask.sizeDelta.x;

        UpdateHealthValue();

        health.OnHealthChanged += UpdateHealthValue;
    }

    private void UpdateHealthValue()
    {
        FieldInfo field = typeof(Health).GetField("healthPoint",
            BindingFlags.NonPublic | BindingFlags.Instance);

        int currentHealth = (int)field.GetValue(health);

        float scale = (float)currentHealth / health.defaultHealthPoint;

        mask.sizeDelta = new Vector2(scale * originalWidth, mask.sizeDelta.y);
    }
}