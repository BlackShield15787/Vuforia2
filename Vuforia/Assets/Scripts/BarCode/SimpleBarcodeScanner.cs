using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SimpleBarcodeScanner : MonoBehaviour
{
    public TMPro.TextMeshProUGUI barcodeAsText;
    BarcodeBehaviour mBarcodeBehaviour;

    public List<string> History;
    void Start()
    {
        mBarcodeBehaviour = GetComponent<BarcodeBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mBarcodeBehaviour != null && mBarcodeBehaviour.InstanceData != null)
        {
            if(!BarCodeManager.Instance.wasDetected)
            {
               BarCodeManager.Instance.History.Add(mBarcodeBehaviour.InstanceData.Text);
               BarCodeManager.Instance.wasDetected = true;

            }

            barcodeAsText.text = mBarcodeBehaviour.InstanceData.Text;
        }
        else
        {
            barcodeAsText.text = "";
        }
    }
    private void OnDestroy()
    {
        BarCodeManager.Instance.wasDetected= false;
    }
}