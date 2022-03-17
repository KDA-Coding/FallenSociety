using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public Player player;
    //public Weapon weapon;
    public FloatingTextManager floatingTextManager;

    // Game/Player Logic and Values
    public int coins;
    public int experience;

    //Floating Text to manage
    public void ShowText(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration) 
    {
        floatingTextManager.Show(message, fontSize, color, position, motion, duration);
    }


    //Save and Load states

    //Save State Outline
    /*
     *  INT preferedSkin
     *  INT coins
     *  INT experience
     *  INT weaponLevel
     */
    public void SaveState() 
    {
        string s = "";

        s += "0" + "|";
        s += coins.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
        Debug.Log("Save State");
    }

    public void LoadState(Scene s, LoadSceneMode mode) 
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        //"0|10|15|2" becomes "0","10","15","2"

        //Change Recorded Data from PlayerPrefs parse
        /*Skin*/
        /*Coins*/ coins = int.Parse(data[1]);
        /*Experience*/ experience = int.Parse(data[2]);
        /*Weapon Level*/

        Debug.Log("Load State");
    }

}
