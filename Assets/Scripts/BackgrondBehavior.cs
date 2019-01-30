using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgrondBehavior : MonoBehaviour {

    public GameObject gameBackgrond;
    private SpriteRenderer gameBackgroundSpriteRenderer;
    
    void Start () {
        gameBackgroundSpriteRenderer = gameBackgrond.GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut(gameBackgroundSpriteRenderer, 0.005f));
    }

    // 오브젝트의 투명도가 높아지도록 처리하는 함수입니다. 
    IEnumerator FadeOut(SpriteRenderer spriteRenderer, float amount)
    {
        Color color = spriteRenderer.color;
        while (color.a > 0.0f)
        {
            color.a -= amount;
            spriteRenderer.color = color;
            yield return new WaitForSeconds(amount);
        }
    }

}
