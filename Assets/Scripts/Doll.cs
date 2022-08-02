using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Doll : MonoBehaviour
{
	public static Doll Instance;

	#region Variable Declarations

	[Header("Doll values")]
	public float speed = 1f;
	public Animator DollAnim;
	[SerializeField]
	private Rigidbody _rigidbody;
	[SerializeField]
	private Camera _mainCam;

	[Header("Private values")]
	private float _objZPos;
	private float _movZ;
	private bool isMouseDragging;



	#endregion

	private void Awake()
	{
		Instance = this;
		//Camera.main.WorldToScreenPoint.;
    
    }

   
    private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_objZPos = _mainCam.WorldToScreenPoint(gameObject.transform.position).z;
			isMouseDragging = true;
		}
		if (Input.GetMouseButtonUp(0))
		{
			isMouseDragging = false;
		}

		if (isMouseDragging)
		{
			var mousePoint = Input.mousePosition;
			mousePoint.z = _objZPos;
			_movZ = _mainCam.ScreenToWorldPoint(mousePoint).z;
		}


	
	}


    private void FixedUpdate()
    {
		var x = (speed * Time.fixedDeltaTime) * -1;

		var newPosition = transform.position + new Vector3(x, 0, 0);

		//to stay on the track
		if (_movZ > 0.9f)
		{
			newPosition.z = 0.9f;
		}
		else if (_movZ < -1)
		{
			newPosition.z = -1;
		}
		else
		{
			newPosition.z = _movZ;
		}

		_rigidbody.MovePosition(newPosition);
	}

    private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Diamond")
		{
			if (other.TryGetComponent<Money>(out Money _m))
			{
				ScoreManager.Instance.IncrementMoney(_m.m_Money);
				Destroy(other.gameObject);
			}

		}
		else
		 if (other.tag == "Clothes")
		{
			if (other.TryGetComponent<Clothes>(out Clothes _cloth))
			{
				Clothes.Instance.ChangeClothes(_cloth.m_Cloth.transform.parent);
				_cloth.m_Cloth.SetActive(true);
				ScoreManager.Instance.DesincreamentScore(_cloth.m_price);
				Destroy(other.gameObject);

			}

		}
	}

	public void StopDoll()
    {
		speed = 0;
		DollAnim.SetTrigger("Idle");
		isMouseDragging = false;
	}
	
}