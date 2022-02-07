using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeScript : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector3 _initialPosition;
    private float _distanceMoved;
    private bool _swipedLeft;
    private int _cardIndex = 0;
    private bool _isAMatch = false;


    public Kaiju[] dejts;
    public Game_Manager game_manager;


    private void Start()
    {
        gameObject.GetComponent<Image>().sprite = dejts[_cardIndex].tinderPic;
        GetComponentInChildren<Text>().text = dejts[_cardIndex].kaijuName;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!_isAMatch)
        {
            transform.localPosition = new Vector2(transform.localPosition.x + eventData.delta.x, transform.localPosition.y + eventData.delta.y);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _initialPosition = transform.localPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _distanceMoved = Mathf.Abs(transform.localPosition.x - _initialPosition.x);

        if (_distanceMoved < 0.15 * Screen.width)
        {
            transform.localPosition = _initialPosition;
        }
        else
        {
            if (transform.localPosition.x > _initialPosition.x)
            {
                _swipedLeft = false;
            }
            else
            {
                _swipedLeft = true;
            }
            StartCoroutine(MovedCard());
        }

    }

    private IEnumerator MovedCard()
    {
        float time = 0;

        //medan kortet inte är genomskinligt.
        while (GetComponent<Image>().color != new Color(1, 1, 1, 0))
        {
            time += Time.deltaTime;

            if (_swipedLeft)
            {
                //Avsluta påbörjad swipe.
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x, transform.localPosition.x - Screen.width, 4 * time), transform.localPosition.y, 0);

            }
            else
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x, transform.localPosition.x + Screen.width, 4 * time), transform.localPosition.y, 0);
                //Om dejten gilla vald prop
                if (game_manager.GetSelectedPropName() != null)
                {
                    if (dejts[_cardIndex].likedProp == game_manager.GetSelectedPropName())
                    {
                        _isAMatch = true;
                    }
                }
            }

            //Gör kortet genomskinligt
            GetComponent<Image>().color = new Color(1, 1, 1, Mathf.SmoothStep(1, 0, 4 * time));
            yield return null;
        }

        // om det inte är en match
        if (!_isAMatch)
        {
            // byt kort
            _cardIndex++;
            if (_cardIndex > dejts.Length - 1)
            {
                _cardIndex = 0;
            }


            //återställ position och färg
            gameObject.GetComponent<Image>().sprite = dejts[_cardIndex].tinderPic;
            GetComponentInChildren<Text>().text = dejts[_cardIndex].kaijuName;

            gameObject.transform.localPosition = _initialPosition;
            GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            //Om det är en match
            gameObject.transform.localPosition = _initialPosition;
            GetComponent<Image>().color = new Color(1, 1, 1, 1);
            Transform match_text = transform.parent.Find("Match_Text");

            if (match_text != null)
            {
                match_text.GetComponent<Text>().text = "MATCH!";

            }
            Matched();
        }
    }

    private void Matched()
    {
        game_manager.SetSlectedDejt(dejts[_cardIndex]);
    }
}
