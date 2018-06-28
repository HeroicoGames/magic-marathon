using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultyManager : MonoBehaviour {

    public GameObject flags;

	void Start ()
    {
        if (PlayerPrefs.GetInt("dificulty") == 1)
        {
            flags.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("dificulty") == 2)
        {
            flags.SetActive(false);
        }
    }
}
