using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnJenga : MonoBehaviour
{
    public GameObject _prefabJenga;
    public int _towerHight;
    public int _towerwidth;

    public List<Rigidbody> _jengaTower = new List<Rigidbody>();
    public List<Material> _jengaMaterials = new List<Material>();

    //private void Start()
    //{
    //    //for (int i = 0; i < _towerHight; i++)
    //    //{
    //    //    for (int j = 0; j < 3; j++)
    //    //    {
    //    //        GameObject tempJenga = Instantiate(_prefabJenga);
    //    //        tempJenga.transform.Rotate(Vector3.up * 90 * i);
    //    //        tempJenga.transform.position = transform.position + tempJenga.transform.forward * (j - 1) + transform.up * 0.5f * i;
    //    //    }
    //    //}
    //}

    private void Start()
    {
        Time.timeScale = 0.5f;

        for (float j = 0; j < _towerHight; j += 0.5f)
        {
            for (int i = -1; i < _towerwidth - 1; i++)
            {
                _jengaTower.Add(Instantiate(_prefabJenga, new Vector3(0f, j, i), Quaternion.identity, transform).GetComponent<Rigidbody>());
                //_jengaMaterials.Add(_jengaTower[i].gameObject.GetComponent<Renderer>().material);
            }
            transform.Rotate(Vector3.up, 90f);
        }

        for (int i = 0; i < _jengaTower.Count; i++)
        {
            _jengaTower[i].transform.parent = null;
        }
    }

    private void Update()
    {
        foreach (Rigidbody item in _jengaTower)
        {
            //item.GetComponent<MeshRenderer>().material.color = new Color(item.position.x, item.position.y, item.position.z);
            item.GetComponent<Renderer>().material.color = new Color(Mathf.Abs(item.position.x / 100), Mathf.Abs(item.position.y / 100), Mathf.Abs(item.position.z / 100));
            //item.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0, 255)/100, Random.Range(0, 255)/100, Random.Range(0, 255)/100);
            //item.GetComponent<MeshRenderer>().material.color = new Color(Mathf.Repeat(Time.time, 255f), Mathf.Repeat(Time.time, 255f), Mathf.Repeat(Time.time, 255f));
            //item.GetComponent<MeshRenderer>().material.color = new Color(Mathf.Repeat(1f, Time.time), Mathf.Repeat(1f, Time.time), Mathf.Repeat(1f, Time.time));
        }

        //for (int i = 0; i < _jengaMaterials.Count; i++)
        //{
        //    _jengaMaterials[i].color = Color.HSVToRGB(Mathf.Repeat(i / _jengaMaterials.Count + Time.time, 1), 1, 1);
        //}
    }
}
