using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon) { return; } // falls period null wird der nachfolgende codeblock nicht ausgeführt. verhindert den error durch null teilen.

        //Kreis Radius berechnung für tau ( 2*pie ) ergibt eine Sinus funktion.
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2; // constant of 6.283
        float rawSinWave = Mathf.Sin(tau * cycles); // going from -1 to 1

        //plus 1 damit wir von oscillation von null bis 1 haben und nich in den mius bereich gehen. form 0 to 1
        movementFactor = (rawSinWave + 1f) / 2f; 

        //Updating die Sinusposition
        Vector3 offset = movementVector * movementFactor;
        transform.position = offset + startingPosition;
    }
}
