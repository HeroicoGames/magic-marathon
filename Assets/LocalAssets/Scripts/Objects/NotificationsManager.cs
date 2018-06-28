using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationsManager : MonoBehaviour {

    public GameObject alerts;
    GameObject panelRed;
    GameObject panelGreen;
    GameObject panelBlue;

    private void Start()
    {
        panelRed = alerts.transform.Find("PanelRed").gameObject;
        panelGreen = alerts.transform.Find("PanelGreen").gameObject;
        panelBlue = alerts.transform.Find("PanelBlue").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Cube") && transform.CompareTag ("FlagRed"))
        {
            panelGreen.SetActive(false);
            panelBlue.SetActive(false);
            panelRed.SetActive(true);
            
        }
        else if (other.transform.CompareTag("Cube") && transform.CompareTag("FlagGreen"))
        {
            panelBlue.SetActive(false);
            panelRed.SetActive(false);
            panelGreen.SetActive(true);

        }
        else if (other.transform.CompareTag("Cube") && transform.CompareTag("FlagBlue"))
        {
            panelRed.SetActive(false);
            panelGreen.SetActive(false);
            panelBlue.SetActive(true);
        }
    }
}