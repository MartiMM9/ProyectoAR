using System.Collections;
using TMPro;
using UnityEngine;

public class LevelManager_FakeAR : MonoBehaviour
{
    [SerializeField] private GameObject spaceshipPrefab;
    [SerializeField] private GameObject portalPrefab;
    [SerializeField] private float shipSpawnRadius;
    [SerializeField] private float portalSpawnRadius;
    [SerializeField] private float spawnMaxHeight;
    [SerializeField] private float spawnMinHeight;
    [SerializeField] private float spawnSpeed;
    [SerializeField] private TextMeshProUGUI timer;
    private float timePassed = 0;

    void Start()
    {
        StartCoroutine(SpawnSpaceships());
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        //Debug.Log(timePassed);
        switch (timePassed)
        {
            case 10:
                spawnSpeed = 2.7f;
                break;
            case 30:
                spawnSpeed = 2.5f;
                break;
            case 60:
                spawnSpeed = 2.2f;
                break;
            case 90:
                spawnSpeed = 2f;
                break;
            case 120:
                spawnSpeed = 1.7f;
                break;
            case 150:
                spawnSpeed = 1.5f;
                break;
            case 180:
                spawnSpeed = 1.2f;
                break;
            case 210:
                spawnSpeed = 1f;
                break;
            case 240:
                spawnSpeed = 0.7f;
                break;
            case 300:
                spawnSpeed = 0.5f;
                break;
        }

        int minutes = (int)timePassed / 60;
        int seconds = (int)timePassed % 60;
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator SpawnSpaceships()
    {
        while(true)
        {
            float angle = Random.Range(0, 2 * Mathf.PI); //Angulo entre 0 y 360 grados aleatorio (calculo en radianes)
            float x = Camera.main.transform.position.x + shipSpawnRadius * Mathf.Cos(angle); //Se saca la posicion en X con el coseno del angulo
            float z = Camera.main.transform.position.z + shipSpawnRadius * Mathf.Sin(angle); //Se saca la posicion en Z con el seno del angulo
            float xPortal = Camera.main.transform.position.x + portalSpawnRadius * Mathf.Cos(angle);
            float zPortal = Camera.main.transform.position.z + portalSpawnRadius * Mathf.Sin(angle);
            float y = Random.Range(spawnMaxHeight, spawnMinHeight);
            Vector3 spawnPoint = new Vector3(x, y, z);
            Vector3 portalSpawnPoint = new Vector3(xPortal, y, zPortal);
            Instantiate(spaceshipPrefab, spawnPoint, Quaternion.identity);
            Instantiate(portalPrefab, portalSpawnPoint, Quaternion.identity);
            yield return new WaitForSeconds(spawnSpeed);
        }
    }
}
