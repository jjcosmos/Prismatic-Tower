using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensFXController : MonoBehaviour
{
    [SerializeField] LensFXObject flame;
    [SerializeField] LensFXObject frost;
    [SerializeField] LensFXObject lightning;

    private LensFXObject currentActive;


    private void Awake()
    {
        currentActive = null;
        flame.gameObject.SetActive(false);
        frost.gameObject.SetActive(false);
        lightning.gameObject.SetActive(false);
    }
    public void ActivateLens(ELensType lens)
    {
        LensFXObject newCurrent = null;
        switch (lens)
        {
            case ELensType.None:
                break;
            case ELensType.Flame:
                newCurrent = flame;
                break;
            case ELensType.Frost:
                newCurrent = frost;
                break;
            case ELensType.Lightning:
                newCurrent = lightning;
                break;
            default:
                break;
        }
        if(currentActive != null) { currentActive.gameObject.SetActive(false); }
        if(newCurrent != null) 
        { 
            currentActive = newCurrent;
            currentActive.gameObject.SetActive(true);
        }
    }
}
