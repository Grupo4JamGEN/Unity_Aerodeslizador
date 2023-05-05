﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace SlimUI.ModernMenu{
	public class UIMenuManager : MonoBehaviour {
		private Animator CameraObject;

		// campaign button sub menu
        [Header("MENUS")]
        [Tooltip("The Menu for when the MAIN menu buttons")]
        public GameObject mainMenu;
        [Tooltip("THe first list of buttons")]
        public GameObject firstMenu;
        [Tooltip("The Menu for when the PLAY button is clicked")]
        public GameObject playMenu;
        [Tooltip("The Menu for when the EXIT button is clicked")]
        public GameObject exitMenu;
        [Tooltip("Optional 4th Menu")]
        public GameObject creditsMenu;

        public enum Theme {custom1, custom2, custom3};
        [Header("THEME SETTINGS")]
        public Theme theme;
        private int themeIndex=0;
        public ThemedUIData themeController;

        [Header("PANELS")]
        [Tooltip("The UI Panel parenting all sub menus")]
        public GameObject mainCanvas;
        [Tooltip("The UI Panel that holds the CONTROLS window tab")]
        public GameObject PanelControls;
        [Tooltip("The UI Panel that holds the VIDEO window tab")]
        public GameObject PanelGame;        
        

        // highlights in settings screen
        [Header("INSTRUCTIONS SCREEN")]
        [Tooltip("Highlight Image for when GAME Tab is selected in Settings")]
        public GameObject lineGame;
        
        [Tooltip("Highlight Image for when CONTROLS Tab is selected in Settings")]
        public GameObject lineControls;
        
		[Header("SFX")]
        [Tooltip("The GameObject holding the Audio Source component for the HOVER SOUND")]
        public AudioSource hoverSound;
        [Tooltip("The GameObject holding the Audio Source component for the AUDIO SLIDER")]
        public AudioSource sliderSound;
        [Tooltip("The GameObject holding the Audio Source component for the SWOOSH SOUND when switching to the Settings Screen")]
        public AudioSource swooshSound;

		void Start(){
			CameraObject = transform.GetComponent<Animator>();

			
			if(SceneManager.GetActiveScene().name== "StartScene(UI)")
			{
                playMenu.SetActive(false);
                exitMenu.SetActive(false);
                if (creditsMenu) creditsMenu.SetActive(false);
                firstMenu.SetActive(true);
                mainMenu.SetActive(true);
            }
			

			SetThemeColors();
		}

		void SetThemeColors()
		{
			switch (theme)
			{
				case Theme.custom1:
					themeController.currentColor = themeController.custom1.graphic1;
					themeController.textColor = themeController.custom1.text1;
					themeIndex = 0;
					break;
				case Theme.custom2:
					themeController.currentColor = themeController.custom2.graphic2;
					themeController.textColor = themeController.custom2.text2;
					themeIndex = 1;
					break;
				case Theme.custom3:
					themeController.currentColor = themeController.custom3.graphic3;
					themeController.textColor = themeController.custom3.text3;
					themeIndex = 2;
					break;
				default:
					Debug.Log("Invalid theme selected.");
					break;
			}
		}

		public void PlayCampaign(){
			exitMenu.SetActive(false);
			if(creditsMenu) creditsMenu.SetActive(false);
			playMenu.SetActive(true);
		}
		
		public void PlayCampaignMobile(){
			exitMenu.SetActive(false);
			if(creditsMenu) creditsMenu.SetActive(false);
			playMenu.SetActive(true);
			mainMenu.SetActive(false);
		}

		public void ReturnMenu(){
            if (playMenu) playMenu.SetActive(false);
			if(creditsMenu) creditsMenu.SetActive(false);
			exitMenu.SetActive(false);
			mainMenu.SetActive(true);
		}

		public void LoadScene(string scene){
			if(scene != ""){
				//StartCoroutine(LoadAsynchronously(scene));
				SceneManager.LoadScene(scene);
			}
		}

		public void  DisablePlayCampaign(){
			if (playMenu!=null)
			{
                playMenu.SetActive(false);
            }
			
		}

		public void Position2(){
			DisablePlayCampaign();
			CameraObject.SetFloat("Animate",1);
		}

		public void Position1(){
			CameraObject.SetFloat("Animate",0);
		}

		void DisablePanels(){
			PanelControls.SetActive(false);
			PanelGame.SetActive(false);
			
			lineGame.SetActive(false);
			lineControls.SetActive(false);
		
			
		}

		public void GamePanel(){
			DisablePanels();
			PanelGame.SetActive(true);
			lineGame.SetActive(true);
		}

		public void ControlsPanel(){
			DisablePanels();
			PanelControls.SetActive(true);
			lineControls.SetActive(true);
		}

		public void PlayHover(){
			hoverSound.Play();
		}

		public void PlaySFXHover(){
			sliderSound.Play();
		}

		public void PlaySwoosh(){
			swooshSound.Play();
		}

		// Are You Sure - Quit Panel Pop Up
		public void AreYouSure(){
			exitMenu.SetActive(true);
			if(creditsMenu) creditsMenu.SetActive(false);
			DisablePlayCampaign();
		}

		public void AreYouSureMobile(){
			exitMenu.SetActive(true);
			if(creditsMenu) creditsMenu.SetActive(false);
			mainMenu.SetActive(false);
			DisablePlayCampaign();
		}

		public void ExtrasMenu(){
			playMenu.SetActive(false);
			if(creditsMenu) creditsMenu.SetActive(true);
			exitMenu.SetActive(false);
		}

		public void QuitGame(){
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#else
				Application.Quit();
			#endif
		}

		// Load Bar synching animation
	}
}