using UnityEngine;

public class Block : MonoBehaviour
{
    public float speed = 5f;
    private bool hasScored = false;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Award score when passing player
        if (!hasScored && transform.position.y < -3f)
        {
            hasScored = true;
            GameManager.Instance.AddScore(1);
        }

        // Destroy block off-screen
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}