using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waves;
    int startingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (true);
    }

    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startingWave; waveIndex<waves.Count; waveIndex++)
        {
            var currentWave = waves[waveIndex];
            yield return StartCoroutine(AllEnnemiesInWave(currentWave));
        }
    }

    private IEnumerator AllEnnemiesInWave(WaveConfig wave)
    {
        for (int soul = 0; soul<wave.GetNumOfSouls();soul++ )
        {
            var soulEnemy = Instantiate(wave.GetSoulPrefab(), wave.GetWaypoints()[0].transform.position, Quaternion.identity);
            soulEnemy.GetComponent<SoulScript>().SetWaveConfig(waves[startingWave]);
            yield return new WaitForSeconds(wave.GetTimeBetweenSpawns() + wave.GetRandomness());
        }
    }
}
