using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectManager : MonoBehaviour
{
    private Animator skillEffects;

    [SerializeField]
    private GameObject playerObj;
 
    void Awake()
    {
        if (skillEffects == null)
            skillEffects = GetComponent<Animator>();
    }
   
    public void PlaySkillAnimation(string stateName, float addfloat)
    {
        if (skillEffects != null)
        {
            this.gameObject.transform.position = playerObj.transform.position + PlayerManager.PlayerInstance.PlayerLookDir*addfloat;
            skillEffects.Play(stateName);
        }
    }
}
