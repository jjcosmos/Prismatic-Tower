using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class MenuHelper : MonoBehaviour
{
    public GameObject SettingsToggle;
    public TMP_Text entryText;//range -10,10
    public Slider entrySlider;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void LoadNext()
    {
        SceneManager.LoadScene(1);
    }

    public void ToggleSettings()
    {
        SettingsToggle.SetActive(!SettingsToggle.activeSelf);
    }

    public void UpdateSensModText()
    {
        if (entryText.text == "") return;
        float sens = float.Parse(entryText.text);
        SystemSetup.sensMult = sens / 10f;
    }

    public void UpdateSensModText(float sens)
    {
        SystemSetup.sensMult =  1 + sens / 10f;
        entryText.text = sens.ToString();
    }
}
