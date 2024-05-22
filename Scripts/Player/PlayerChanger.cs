using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerChanger : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sprite;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CharacterChange();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CharacterChange()
    {
        animator.runtimeAnimatorController = CharacterManager.instance.Characters[CharacterManager.instance.selectIndex].animator;
        sprite.sprite = CharacterManager.instance.Characters[CharacterManager.instance.selectIndex].sprite;
    }
}
