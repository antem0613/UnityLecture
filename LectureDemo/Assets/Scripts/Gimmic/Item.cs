using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 90f, bounceHeight = 0.2f, bounceSpeed = 2f;
    Vector3 initialPos;
    float delta;

    void Start()
    {
        initialPos = gameObject.transform.localPosition;
        bounceHeight /= 2f;
        delta = -Mathf.PI;
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime * bounceSpeed;

        gameObject.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
        gameObject.transform.localPosition = initialPos + Vector3.up * (Mathf.Cos(delta) + 1f) * bounceHeight;
    }

    void OnPickup(GameObject player)
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPickup(other.gameObject);
            Destroy(gameObject);
        }
    }
}
