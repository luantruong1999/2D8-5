using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour,IDamegeable
{
   public string displayStringName;
   public int curHp;
   public int maxHp;
   public enum Team
   {
      player,
      Enemy,
      
   }

   [SerializeField] private Team team;
   [Header("audio")] [SerializeField] private AudioSource _audioSource;
   [SerializeField] private AudioClip _audioClip;
   public event UnityAction onTakeDame;
   public event UnityAction onHeal;


   public void TakeDame(int Dame)
   {
      curHp -= Dame;
      _audioSource.PlayOneShot(_audioClip);
      onTakeDame?.Invoke();
      if (curHp < 0)
      {
         Die();
      }
   }

   public void Die()
   {
      
   }

   public Team GetTeam()
   {
      return team;
   }

   public void Heal(int HealAmount)
   {
      curHp += HealAmount;
      if (curHp > maxHp) curHp = maxHp;
      onHeal?.Invoke();
   }
}
