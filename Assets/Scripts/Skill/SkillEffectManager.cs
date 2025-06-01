using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectManager : MonoBehaviour
{
    private Animator skillEffects;

    [SerializeField]
    private GameObject playerObj;

    [SerializeField]
    private GameObject thivseAnimObj;
    List<Animator> thivseAnims = new List<Animator>();
 
    void Awake()
    {
        if (skillEffects == null)
            skillEffects = GetComponent<Animator>();

        foreach(Animator anim in thivseAnimObj.GetComponentsInChildren<Animator>())
        {
            thivseAnims.Add(anim);
        }
    }
   
    /// <summary>
    /// 스킬 이펙트 재생
    /// 캐릭터 기준 원하는 위치에서 재생
    /// </summary>
    /// <param name="stateName"></param>
    /// <param name="addXfloat"></param>
    /// <param name="addYfloat"></param>
    public void PlaySkillAnimation(string stateName, float addXfloat, float addYfloat)
    {
        if (skillEffects != null)
        {
            this.gameObject.transform.position = playerObj.transform.position 
                + PlayerManager.PlayerInstance.PlayerLookDir*addXfloat+Vector3.up*addYfloat;
            skillEffects.Play(stateName);
        }
    }
    /// <summary>
    /// 스킬 이펙트 재생
    /// 캐릭터 기준 원하는 위치에서 재생
    /// </summary>
    /// <param name="stateName"></param>
    /// <param name="addXfloat"></param>
    /// <param name="addYfloat"></param>
    public void PlayThivseSkillAnimation(string stateName,int count,Vector3 mobPos, float addXfloat, float addYfloat)
    {
        if (thivseAnims[count - 1] != null)
        {
            this.gameObject.transform.position = mobPos
                + PlayerManager.PlayerInstance.PlayerLookDir * addXfloat + Vector3.up * addYfloat;
            stateName = stateName + count.ToString();
            thivseAnims[count - 1].Play(stateName);
        }
    }
}
