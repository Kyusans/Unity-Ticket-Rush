using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
  [SerializeField] List<Transform> players;
  [SerializeField] float enemyLocalScale;
  Animator enemyAnim;
  Rigidbody2D enemyRB;
  float moveSpeeed = 6.0f;
  float attackRange = 10.0f;

  void Start()
  {
    enemyRB = GetComponent<Rigidbody2D>();
    enemyAnim = GetComponent<Animator>();
  }

  void Update()
  {
    Transform closestPlayer = GetClosestPlayer();
    if (closestPlayer != null)
    {
      float distanceToPlayer = Vector2.Distance(transform.position, closestPlayer.position);

      if (distanceToPlayer <= attackRange)
      {
        enemyAnim.SetBool("playerFound", true);
        attack(closestPlayer);
      }
      else
      {
        enemyAnim.SetBool("playerFound", false);
      }
    }
  }

  Transform GetClosestPlayer()
  {
    Transform closestPlayer = null;
    float closestDistance = Mathf.Infinity;

    foreach (Transform player in players)
    {
      float distanceToPlayer = Vector2.Distance(transform.position, player.position);
      if (distanceToPlayer < closestDistance)
      {
        closestDistance = distanceToPlayer;
        closestPlayer = player;
      }
    }

    return closestPlayer;
  }

  void attack(Transform targetPlayer)
  {
    if (targetPlayer.position.x < transform.position.x)
    {
      transform.localScale = new Vector3(enemyLocalScale, enemyLocalScale, enemyLocalScale);
    }
    else
    {
      transform.localScale = new Vector3(-enemyLocalScale, enemyLocalScale, enemyLocalScale);
    }

    transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, moveSpeeed * Time.deltaTime);
  }
}
