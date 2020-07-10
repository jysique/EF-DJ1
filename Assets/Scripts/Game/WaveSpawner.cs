using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState{
        SPAWNING,
        WAITIING,
        COUNTING
    };

    [System.Serializable]
    public class Wave{
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;
    }
    private EnemyController currentEnemy;
    public Wave[] waves;

    private int nextWave =0;
    public float timeBetweenWaves = 5f;
    public float waveCountDown;

    private float searchCountdown = 1f;
    public SpawnState state = SpawnState.COUNTING ;
    private void Start() {
        waveCountDown = timeBetweenWaves;
    }
    private void Update() {
        if(state == SpawnState.WAITIING){
            if(!EnemyIsAlive()){
                //new round
                WaveCompleted();
                return;
            }else{
                return;
            }
        }

        if(waveCountDown <= 0){
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave ( waves[nextWave]));
            }
        }else{
            waveCountDown-=Time.deltaTime;
        }
    }
    void WaveCompleted(){
        print("wave comple");
        state = SpawnState.COUNTING;

        waveCountDown = timeBetweenWaves;
        if(nextWave + 1> waves.Length -1){
            nextWave = 0;
            print("completed all waves");
        }else{
            nextWave++;
        }
    }

    bool EnemyIsAlive(){
        searchCountdown-=Time.deltaTime;
        if(searchCountdown <=0f){
            searchCountdown = 1f;
            if(GameObject.FindGameObjectWithTag("Enemy")== null){
                return false;
            }    
        }
        
        return true;
    }
    IEnumerator SpawnWave(Wave _wave){
        print("Spawning wave: "+ _wave.name);
        state = SpawnState.SPAWNING;
        for (int i = 0; i< _wave.count;i++){
            int random = Random.Range(1,2);
            SpawnEnemy(_wave.enemy[random]);
            yield return new WaitForSeconds(_wave.rate);
        }

        state = SpawnState.WAITIING;
        yield break;
    }

    void SpawnEnemy (Transform _enemy){
        print("Spawn enemy " + _enemy.name);
        currentEnemy = Instantiate (_enemy,transform.position,transform.rotation).GetComponent<EnemyController>();
    }
}
