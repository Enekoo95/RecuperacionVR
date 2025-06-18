using UnityEngine;

public class BalloonCollisionHard : MonoBehaviour
{
    public BalloonSpawnerAndScoreHard manager;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stick"))
        {
            if (gameObject.CompareTag("GloboRojo"))
            {
                manager.AddScore(-2);
            }
            else // NormalBalloon
            {
                manager.AddScore(1);
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            if (gameObject.CompareTag("Globo"))
            {
                manager.AddScore(-1);
            }
            // Si es globo rojo y toca el suelo, no afecta en la puntuacion
            Destroy(gameObject);
        }
    }
}
