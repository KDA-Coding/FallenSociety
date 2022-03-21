using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    // Text fields
    public Text levelText, hitpointText, coinsText, upgradeCostText, expText;

    // Logic
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite, weaponSprite;
    public RectTransform expBar;

    // Character Selection
    public void OnArrowClick(bool right)
    {
        if (right)
        {
            currentCharacterSelection++;

            //If too far in Array
            if (currentCharacterSelection == GameManager.instance.playerSprites.Count)
                currentCharacterSelection = 0;

            OnSelectionChanged();
        }
        else 
        {
            currentCharacterSelection--;

            //If too far in Array
            if (currentCharacterSelection < 0 )
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;

            OnSelectionChanged();
        }
    }
    private void OnSelectionChanged() 
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
    }

    // Weapon Upgrade
    public void OnUpgradeClick() 
    {
        // 
    }

    //Update Character Info
    public void UpdateMenu() 
    {
        //Weapon
        weaponSprite.sprite = GameManager.instance.weaponSprites[0];
        upgradeCostText.text = "NOT IMPLEMENTED";

        //Meta
        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        coinsText.text = GameManager.instance.coins.ToString();
        levelText.text = "NOT IMPLEMENTED";

        // Exp Bar
        expText.text = "NOT IMPLEMENTED";
        expBar.localScale = new Vector3(0.5f, 0, 0);

    }
}

