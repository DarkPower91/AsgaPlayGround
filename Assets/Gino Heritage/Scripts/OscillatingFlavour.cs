using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void FlavourChanged(Flavours newFlavour);

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class OscillatingFlavour : MonoBehaviour
{
    #region Public fields
    [Readonly]
    public Flavours CurrentFlavour = Flavours.electronic;
    public FlavourDefinition m_GameOverFlavorMessage = null;
    public GameObject ExplosionAnimation = null;
    public event FlavourChanged OnFlavourChanged = null;

    #endregion

    #region Private fields
    private float changeTime = 1;
    private int availableNeutrinos = (int)Flavours.count;
    private Animator animator;
    private Flavours m_NextFlavour;
    #endregion

    private Flavours randomNeutrino()
    {
        return (Flavours)Random.Range(0, availableNeutrinos);
    }

    private void Awake() 
    {
        animator = GetComponent<Animator>(); 
    }

    void Start()
    {
        StartCoroutine(flavourChange());
        m_NextFlavour = CurrentFlavour = randomNeutrino();
        animator.SetInteger( "flavour", (int) CurrentFlavour );
    }

    void Update()
    {
        if(m_NextFlavour == CurrentFlavour)
        {
            m_NextFlavour = randomNeutrino();
        }
    }

    private IEnumerator flavourChange() 
    {
        while (true) 
        {    
            if(FlowManager.GetGameState() == GameState.InGame)
            {
                CurrentFlavour = m_NextFlavour;
                animator.SetInteger( "flavour", (int) CurrentFlavour );

                if (OnFlavourChanged != null)
                {
                    OnFlavourChanged(CurrentFlavour);
                }

                yield return new WaitForSeconds(changeTime); 
            }
            else
            {
                yield return null;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        #if UNITY_EDITOR
        if(GameObject.FindGameObjectWithTag("DebugManager").GetComponent<DebugManager>().isInGodMode)
            return;
        #endif

        FlavourDefinition otherFlavour = other.gameObject.GetComponent<FlavourDefinition>();
        if (otherFlavour != null) 
        {
            if (otherFlavour.flavour == CurrentFlavour) 
            {
                Destroy(other.gameObject);
                FlowManager.SetFlowState(GameState.GameOver);
                m_GameOverFlavorMessage.SetFlavour(CurrentFlavour);
                if(ExplosionAnimation != null)
                {
                    ExplosionAnimation.SetActive(true);
                    StartCoroutine(DisableFx());
                    
                }
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                this.gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
    }

    private IEnumerator DisableFx()
    {
        yield return null;

        float clipDuration = ExplosionAnimation.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(clipDuration);

        ExplosionAnimation.SetActive(false);
    }
}
