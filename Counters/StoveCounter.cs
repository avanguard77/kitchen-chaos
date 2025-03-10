using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter,IHasProgress
{
    public event EventHandler<OnStateChangedArges> OnStateChanged;
    public event EventHandler<IHasProgress.OnProgressChangedEventArg> OnProgressChanged;

    public class OnStateChangedArges : EventArgs
    {
        public State state;
    }

    public enum State
    {
        Idle,
        Frying,
        Fried,
        Burned,
    }

    [SerializeField] FryingRecepiSo[] fryingRecepiSoArray;
    [SerializeField] BurningRecepiSo[] burningRecepiSoArray;


    private FryingRecepiSo fryingRecepiSo;
    private BurningRecepiSo burningRecepiSo;

    private float fryingTimer;
    private float burningTimer;

    private State state;

    private void Start()
    {
        state = State.Idle;
    }

    private void Update()
    {
        if (hasKitchenObject())
        {
            switch (state)
            {
                case State.Idle:
                    break;
                case State.Frying:
                {
                    fryingTimer += Time.deltaTime;
                    
                    OnProgressChanged?.Invoke(this,new IHasProgress.OnProgressChangedEventArg()
                    {
                        progressNormalized = fryingTimer/fryingRecepiSo.fruingRecepiSoTimer
                    });

                    if (fryingTimer >= fryingRecepiSo.fruingRecepiSoTimer)
                    {
                        //Fried
                        getKitchenObject().destroySelf();

                        KitchenObject.SpawnKitchenObject(fryingRecepiSo.output, this);
                        state = State.Fried;
                        burningTimer = 0;
                        burningRecepiSo = GetBurningRecepiSowithInput(getKitchenObject().GetKitchenObjectSo());
                        OnStateChanged?.Invoke(this, new OnStateChangedArges { state = state });
                        
                        
                        
                    }
                }
                    break;
                case State.Fried:
                {
                    burningTimer += Time.deltaTime;
                    
                    OnProgressChanged?.Invoke(this,new IHasProgress.OnProgressChangedEventArg()
                    {
                        progressNormalized = burningTimer/burningRecepiSo.burningTimerMax
                    });

                    if (burningTimer >= burningRecepiSo.burningTimerMax)
                    {
                        //Fried
                        getKitchenObject().destroySelf();

                        KitchenObject.SpawnKitchenObject(burningRecepiSo.output, this);
                        state = State.Burned;
                        OnStateChanged?.Invoke(this, new OnStateChangedArges { state = state });
                        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArg()
                        {
                            progressNormalized = 0f
                        });
                    }
                }
                    break;
                case State.Burned:
                    break;
            }

            Debug.Log(state);
        }
    }

    public override void interact(Player player)
    {
        if (!hasKitchenObject())
        {
            //there is no kitchen Object here
            if (player.hasKitchenObject())
            {
                if (HasKitchenRecepi(player.getKitchenObject().GetKitchenObjectSo()))
                {
                    player.getKitchenObject().setKitchenObjectParent(this);
                    fryingRecepiSo = GetFriyingRecepiSowithInput(getKitchenObject().GetKitchenObjectSo());
                    state = State.Frying;
                    OnStateChanged?.Invoke(this, new OnStateChangedArges { state = state });
                    fryingTimer = 0f;
                    OnProgressChanged?.Invoke(this,new IHasProgress.OnProgressChangedEventArg()
                    {
                        progressNormalized = fryingTimer/fryingRecepiSo.fruingRecepiSoTimer
                    });
                }
            }
            else
            {
                //player is not carring sth
            }
        }
        else
        {
            //there is kitchen object 
            if (player.hasKitchenObject())
            {
                //player is carring 
            }
            else
            {
                //player is not 
                getKitchenObject().setKitchenObjectParent(player);
                state = State.Idle;
                OnStateChanged?.Invoke(this, new OnStateChangedArges { state = state });
                OnProgressChanged?.Invoke(this,new IHasProgress.OnProgressChangedEventArg()
                {
                    progressNormalized = 0f
                });
            }
        }
    }

    private bool HasKitchenRecepi(KitchenObjectSo kitchenObjectSo)
    {
        FryingRecepiSo fryingRecepiSo = GetFriyingRecepiSowithInput(kitchenObjectSo);
        return fryingRecepiSo != null;
    }

    private KitchenObjectSo getInputSetOutput(KitchenObjectSo kitchenObjectSo)
    {
        FryingRecepiSo fryingRecepiSo = GetFriyingRecepiSowithInput(kitchenObjectSo);
        if (fryingRecepiSo != null)
        {
            return fryingRecepiSo.output;
        }

        return null;
    }

    private BurningRecepiSo GetBurningRecepiSowithInput(KitchenObjectSo inputKitchenObjectSo)
    {
        foreach (BurningRecepiSo burningRecepiSo in burningRecepiSoArray)
        {
            if (burningRecepiSo.input == inputKitchenObjectSo)
            {
                return burningRecepiSo;
            }
        }

        return null;
    }

    private FryingRecepiSo GetFriyingRecepiSowithInput(KitchenObjectSo inputKitchenObjectSo)
    {
        foreach (FryingRecepiSo fryingRecepiSo in fryingRecepiSoArray)
        {
            if (fryingRecepiSo.input == inputKitchenObjectSo)
            {
                return fryingRecepiSo;
            }
        }

        return null;
    }
}