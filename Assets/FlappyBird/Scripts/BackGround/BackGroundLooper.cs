
using UnityEngine;

public class BackGroundLooper : ComponentBehavior
{
   public float speed = -0.1f;
   private Vector2 offset = Vector2.zero;
   private Material material;
   private static readonly int MainTex = Shader.PropertyToID("_MainTex");
   protected override void ResetValue()
   {
      base.ResetValue();
      this.speed = -0.05f;
   }

   protected override void Start()
   {
      material = GetComponent<Renderer>().material;
      offset = material.GetTextureOffset(MainTex);
   }

   private void Update()
   {
      offset += Vector2.left * (speed * Time.deltaTime);
      material.SetTextureOffset(MainTex, offset);
   }
}
