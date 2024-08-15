using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMineController : MonoBehaviour
{
    public Sprite goldMineActiveSprite;
    public Sprite goldMineInactiveSprite;
    
    public int goldAmount;
    public bool isActive;

    public int goldPerDig;
    
    private SpriteRenderer _goldMineSpriteRenderer;

    private void Start()
    {
        _goldMineSpriteRenderer = GetComponent<SpriteRenderer>();

        Sprite goldMineSprite = goldAmount > 0 ? goldMineActiveSprite : goldMineInactiveSprite;
        ChangeSprite(goldMineSprite);
        isActive = true;
    }

    public int DigGold()
    {
        if (!isActive) return 0;
        
        int digAmount = Mathf.Min(goldPerDig, goldAmount);
        goldAmount -= digAmount;

        if (goldAmount == 0)
        {
            isActive = false;
            ChangeSprite(goldMineInactiveSprite);
        }

        return digAmount;
    }

    private void ChangeSprite(Sprite sprite)
    {
        _goldMineSpriteRenderer.sprite = sprite;
    }
}
