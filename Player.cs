using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour

{
    public float jumpForce = 1.5f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
   
    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;
    
    public AudioSource coin;
    public AudioSource coin2;

    public GameObject circlePrefab;
    public GameObject nestedCirclePrefab;
    public GameObject colorChangerPrefab;

    public Transform lastCircle;

    public ParticleSystem color;
    

    private Color currentColor;
    private string currentStringColor;
    private bool gameOver = false ;
    public bool flapping = false ;
   
   void Start()
   {
     SetRandomColor();
     var main = color.main;
     main.startColor = currentColor;
   }
   void Update()
    {
     if ( Input.GetTouch(0).tapCount==1  )
       {
        flapping = true;
       } 
    }
   
   void OnTriggerEnter2D(Collider2D col)
   {
       if (col.tag == "COLOR CHANGER")
       {
        
        SetRandomColor();
        coin.Play();
        Destroy(col.gameObject);
        Instan();
        
        var main = color.main;
        main.startColor = currentColor;
        return;
       }
       if (col.tag != currentStringColor && !gameOver)
        { 
           gameOver = true;
           coin2.Play();
           Invoke("Restart", 1);

          
        }

    }
   void Instan()
   {
       GameObject prefabCircle;
       Transform colorChange;

       int a = Random.Range(0,4);

       if(a == 0)   
           prefabCircle = nestedCirclePrefab;
       
       else
           prefabCircle = circlePrefab;
        
       if (lastCircle.gameObject.tag.Equals("Circle"))
       {
         colorChange = Instantiate(colorChangerPrefab, new Vector2(0,lastCircle.position.y +4),Quaternion.identity).transform;
           
           if(prefabCircle.tag.Equals("Circle"))
               lastCircle =  Instantiate(prefabCircle, new Vector2(0,colorChange.position.y +4),Quaternion.identity).transform;
           
           else 
               lastCircle = Instantiate(prefabCircle, new Vector2(0,colorChange.position.y +5),Quaternion.identity).transform;
        
       }
       else 
       {     
              colorChange = Instantiate(colorChangerPrefab, new Vector2(0,lastCircle.position.y +5),Quaternion.identity).transform;
              
              if(prefabCircle.tag.Equals("Circle"))

                lastCircle =  Instantiate(prefabCircle, new Vector2(0, colorChange.position.y +4),Quaternion.identity).transform;
            
              else

                lastCircle =  Instantiate(prefabCircle, new Vector2(0, colorChange.position.y +5),Quaternion.identity).transform;


       }

   }
   void Restart()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
   
   void SetRandomColor()
   {
       int index = Random.Range(0,4);

       switch(index)
       {
           case 0:
                sr.color = colorCyan;
                currentStringColor = "CYAN";
                currentColor = colorCyan;
                break;
           case 1:
                sr.color = colorYellow;
                currentStringColor = "YELLOW";
                currentColor = colorYellow;

                break;
           case 2:
                sr.color = colorMagenta;
                currentStringColor = "MAGENTA";
                currentColor = colorMagenta;

                break;
           case 3:
                sr.color = colorPink;
                currentStringColor = "PING";
                currentColor = colorPink;
                break;

       }
   }
}
