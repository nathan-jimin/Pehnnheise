var Health : int = 3;
var Character : GameObject;
var BulletTag : String;
 
function Start () {
 
}
 
function OnCollisionEnter ( collision : Collision ){
 
if(collision.gameObject.tag == BulletTag) 
{
Health--; 
Destroy(collision.gameObject); 
 
}
 
if(Health < 1){
Destroy(Character);
}
}
