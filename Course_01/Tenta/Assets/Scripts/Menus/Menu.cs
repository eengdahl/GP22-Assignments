using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject credits;
    public GameObject instructions;
    //public TMP_Text subtitle;
   // int subtitleRandom;
    


    public void Exit()
    {
        //TODO: Make the game exit, editor and application
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        //TODO: make funktion load the game scene
        
    }

    public void LoadMenu()
    {
        //TODO: Make function load the menu scene
    }

    //TODO: make it so you cant show both instructions and credits at the same time
    public void ShowCredits()
    {
        instructions.SetActive(false);
        credits.SetActive(!credits.activeSelf);
    }

    public void ShowInstructions()
    {
        credits.SetActive(false);
        instructions.SetActive(!instructions.activeSelf);
    }


    //public void Start()
    //{
    //    subtitle = GetComponent<TMP_Text>();

    //    subtitleRandom = Random.Range(1, 5);
    //    Debug.Log("Ping");
    //    if (subtitleRandom == 1)
    //    {
    //        subtitle.text = "Tankmainia!";  
    //    }
    //    if (subtitleRandom == 2)
    //    {
    //        subtitle.text = "Tanks Everywere!";
    //    }
    //    if (subtitleRandom == 3)
    //    {
    //        subtitle.text = "Be the Tank you dream to be";
    //    }
    //    if (subtitleRandom == 4)
    //    {
    //        subtitle.text = "Tank på det";
    //    }
    //    if (subtitleRandom == 5)
    //    {
    //        subtitle.text = "Enough is enough! I have had it with these mother-fucking Tanks on this mother-fucking plane!";
    //    }

    //}


}
