using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainGenerator : MonoBehaviour
{
    public GameObject _linkPrefab;

    List<Rigidbody> _linkBodies = new List<Rigidbody>();

    public int _linkCount = 10;
    public float _linkScale = 1;


    public float _spring = 100;
    public float _dumper = 1;

    private void Start()
    {
        for (int i = 0; i < _linkCount; i++)
        {
            _linkBodies.Add(Instantiate(_linkPrefab).GetComponent<Rigidbody>());
            _linkBodies[i].transform.localScale = Vector3.one * _linkScale;
            _linkBodies[i].transform.position = transform.position + transform.forward * i * _linkScale;
            //_linkBodies[i].transform.rotation = transform.rotation;
        }

        for (int i = 1; i < _linkBodies.Count; i++)
        {
            // Attacher ensemble les SpringJoints
            SpringJoint springJoint = _linkBodies[i].gameObject.AddComponent<SpringJoint>();
            springJoint.connectedBody = _linkBodies[i - 1];
            springJoint.anchor = Vector3.forward * _linkScale;
            springJoint.autoConfigureConnectedAnchor = false;
            springJoint.connectedAnchor = Vector3.zero;
            springJoint.spring = _spring;
            springJoint.damper = _dumper;
            springJoint.enableCollision = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, Vector3.up);
        Gizmos.DrawLine(transform.position, Vector3.down);
        Gizmos.DrawLine(transform.position, Vector3.right);
        Gizmos.DrawLine(transform.position, Vector3.left);
        Gizmos.DrawLine(transform.position, Vector3.forward);
        Gizmos.DrawLine(transform.position, Vector3.back);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.forward);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.back);

        
        if(_linkBodies != null)
        {
            for (int i = 0; i < _linkBodies.Count; i++)
            {
                SpringJoint debugAnchor;
                debugAnchor = _linkBodies[i].gameObject.GetComponent<SpringJoint>();
                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(debugAnchor.anchor, 0.1f);
                Gizmos.color = Color.cyan;
                Gizmos.DrawSphere(debugAnchor.connectedAnchor, 0.1f);
            }
        }
    }
}
