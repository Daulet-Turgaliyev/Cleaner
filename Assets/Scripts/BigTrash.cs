using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BigTrash : MonoBehaviour
{
    

    [SerializeField] private float _hp;
    [SerializeField] private float _damage;

    public GameObject Parent_Trash;
    public GameObject Body_Trash;

    private void Start()
    {
        _hp = Random.Range(1f, 4f);
        _damage = Random.Range(.05f, 1f);

        Body_Trash.transform.localScale = new Vector3(_hp, _hp, _hp);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player") {
            _hp -= _damage;
            Damage();

        }
    }

  

    private void Damage()
    {

        if (_hp > .1f) { Body_Trash.transform.localScale = new Vector3(_hp, _hp, _hp); }
        else { Destroy(Parent_Trash); }
    }
}
