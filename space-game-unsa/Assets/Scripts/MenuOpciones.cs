using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    [Header("MenuOpciones")]
    public Slider Volumemaster;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;

    [Header("MenuInicio")]
    public GameObject menuPrincipal;
    public GameObject menuOpciones;

    public void OpenPanel(GameObject panel)
    {
        menuPrincipal.SetActive(false);
        menuOpciones.SetActive(false);

        panel.SetActive(true);
        PlaySoundButton();
    }

    public void Awake()
    {
        Volumemaster.onValueChanged.AddListener(ChangeVolumeMaster);
    }
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void Salir()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
    public void ChangeVolumeMaster(float v)
    {
        mixer.SetFloat("VolMaster", v); 
    }
    public void PlaySoundButton()
    {
        fxSource.PlayOneShot(clickSound);
    }
}
