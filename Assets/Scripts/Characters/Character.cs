using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour,IDamegeable
{
   public string displayStringName;
   public int curHp;
   public int maxHp;
   public enum Team
   {
      player,
      Enemy,
      
   }

   [SerializeField] protected Team team;
   [Header("audio")] [SerializeField] protected AudioSource _audioSource;
   [SerializeField] protected AudioClip _audioClip;
   public event UnityAction onTakeDame;
   public event UnityAction onHeal;


   public virtual void TakenDame(int Dame)
   {
      curHp -= Dame;
      _audioSource.PlayOneShot(_audioClip);
      onTakeDame?.Invoke();
      if (curHp < 0)
      {
         Die();
      }
   }

   public virtual void Die()
   {
      
   }

   public Team GetTeam()
   {
      return team;
   }

   public virtual void Heal(int HealAmount)
   {
      curHp += HealAmount;
      if (curHp > maxHp) curHp = maxHp;
      onHeal?.Invoke();
   }
}
