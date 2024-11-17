using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lis1t : MonoBehaviour
{
    public List<int> AmNiam = new List<int>(3);
    public List<string> Kus = new List<string>(4);
    public List<float> Esh1 = new List<float>(5);
    void Start()
    {
        AmNiam[0] = 4;
        AmNiam[1] = 14;
        AmNiam[2] = 1;

        Kus[0] = "Da";
        Kus[1] = "Net";
        Kus[2] = "Vozmozno";
        Kus[3] = "Skoree vsego";

        Esh1[0] = 1.5f;
        Esh1[1] = 3.45f;
        Esh1[2] = 7.74f;
        Esh1[3] = 9.999f;
        Esh1[4] = 14.79f;
    }


}
