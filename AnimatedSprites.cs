using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSprites : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int index;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        // will be called in a next frame;
        Invoke(nameof(Animate), 0f); // call after certain time becus initially the game speed would be zero and direct calling the method wont work
    }

    private void OnDisable()
    {
        // when the game is disabled/over
        CancelInvoke();
    }
    private void Animate()
    {

        index++;

        if(index >= sprites.Length) // the index woulde exceed the total no of sprites present
        {
            index = 0;
        }

        if(index >= 0 && sprites.Length > index) // wont exceed the bundry and we can render a sprite easily
        {
            spriteRenderer.sprite = sprites[index];
        }

        Invoke(nameof(Animate), 1f / GameManager.instance.gameSpeed); // we wanna call this everytime and depending on the game speed, if the speed increases the time would get shorter
    }
}
