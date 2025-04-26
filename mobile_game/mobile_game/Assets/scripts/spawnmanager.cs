using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnmanager : MonoBehaviour
{
    public GameObject[] enemies;       // Inspector’dan atanan 12 düşman
    public float fallSpeed = 1f;
    public float respawnDelay = 1f;

    private Vector3[] spawnPositions;
    private HashSet<GameObject> respawning;

    private void Start()
    {
        // 4 sabit spawn noktası
        spawnPositions = new Vector3[]
        {
            new Vector3(-2f, 6f, 0f),
            new Vector3(-0.65f, 6f, 0f),
            new Vector3(0.65f, 6f, 0f),
            new Vector3(2f, 6f, 0f)
        };

        respawning = new HashSet<GameObject>();
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (fallSpeed <= 7) {
        fallSpeed += 0.01f * Time.deltaTime;
        }
        
    }

    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            // Bu turda kaç düşman respawn edilecek? (1–3 arası)
            int toSpawn = Random.Range(1, 4);
            int spawned = 0;

            for (int i = 0; i < enemies.Length && spawned < toSpawn; i++)
            {
                var enemy = enemies[i];
                if (enemy.transform.position.y < -6f && !respawning.Contains(enemy))
                {
                    StartCoroutine(Respawn(enemy));
                    spawned++;
                }

            }

            yield return new WaitForSeconds(respawnDelay);
        }
    }

    private IEnumerator Respawn(GameObject enemy)
    {
        respawning.Add(enemy);
        enemy.SetActive(false);

        yield return new WaitForSeconds(respawnDelay);

        int idx = Random.Range(0, spawnPositions.Length);
        enemy.transform.position = spawnPositions[idx];
        enemy.transform.rotation = Quaternion.Euler(180f, 0f, 0f);

        var rb = enemy.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.gravityScale = fallSpeed;
        }

        enemy.SetActive(true);
        respawning.Remove(enemy);
    }
}