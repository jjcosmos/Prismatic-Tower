using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersistantCanvas : MonoBehaviour
{
    public static PersistantCanvas staticCanvas;
    public LoadZone globalLoadZone;
    public FadeIn blackout;
    public Transform headingParent;
    public TMP_Text headingText;
    public TMP_Text subHeadingText;
    private void Awake()
    {
        if (staticCanvas == null)
        {
            staticCanvas = this;
            DontDestroyOnLoad(this.gameObject);
            headingParent.localScale = Vector3.zero;
        }
        else
            Destroy(this.gameObject);
    }

    public IEnumerator DisplayBossText(string heading, string subheading)
    {
        subHeadingText.text = "";
        headingText.text = "";
        //float scaleMult = 1;
        headingParent.localScale = Vector3.one;
        headingText.text = heading;
        yield return new WaitForSeconds(1f);
        subHeadingText.text = subheading;
        /*yield return new WaitForSeconds(1f);
        while(scaleMult > 0)
        {
            headingParent.localScale = Vector3.one * scaleMult;
            scaleMult -= Time.deltaTime * 2;
            yield return null;
        }*/
    }

    public void RemoveBossText()
    {
        subHeadingText.text = "";
        headingText.text = "";
    }
}
