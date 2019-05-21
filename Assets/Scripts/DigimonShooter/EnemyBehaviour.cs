using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DigimonShooter
{
    public class EnemyBehaviour : MonoBehaviour
    {
        private NavMeshAgent _agent;
        public Animator anim;
        private float cooldown = 5;
        private int index = -1;
        public bool isDead;

        [SerializeField] private IntVariable Score;

        private float timer;
        public List<Transform> waypointCircuit;


        public IEnumerator Dead()
        {
            if (isDead)
                yield return null;
            var deadtimer = 5.0f;
            anim.SetTrigger("dead");
            GetComponent<NavMeshAgent>().enabled = false;
            while (deadtimer > 0)
            {
                deadtimer -= Time.deltaTime;
                yield return null;
            }

            yield return null;
        }

        public IEnumerator Patrol()
        {
            anim.SetTrigger("patrol");
            index = Random.Range(0, waypointCircuit.Count);
            _agent.SetDestination(waypointCircuit[index].position);
            while (_agent.remainingDistance > 1)
            {
                if (isDead)
                    yield return StartCoroutine(Dead());
                yield return null;
            }

            yield return StartCoroutine(Idle());
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                if (isDead)
                    return;
                Debug.Log("hit");
                isDead = true;
                Score.Value += 1;
            }
        }

        public IEnumerator Idle()
        {
            anim.SetTrigger("idle");
            while (timer > 0)
            {
                timer -= Time.deltaTime;
                if (isDead)
                    yield return StartCoroutine(Dead());
                yield return null;
            }

            timer = cooldown;

            yield return StartCoroutine(Patrol());
        }

        // Use this for initialization
        private void Start()
        {
            index = Random.Range(0, waypointCircuit.Count);
            timer = cooldown;
            _agent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
            StartCoroutine(Idle());
        }
    }
}