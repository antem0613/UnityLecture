using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] bool initialState = true;

    void Start()
    {
        gameObject.SetActive(initialState);
    }

    public void OnEnable()
    {
        gameObject.SetActive(true);
    }

    public void OnDisable()
    {
        gameObject.SetActive(false);
    }

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
