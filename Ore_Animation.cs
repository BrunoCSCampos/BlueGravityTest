using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore_Animation : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AnimateHit()
    {
        StartCoroutine("AnimateRoutine");
    }
    
    public IEnumerator AnimateRoutine()
    {
        animator.SetBool("OreHit 0", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("OreHit 0", false);
        StopCoroutine("AnimateRoutine");
    }

    
}
