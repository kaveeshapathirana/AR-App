using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorChange : MonoBehaviour
{

    public Material vaseMaterial;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){ }

    public void ChangeColor()
    {
        string Buttonname = EventSystem.current.currentSelectedGameObject.name;

        if (Buttonname == "RedColorBtn")
        {
            vaseMaterial.color = new Color( 255/255f,0/255f ,0/255f );
        }

        else if (Buttonname == "GreenColorBtn")
        {
            vaseMaterial.color = new Color(0 / 255f, 128 / 255f, 0 / 255f);
        }

        else if (Buttonname == "BlueColorBtn")
        {
            vaseMaterial.color = new Color(0 / 255f, 0 / 255f, 255 / 255f);
        }



    }



}
