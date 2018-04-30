using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * Created by Nicolas RAYMOND
 * Script de gestion des boutons de l'interface
 */
public class ButtonManager : MonoBehaviour {

    public GameObject ecranCreation;
    public GameObject ecranRejoindre;
    public GameObject ecranSalon;

    public InputField inputFieldPseudo;
    public InputField inputFieldNomSalon;
    public Toggle toggleEquipesAlea;

    private string pseudo;
    private string nomSalon;
    private Boolean randomTeam;

    void Start()
    {
        
    }
    // once per frame
    void Update()
    {
        if (ecranCreation.activeInHierarchy)
        {
            inputFieldPseudo = ecranCreation.transform.Find("InputFieldPseudo").GetComponent<InputField>();
        }
        else if (ecranRejoindre.activeInHierarchy)
        {
            inputFieldPseudo = ecranRejoindre.transform.Find("InputFieldPseudo").GetComponent<InputField>();
        }

    }

    /**
     * Méthode pour lancer une scène à partir de son nom
     */
    public void playScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    /**
     * Méthode pour quitter l'application
     */
    public void quitterJeu()
    {
        Application.Quit();
    }

    /**
     * Méthode pour valider la création du salon
     */
    public void Submit()
    {
        pseudo = inputFieldPseudo.text;
        nomSalon = inputFieldNomSalon.text;
        randomTeam = toggleEquipesAlea.isOn;

        if (!String.IsNullOrEmpty(nomSalon)) // attention no empty != no whitespace
        {
            ecranSalon.transform.Find("TextNomSalon").GetComponent<Text>().text = nomSalon;
            ecranSalon.transform.Find("PanelJoueurs/TextPseudo1").GetComponent<Text>().text = pseudo;

            Button buttonAlea = (Button)ecranSalon.transform.Find("ButtonAlea").GetComponent<Button>();
            if (randomTeam)
            {
                buttonAlea.enabled = true;
            }
            else
            {
                buttonAlea.enabled = false;
            }

            ecranCreation.SetActive(false);
            ecranSalon.SetActive(true);
        }   
    }
}
