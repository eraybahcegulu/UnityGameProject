using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keles : MonoBehaviour
{

    public bool atesEdebilirmi;
    float iceridenAtesEtmeSikligi;
    public float disaridanAtesEtmeSikligi;
    public float menzil;
    public Camera benimCam;
    public AudioSource AtesSesi;
    public ParticleSystem AtesEfekt;

    public ParticleSystem Mermi›zi;
    public ParticleSystem KanEfekti;

    Animator animatorum;
    void Start()
    {
        animatorum = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && atesEdebilirmi && Time.time > iceridenAtesEtmeSikligi)
        {
            AtesEt();
            iceridenAtesEtmeSikligi = Time.time + disaridanAtesEtmeSikligi;
        }
        
    }

    void AtesEt()
    {
        AtesSesi.Play();
        AtesEfekt.Play();
        animatorum.Play("ateset");

        RaycastHit hit;
        if(Physics.Raycast(benimCam.transform.position,benimCam.transform.forward,out hit,menzil))
        {

            if (hit.transform.gameObject.CompareTag("Dusman"))
            {
                Instantiate(KanEfekti, hit.point, Quaternion.LookRotation(hit.normal));
            }

            else if (hit.transform.gameObject.CompareTag("DevrilebilirObje"))
            {
                Rigidbody rg = hit.transform.gameObject.GetComponent<Rigidbody>();
                // rg.AddForce(new Vector3(4f, 2f, 3f) * 50f);
                // rg.AddForce(transform.forward * 500f);

                rg.AddForce(-hit.normal * 50f);
                Instantiate(Mermi›zi, hit.point, Quaternion.LookRotation(hit.normal));
            }

            else
            {
                Instantiate(Mermi›zi, hit.point, Quaternion.LookRotation(hit.normal));
            }
            
        }


    }
}
