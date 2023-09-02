using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsAnim : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(AnimationButton());
    }


    private IEnumerator AnimationButton()
    {
        yield return new WaitForSeconds(2f);
        _animator.Play("WidgetAnim");
    }
}
