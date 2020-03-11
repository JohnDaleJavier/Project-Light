using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPulse : MonoBehaviour
{
    public GameObject lightningPulse;
    public float pulseDuration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(lightning());
        }
    }


    IEnumerator lightning()
    {
        lightningPulse.SetActive(true);

        yield return new WaitForSeconds(pulseDuration);

        lightningPulse.SetActive(false);
    }
}
