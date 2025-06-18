using UnityEngine;
using System.Collections;
using TMPro;

public class BalloonSpawnerAndScore : MonoBehaviour
{
    public float spawnInterval = 3f;
    public float spawnHeight = 5f;
    public int score = 0;
    public TMP_Text scoreText;
    public GameObject balloonPrefab;
    public GameObject groundPlane;

    private Coroutine spawnCoroutine;
    private bool isGameFinished = false;

    void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnBalloons());
    }

    IEnumerator SpawnBalloons()
    {
        while (!isGameFinished)
        {
            SpawnBalloon();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnBalloon()
    {
        if (groundPlane == null) return;

        Renderer rend = groundPlane.GetComponent<Renderer>();
        Vector3 size = rend.bounds.size;
        Vector3 center = rend.bounds.center;

        float minX = center.x - size.x * 0.3f;
        float maxX = center.x + size.x * 0.3f;
        float minZ = center.z - size.z * 0.3f;
        float maxZ = center.z + size.z * 0.3f;

        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);
        float y = groundPlane.transform.position.y + spawnHeight;

        Vector3 spawnPos = new Vector3(x, y, z);
        GameObject balloon = Instantiate(balloonPrefab, spawnPos, Quaternion.identity);

        balloon.AddComponent<BalloonCollision>().manager = this;
    }

    public void AddScore(int amount)
    {
        if (isGameFinished) return;

        score += amount;
        int target = PlayerPrefs.GetInt("puntObj", 10);

        if (score >= target)
        {
            scoreText.text = "FIN";
            isGameFinished = true;
            StopCoroutine(spawnCoroutine);
        }
        else
        {
            scoreText.text = score.ToString();
        }
    }
}
