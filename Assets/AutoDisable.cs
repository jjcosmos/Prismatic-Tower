using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour
{
    // Start is called before the first frame update
    private Coroutine disableCoroutine;
    private void OnEnable()
    {
        disableCoroutine = StartCoroutine(DisableSelf());
    }

    private void OnDisable()
    {
        if(disableCoroutine!=null)
        { StopCoroutine(disableCoroutine); }
    }

    IEnumerator DisableSelf()
    {
        yield return new WaitForSeconds(5f);
        this.gameObject.SetActive(false);
    }
}
