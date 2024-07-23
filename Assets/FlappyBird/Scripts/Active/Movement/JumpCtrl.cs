
using System;
using UnityEngine;
[RequireComponent((typeof(CircleCollider2D)))]
[RequireComponent((typeof(Rigidbody2D)))]
public class JumpCtrl : ComponentBehavior
{
    [SerializeField] protected CircleCollider2D cCollider2D;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected AudioSource jumpSound;
    [SerializeField] protected float jumpForce = 50f;
    [SerializeField] protected float prePosY;
    [SerializeField] protected float curPosY;
    [SerializeField] protected float maxHeight = 18f;
    [SerializeField] protected float minHeight = -19f;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadRigid();
        this.ChangeColliderInfor();
        this.ChangeRidbodyInfor();
        this.LoadSound();
    }

    protected override void Awake()
    {
        this.prePosY = transform.position.y;
    }

    protected virtual void LoadCollider()
    {
        if(cCollider2D != null) return;
        cCollider2D = transform.GetComponent<CircleCollider2D>();
        Debug.Log(transform.name + " LoadCicleCollider successful");
    }

    protected virtual void LoadRigid()
    {
        if (rb != null) return;
        rb = transform.GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + " Load Rigid successful");
    }
    protected virtual void ChangeColliderInfor()
    {
        cCollider2D.isTrigger = true;
        cCollider2D.radius = 3f;
    }

    protected virtual void ChangeRidbodyInfor()
    {
        rb.mass = 0.1f;
        
    }

    protected virtual void LoadSound()
    {
        if (jumpSound != null) return;
        jumpSound = transform.GetComponent<AudioSource>();
        Debug.Log(transform.name + " Load Jump sound successful");
    }
    private void Update()
    {
        curPosY = transform.position.y;
        if(Math.Abs(curPosY - prePosY) > 0.01f) 
             ChangeRot();
        prePosY = curPosY;
    }

    protected virtual void ChangeRot()
    {
       
        float angleDeg = Mathf.Atan2(curPosY - prePosY, 0.5f) * Mathf.Rad2Deg;
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.z = angleDeg;
        transform.eulerAngles = currentRotation;
      
    }

    public void Jumping()
    {
        rb.AddForce(Vector2.up * jumpForce);
        jumpSound.Play();
    }

    public void ChangePos()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Min(pos.y, maxHeight);
        pos.y = Mathf.Max(pos.y, minHeight);
        transform.position = pos;
    }
  
    
}
