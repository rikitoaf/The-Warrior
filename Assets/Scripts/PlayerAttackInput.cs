using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{

    private CharacterAnimations playerAnimation;
    public GameObject attackPoint;

    private PlayerShield shield;
    private CharecterSoundFX soundFx;
    // Start is called before the first frame update
    void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimations>();
        shield = GetComponent<PlayerShield>();
        soundFx = GetComponentInChildren<CharecterSoundFX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            //print("button pressed");
            playerAnimation.Defend(true);

            shield.ActivateSheild(true);
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            playerAnimation.UnFreezeAnimation();
            playerAnimation.Defend(false) ;
            shield.ActivateSheild(false);
        }
        

        if (Input.GetKeyDown(KeyCode.K))
        {
           // print("button pressed");
            if (Random.Range(0, 2) > 0)
            {
                playerAnimation.Attack_1();
                soundFx.Attack_1();
            }
            else
            {
                playerAnimation.Attack_2();
                soundFx.Attack_2();
            }
        }
    }
    void Activate_AttackPoint()
    {
        attackPoint.SetActive(true);
    }
    void Deactivate_AttackPoint()
    {
       
        
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
}
