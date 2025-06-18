using UnityEngine;

public class BalloonCollision : MonoBehaviour
{
    public BalloonSpawnerAndScore manager;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stick"))
        {
            manager.AddScore(1);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
