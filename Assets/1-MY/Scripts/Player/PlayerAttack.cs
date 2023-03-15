using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   public bool AttackTrigger;
   public GameObject EnemyObjTemp;
   private Animator _animator;
   private AudioSource swordAudio;

   private void Start()
   {
      _animator = GameObject.Find("炭治郎").GetComponent<Animator>();
      swordAudio = this.GetComponent<AudioSource>();
   }

   private void Update()
   {
      //if (Input.GetMouseButtonDown(0))
      if (Input.GetKeyDown("space"))//攻击键
      {
         swordAudio.Play();
         _animator.SetBool("Attack",true);
         if (AttackTrigger == true && EnemyObjTemp)
         {
            EnemyObjTemp.GetComponent<Enemy>().EnemyInfo.EnemyHP -= 25;
         }
      }
      else
      {
         _animator.SetBool("Attack",false);
      }
   }
}
