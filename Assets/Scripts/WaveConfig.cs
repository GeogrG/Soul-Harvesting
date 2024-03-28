using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Soul Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject soulPrefab;
    [SerializeField] GameObject wayPrefab;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] float randomness;
    [SerializeField] int numOfSouls;

    [SerializeField] float moveSpeed = 5f;

    public List<Transform> GetWaypoints()
    {
        var waypoints = new List<Transform>();
        foreach(Transform child in wayPrefab.transform)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public GameObject GetSoulPrefab() { return soulPrefab; }

    public GameObject GetWayPrefab() { return wayPrefab; }

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }

    public float GetRandomness() { return randomness; }

    public int GetNumOfSouls() { return numOfSouls; }

    public float GetMoveSpeed() { return moveSpeed; }
}
