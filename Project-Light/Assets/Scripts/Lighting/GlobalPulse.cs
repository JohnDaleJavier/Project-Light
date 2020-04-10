using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPulse : MonoBehaviour
{
    public float pulseDuration;
    public float pulseChance;
    Animator anim;

    bool wait = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float randomNum = Random.Range(0,100f);
        if (randomNum < pulseChance  && wait == false){
            wait =true;
            StartCoroutine(lightning());
            
        }
    }
    IEnumerator lightning()
    {
        anim.SetBool("Lightning",true);

        yield return new WaitForSeconds(pulseDuration);
        wait = false;
        anim.SetBool("Lightning",false);
    }
}
