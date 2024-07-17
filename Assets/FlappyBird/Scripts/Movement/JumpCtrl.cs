
using System;
using UnityEngine;
[RequireComponent((typeof(CircleCollider2D)))]
[RequireComponent((typeof(Rigidbody2D)))]
public class JumpCtrl : ComponentBehavior
{
    [SerializeField] protected CircleCollider2D cCollider2D;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float jumpForce = 80f;
    [SerializeField] protected float prePosY;
    [SerializeField] protected float curPosY;
   
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadRigid();
        this.ChangeColliderInfor();
        this.ChangeRidbodyInfor();
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
    }

  
    
}
