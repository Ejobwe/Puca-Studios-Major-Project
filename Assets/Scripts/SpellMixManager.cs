using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SpellMixManager : MonoBehaviour
{
    public  List<GameObject>  Spells = new List<GameObject>();
    public List<SpellProperty> Props = new List<SpellProperty>();
    private int oldcount;
    void Start()
    {
        StartCoroutine(Flush());
    }

    
    void Update()
    {
        oldcount = Spells.Count;
        for (int i = 0; i < Spells.Count; i++)
        {
            for (int j = 0; j < Spells.Count; j++)
            {
                if (Props[i].combo ==Spells[j])
                {
                    SpellFuse(Props[i],Props[j]);
                }
            }
        }
    }

    private void SpellFuse(SpellProperty SP1, SpellProperty SP2)
    {
        if ((SP1.Burning || SP2.Burning) && (SP1.Wet || SP2.Wet))
        {
            Debug.Log("WE MADE STEAM");
        }
    }
    #region Flush

    

    
    private IEnumerator Flush()
    {
        for (int i = 0; i < Spells.Count; i++)
        {
            if (null == Spells[i])
            {
                Spells.Remove(Spells[i]);
            }
        }
        for (int i = 0; i < Props.Count; i++)
        {
            if (Props[i] == null)
            {
                Props.Remove(Props[i]);
            }
        }
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Flush());
    }
    #endregion
    
}
