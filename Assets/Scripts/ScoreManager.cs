using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField]
    private Text _DiamondScore;
   // public GameObject DiamondCanvas;
    int _Diamond;


    private void Awake()
    {
        Instance = this;
    }
   


    public void IncrementMoney(int _diamentValue)
    {
      
       //  DiamondObject.transform.DOMove(DiamondCanvas.transform.position, 2f);
        _Diamond+= _diamentValue;
        _DiamondScore.text = _Diamond.ToString();
    }

    public void DesincreamentScore(int _price)
    {
        _Diamond -= _price;
        _DiamondScore.text = _Diamond.ToString();
        if(_Diamond <=0 )
        {
            _Diamond = 0;
            Doll.Instance.StopDoll();
            _DiamondScore.text = _Diamond.ToString();
        }
        
    }
 
}
