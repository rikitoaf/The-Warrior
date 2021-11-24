using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    public float health = 100f;

    private float x_Death = -90f;
    private float death_Smooth = 0.9f;
    private float rotate_Time = 0.23f;
    private bool PlayerDied = false;

    public bool is_player;

    [SerializeField]
    private Image health_UI;


    [HideInInspector]
    public bool ShieldActivated;

    private CharecterSoundFX soundFx;

    void Awake()
    {
        soundFx = GetComponentInChildren<CharecterSoundFX>();    
    }


    void Update()
    {
            if (PlayerDied)
        {
            RotateAfterDeath();
        }
    }

    public void ApplyDamage (float damage)
    {

        if (ShieldActivated)
        {
            return;
        }

        health -= damage;

        if(health_UI != null)
        {
            health_UI.fillAmount = health/100f;
        }

        if (health <= 0)
        {
            soundFx.Die();
            GetComponent<Animator>().enabled = false;
            StartCoroutine(AllowRotate());
            if (is_player)
            {
                GetComponent<PlayerMove>().enabled = false;
                GetComponent<PlayerAttackInput>().enabled = false;

                Camera.main.transform.SetParent(null);
                GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG).GetComponent<EnemyController>().enabled = false;

            }
            else
            {
                GetComponent<EnemyController>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;
            }
        }
    }

    void RotateAfterDeath()
    {
        transform.eulerAngles = new Vector3(Mathf.Lerp(transform.eulerAngles.x, x_Death, Time.deltaTime * death_Smooth),
            transform.eulerAngles.y, transform.eulerAngles.z);
    }

    IEnumerator AllowRotate()
    {
        PlayerDied = true;
        yield return new WaitForSeconds(rotate_Time);
        PlayerDied = false;

    }
}
