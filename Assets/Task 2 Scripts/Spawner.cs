using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Camera _camera;

    [SerializeField] private GameObject spawn_object;
    [SerializeField] private int spawnCount;
    [SerializeField] float offset;
    private void Awake()
    {
        _camera = Camera.main;
        for (int i = 0; i < spawnCount; i++)
        {
            RandomSpawner();
        }
    }
    private void RandomSpawner()
    {
        print(Screen.height);
        float yPos = Random.Range(-_camera.orthographicSize + offset, _camera.orthographicSize - offset);
        float orthographicWidth = _camera.orthographicSize * _camera.aspect;
        float xPos = Random.Range(-orthographicWidth + offset, orthographicWidth - offset);

        // Vector3 position = _camera.ScreenToWorldPoint(new Vector3(screen_x, screen_y, 0f));
        Instantiate(spawn_object, new Vector2(xPos, yPos), Quaternion.identity);
    }
}
