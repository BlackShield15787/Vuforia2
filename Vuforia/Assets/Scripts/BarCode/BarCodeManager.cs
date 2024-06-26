using Palmmedia.ReportGenerator.Core.Reporting.History;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BarCodeManager : MonoBehaviour
{
    public static BarCodeManager Instance;
    public List<string> History;
    public bool wasDetected = false;
    public int LastWebSiteLinkIndex = 0;

  

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }

    public void AccesToQRWebSite()
    {
        if (History.Count>0 && LastWebSiteLinkIndex>=0 && LastWebSiteLinkIndex<History.Count)
        {
            Application.OpenURL(History[LastWebSiteLinkIndex]);
        }
        else
        {
            Debug.LogError("indice fuera de rango o la lista de history esta vacia");
        }
    }
    public void AccesToQRWebSite(string _url)
    {
        Application.OpenURL(_url);
    }

}
