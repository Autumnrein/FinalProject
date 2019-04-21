using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystems : MonoBehaviour
{
    private ParticleSystem ps;
    public GameController playerScript;
    public float starScroll = -5f;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject gameController = GameObject.Find("GameController");
        playerScript.score = 0;
        ParticleSystem ps = GetComponent<ParticleSystem>();
       
    }

    // Update is called once per frame
    void Update()
    {
           

        if (playerScript.score >= 100)
        {

            var main = ps.main;
            main.simulationSpeed = starScroll;


        }
    }
}
