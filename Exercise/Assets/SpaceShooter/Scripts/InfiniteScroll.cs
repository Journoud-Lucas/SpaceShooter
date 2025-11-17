using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 2f;

    private Vector3 startPosition;
    private float height;

    void Start()
    {
        startPosition = transform.position;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            height = sr.bounds.size.y;
        }
    }

    void Update()
    {
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        if (transform.position.y <= startPosition.y - height)
        {
            transform.position = startPosition;
        }
    }
}
