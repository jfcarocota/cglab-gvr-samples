using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VRButton : MonoBehaviour
{
    Button btnVR;
    [SerializeField]
    GameObject myParent;


    void Awake() 
    {
        btnVR = GetComponent<Button>();    
    }

    public void Click()
    {
        myParent.SetActive(false);
    }
}
