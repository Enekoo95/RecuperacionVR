using UnityEngine;
using System.Collections;
using TMPro;

public class BalloonSpawnerAndScoreHard : MonoBehaviour
{
    public float spawnInterval = 3f;
    public float spawnHeight = 5f;
    public int score = 0;
    public TMP_Text scoreText;
    public GameObject globoNormal;
    public GameObject globoRojo;
    public GameObject suelo;

    private Coroutine spawnCoroutine;
    private bool gameEnded = false;

    void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnBalloons());
    }

    IEnumerator SpawnBalloons()
    {
        while (!gameEnded)
        {
            SpawnBalloon();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnBalloon()
    {
        if (suelo == null)
        {
            Debug.LogError("Asignar el plano del suelo.");
            return;
        }

        Renderer rend = suelo.GetComponent<Renderer>();
        Vector3 groundSize = rend.bounds.size;
        Vector3 groundCenter = rend.bounds.center;

        float minX = groundCenter.x - groundSize.x * 0.3f;
        float maxX = groundCenter.x + groundSize.x * 0.3f;
        float minZ = groundCenter.z - groundSize.z * 0.3f;
        float maxZ = groundCenter.z + groundSize.z * 0.3f;

        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        float y = suelo.transform.position.y + spawnHeight;

        Vector3 spawnPos = new Vector3(randomX, y, randomZ);

        bool isRed = Random.value < 0.25f;
        GameObject balloon = Instantiate(isRed ? globoRojo : globoNormal, spawnPos, Quaternion.identity);
        balloon.tag = isRed ? "RedBalloon" : "NormalBalloon";

        BalloonCollisionHard collision = balloon.AddComponent<BalloonCollisionHard>();
        collision.manager = this;
    }

    public void AddScore(int amount)
    {
        if (gameEnded) return;

        score += amount;
        int target = PlayerPrefs.GetInt("puntObj", 10);

        if (score >= target)
        {
            scoreText.text = "FIN";
            gameEnded = true;
            StopCoroutine(spawnCoroutine);
        }
        else
        {
            scoreText.text = score.ToString();
        }
    }
}
