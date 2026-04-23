using System;
using UnityEngine;

public class KeyIndicator : MonoBehaviour
{
    [SerializeField] GameObject keyIcon;

    void Start()
    {
        GameManager.Instance.OnAddKey += StepIndicator;
    }

    void StepIndicator(object obj, EventArgs e)
    {
        Instantiate(keyIcon, transform);
    }
}
