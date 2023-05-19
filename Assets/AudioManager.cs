using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;

    // Start is called before the first frame update
    void Start()
    {
        var dbBgm = PlayerPrefs.GetFloat("BGM_ATTENUATION",0);
        var volBgm = DbToVol(dbBgm);
        mixer.SetFloat("BGM_ATTENUATION",dbBgm);
        bgmSlider.SetValueWithoutNotify(volBgm);

        var dbSfx = PlayerPrefs.GetFloat("SFX_ATTENUATION",0);
        var volSfx = DbToVol(dbSfx);
        mixer.SetFloat("SFX_ATTENUATION",dbSfx);
        sfxSlider.SetValueWithoutNotify(volSfx);
    }

    private void OnEnable() {
        bgmSlider.onValueChanged.AddListener(SetBgmVol);
        sfxSlider.onValueChanged.AddListener(SetSfxVol);
    }

    private void OnDisable() {
        bgmSlider.onValueChanged.RemoveListener(SetBgmVol);
        sfxSlider.onValueChanged.RemoveListener(SetSfxVol);
        PlayerPrefs.Save();
    }

    private void SetBgmVol(float vol)
    {
        var db = VolToDB(vol);
        mixer.SetFloat("BGM_ATTENUATION",db);
        PlayerPrefs.SetFloat("BGM_ATTENUATION",db);
    }

    private void SetSfxVol(float vol)
    {
        var db = VolToDB(vol);
        mixer.SetFloat("SFX_ATTENUATION",db);
        PlayerPrefs.SetFloat("SFX_ATTENUATION",db);
    }

    private float DbToVol(float db)
    {
        return Mathf.Pow(10, db/20);
    }

    private float VolToDB(float vol)
    {
        if(vol==0)
            return -80;

        return 20 * Mathf.Log10(vol);
    }
}
