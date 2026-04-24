using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject spaceshipPrefab;
    [SerializeField] private float spawnRadius;
    [SerializeField] private float spawnMaxHeight;
    [SerializeField] private float spawnMinHeight;
    [SerializeField] private float spawnSpeed;

    void Start()
    {
        StartCoroutine(SpawnSpaceships());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnSpaceships()
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
