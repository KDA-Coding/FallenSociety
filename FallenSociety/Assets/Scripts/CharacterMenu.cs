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
        GameManager.instance.player.SwapSprite(currentCharacterSelection);
    }

    // Weapon Upgrade
    public void OnUpgradeClick() 
    {
        if (GameManager.instance.TryUpgradeWeapon())
        {
            UpdateMenu();
        }
    }

    //Update Character Info
    public void UpdateMenu() 
    {
        //Current Level Reference for Exp Bar
        int currentLevel = GameManager.instance.GetCurrentLevel();

        //Weapon
        weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.weaponLevel];
        if (GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponPrices.Count)
            upgradeCostText.text = "Max";
        else
            upgradeCostText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString();

        //Meta
        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        coinsText.text = GameManager.instance.coins.ToString();
        levelText.text = currentLevel.ToString();

        // Exp Bar
        if(currentLevel == GameManager.instance.xpTable.Count) 
        {
            expText.text = GameManager.instance.experience.ToString() + " Total Exp"; //Display total EXP if max level
            expBar.localScale = Vector3.one;
        }
        else 
        {
            int prevLevelExp = GameManager.instance.GetXpToLevel(currentLevel - 1);
            int currentLevelExp = GameManager.instance.GetXpToLevel(currentLevel);

            int difference = currentLevelExp - prevLevelExp;
            int currXpIntoLevel = GameManager.instance.experience - prevLevelExp;

            float expCompletionRatio = (float)currXpIntoLevel / (float)difference;
            expBar.localScale = new Vector3(expCompletionRatio, 1, 1);

            expText.text = currXpIntoLevel.ToString() + " / " + difference;
        }
    }
}

