using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulScript : MonoBehaviour
{
    [SerializeField] int points;
    [SerializeField] AudioClip clip;
    BoxCollider2D box;
    Animator anim;
    List<Transform> waypoints;
    WaveConfig wave;
    int currentWaypoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        waypoints = wave.GetWaypoints();
        transform.position = waypoints[currentWaypoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.wave = waveConfig;
    }

    private void Flip()
    {
        if (transform.position != waypoints[waypoints.Count - 1].transform.position)
        {
            if (waypoints[currentWaypoint].transform.position.x < waypoints[currentWaypoint + 1].transform.position.x && transform.position != waypoints[waypoints.Count - 1].transform.position)
            {
                transform.localScale = new Vector2(1f, 1f);
            }
            else if (waypoints[currentWaypoint].transform.position.x == waypoints[currentWaypoint + 1].transform.position.x && transform.position != waypoints[waypoints.Count - 1].transform.position)
            {
                transform.localScale = transform.localScale;
            }
            else
            {
                transform.localScale = new Vector2(-1f, 1f);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        if (currentWaypoint <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[currentWaypoint].transform.position;
            var movingThisFrame = Time.deltaTime * wave.GetMoveSpeed();
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movingThisFrame);
            if (transform.position == targetPosition)
            {
                Flip();
                currentWaypoint++;
            }
        }
    }

    public void KillCharacket()
    {
        anim.SetTrigger("Dead");
        box.enabled = false;
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }
    public int GetPoints() { return points; }

    public void Dead()
    {
        Destroy(gameObject);
    }
}
