using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavespawner : MonoBehaviour
{
    //Spawn enemies 
    public Transform enemyPre;
    public Transform spawnPoint;

    public float waveTimer = 10f; //time inbetween each of the waves
    private float countDown = 3f; //how long it takes to spawn a wave
    private int waveNum = 0;

    void Update(){

        if(countDown <= 0f){

            StartCoroutine(Wave()); //This is how to call a method with a IEnumerator
            countDown = waveTimer;
        }

        countDown-= Time.deltaTime;
    }

    IEnumerator Wave(){
         //Will adjust code below later for different enemies and all that 

        waveNum++;

        for(int i = 0; i < waveNum; i++){

            spawn();
            yield return new WaitForSeconds(0.5f); //helps the enemies not spawn on top of each other
        }
        Debug.Log("More humans are on their way!!");
    }

    void spawn(){

        Instantiate(enemyPre, spawnPoint.position, spawnPoint.rotation);
    }

}
