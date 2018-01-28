using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateParent : MonoBehaviour {

    [SerializeField]
    bool inputTop;
    [SerializeField]
    bool inputBottom;

    [SerializeField]
    GameObject influencee1;
    [SerializeField]
    GameObject influencee2;

    //output of gate
    bool output;

    //type of gate
    int gateType = 1;

    [Header("Sprites")]
    [SerializeField]
    Sprite andSprite;
    [SerializeField]
    Sprite nandSprite;
    [SerializeField]
    Sprite orSprite;
    [SerializeField]
    Sprite norSprite;
    [SerializeField]
    Sprite xorSprite;
    [SerializeField]
    Sprite xnorSprite;

    [SerializeField]
    BoxCollider2D coll;

    public bool Output
    {
        get
        {
            return output;
        }
        set
        {
            output = value;
        }
    }

    public bool InputTop
    {
        get
        {
            return inputTop;
        }
        set
        {
            inputTop = value;
        }
    }

    public bool InputBottom
    {
        get
        {
            return inputBottom;
        }
        set
        {
            inputBottom = value;
        }
    }

    public int GateType
    {
        get
        {
            return gateType;
        }
        set
        {
            gateType = value;
        }
    }


    Ray ray;
    RaycastHit hit;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        if (influencee1.tag == "Gate")
        {
            influencee1.GetComponent<GateParent>().InputTop = output;
        }
        if (influencee1.tag == "Button")
        {
            influencee1.GetComponent<Button>().state = output;
        }
        if (influencee1.tag == "Button 2")
        {
            influencee1.GetComponent<Button>().state = !output;
        }
        if (influencee2.tag == "Gate")
        {
            influencee2.GetComponent<GateParent>().InputTop = output;
        }
        if (influencee2.tag == "Button")
        {
            influencee2.GetComponent<Button>().state = output;
        }
        if (influencee2.tag == "Button 2")
        {
            influencee2.GetComponent<Button>().state = !output;
        }

        this.DecideOutput(inputTop, inputBottom);
    }

    void DecideOutput(bool top, bool bottom)
    {
        switch (this.gateType)
        {
            case 1:
                if (top && bottom)
                {
                    output = true;
                }
                else
                {
                    output = false;
                }
                break;
            case 2:
                if (top && bottom)
                {
                    output = false;
                }
                else
                {
                    output = true;
                }
                break;
            case 3:
                if (top || bottom)
                {
                    output = true;
                }
                else
                {
                    output = false;
                }
                break;
            case 4:
                if (top || bottom)
                {
                    output = false;
                }
                else
                {
                    output = true;
                }
                break;
            case 5:
                if (top ^ bottom)
                {
                    output = true;
                }
                else
                {
                    output = false;
                }
                break;
            case 6:
                if (top ^ bottom)
                {
                    output = false;
                }
                else
                {
                    output = true;
                }
                break;
            default:
                break;
        }
    }

    private void OnMouseDown()
    {
  
                if (this.gateType < 6)
                {
                    this.gateType++;
                }
                else if(this.gateType == 6)
                {
                    this.gateType = 1;
                }
                switch(this.gateType)
                {
                    case 1:
                        this.GetComponent<SpriteRenderer>().sprite = andSprite;
                        break;
                    case 2:
                        this.GetComponent<SpriteRenderer>().sprite = nandSprite;
                        break;
                    case 3:
                        this.GetComponent<SpriteRenderer>().sprite = orSprite;
                        break;
                    case 4:
                        this.GetComponent<SpriteRenderer>().sprite = norSprite;
                        break;
                    case 5:
                        this.GetComponent<SpriteRenderer>().sprite = xorSprite;
                        break;
                    case 6:
                        this.GetComponent<SpriteRenderer>().sprite = xnorSprite;
                        break;
                    default:
                        break;
                }
    }
}
