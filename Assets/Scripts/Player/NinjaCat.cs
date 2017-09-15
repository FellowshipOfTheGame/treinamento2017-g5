using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaCat : MonoBehaviour {

    private AudioSource audioS;
        
    void Update() {
        audioS = GetComponent<AudioSource>();

        Scratching();
    }
    void Scratching()
    {
        AllCatsBehaviour allCats = GetComponentInParent<AllCatsBehaviour>();
        allCats.an.SetBool("Parede", allCats.onWall);
        if (allCats.onWall)
        {
            allCats.Rigid.velocity = Vector2.zero;
            audioS.enabled = true;
            audioS.loop = true;
            if (!audioS.isPlaying)
                audioS.Play();
        }
        else
        {
            audioS.enabled = false;
            audioS.loop = false;
        }
    }
    
}
