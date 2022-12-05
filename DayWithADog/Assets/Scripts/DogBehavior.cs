using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogBehavior : MonoBehaviour {
    private bool isIdle;
    private bool idleMoving;
    private int movingDirection;
    private const int Right = 1;
    private const int Left = -1;
    [SerializeField]
    private RectTransform rt;
    [SerializeField]
    private Image image;
    [SerializeField]
    private List<Sprite> _sprites;
    private Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();
    [SerializeField]
    private List<DogAction> dogActionsToDo;
    [SerializeField]
    private GameEvent allActionsDone;

    void Start(){
        isIdle = true;
        idleMoving = true; 
        movingDirection = Random.Range(1, 3);
        for (int i = 0; i< _sprites.Count; i++){
            sprites.Add(_sprites[i].name, _sprites[i]);
        }
    }

    private void setRandomIdle(int chance){
        float random = Random.Range(0, 100);
        if (random < chance){ 
            idleMoving = !idleMoving;
        }

    }

    private void Idle(){
        if (idleMoving){
                image.sprite = sprites["dog_play"];
            if (rt.anchoredPosition.x >= 320f){
                movingDirection = Left;
                setRandomIdle(50);
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            else if (rt.anchoredPosition.x == 0){
                setRandomIdle(50);
            }
            else if (rt.anchoredPosition.x  <= -320f){
                movingDirection = Right;
                setRandomIdle(50);
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x + (2f * movingDirection), -150f);
        }
        else{
            image.sprite = sprites["dog_idle"];
            setRandomIdle(5);
   
        }
    }

    void FixedUpdate(){
        if (isIdle){
            Idle();
        }
    }       

    public void Act(DogAction dogAction){
        isIdle = false;
        image.sprite = sprites["dog_idle"];
        dogAction.Act();
        StartCoroutine(FinishDogAction(dogAction));

    }

    IEnumerator FinishDogAction(DogAction dogAction){
        GameObject actionItem = GameObject.Find(dogAction.actionItemName);
        yield return new WaitForSeconds(2f);
        isIdle = true;
        actionItem.SetActive(false);
        dogActionsToDo.Remove(dogAction);

        if(dogActionsToDo.Count == 0){
            allActionsDone.Raise();
        }
    }
    
}
