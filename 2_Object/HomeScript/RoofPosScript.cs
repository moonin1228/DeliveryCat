using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofPosScript : MonoBehaviour
{
//    [SerializeField] RectTransform _trans;

    

    public void ClickPosUpButton()
    {
        var temp = transform.localPosition;
        temp.y += 425f;
        transform.localPosition = temp;
    
    }

    public void ClickPosDownButton()
    {
        var temp = transform.localPosition;
        temp.y -= 395f;
        transform.localPosition = temp;
    }
}
