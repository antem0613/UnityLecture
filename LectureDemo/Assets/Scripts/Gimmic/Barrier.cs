using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] bool initialState = true;

    void Start()
    {
        gameObject.SetActive(initialState);
    }

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
