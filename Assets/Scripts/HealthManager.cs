using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health = 3;
    [SerializeField]private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    private void Start()
    {
        health = 3;
    }

    public void SetFullHeart(Sprite fullHeart)
    {
        this.fullHeart = fullHeart;
    }
    public Sprite GetFullHeart()
    { 
        return this.fullHeart;
    }

    public void SetEmptyHeart(Sprite emptyHeart)
    {
        this.emptyHeart = emptyHeart;
    }
    public Sprite GetEmptyHeart()
    {
        return this.emptyHeart;
    }

    public void SetImages(Image[] hearts)
    {
        foreach (Image img in hearts)
        {
            this.hearts = hearts;
        }
            
    }
    public Image[] GetImages()
    {
        return hearts;
    }

}
