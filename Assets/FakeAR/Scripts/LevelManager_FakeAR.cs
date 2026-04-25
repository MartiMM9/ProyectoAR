using System.Collections;
using UnityEngine;

public class LevelManager_FakeAR : MonoBehaviour
{
    [SerializeField] private GameObject spaceshipPrefab;
    [SerializeField] private float spawnRadius;
    [SerializeField] private float spawnMaxHeight;
    [SerializeField] private float spawnMinHeight;
    [SerializeField] private float spawnSpeed;
    private float timePassed = 0;

    void Start()
    {
        StartCoroutine(SpawnSpaceships());
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        switch (timePassed)
        {
            case 10:
                spawnSpeed = 4.7f;
                break;
            case 30:
                spawnSpeed = 4.5f;
                break;
            case 60:
                spawnSpeed = 4.2f;
                break;
            case 90:
                spawnSpeed = 4f;
                break;
            case 120:
                spawnSpeed = 3.5f;
                break;
            case 150:
                spawnSpeed = 3f;
                break;
            case 180:
                spawnSpeed = 2.5f;
                break;
            case 210:
                spawnSpeed = 2f;
                break;
            case 240:
                spawnSpeed = 1.5f;
                break;
            case 300:
                spawnSpeed = 1f;
                break;
        }
    }

    IEnumerator SpawnSpaceships()
    {
        while(timePassed <= 360)
        {
            float angle = Random.Range(0, 2 * Mathf.PI); //Angulo entre 0 y 360 grados aleatorio (calculo en radianes)
            float x = Camera.main.transform.position.x + spawnRadius * Mathf.Cos(angle); //Se saca la posicion en X con el coseno del angulo
            float z = Camera.main.transform.position.z + spawnRadius * Mathf.Sin(angle); //Se saca la posicion en Z con el seno del angulo
            float y = Random.Range(spawnMaxHeight, spawnMinHeight);
            Vector3 spawnPoint = new Vector3(x, y, z);
            Instantiate(spaceshipPrefab, spawnPoint, Quaternion.identity);
            yield return new WaitForSeconds(spawnSpeed);
        }
    }
}
