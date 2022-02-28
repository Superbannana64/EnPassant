using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testingdisable : MonoBehaviour
{
    public GameObject rock;
    bool check;
    bool isEnable;
    // Start is called before the first frame update
    void Start()
    {
        isEnable = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool checking = disable();
        theCheck(checking, isEnable);
    }
    
    bool disable()
    {
        check = Input.GetKeyDown(KeyCode.X);
        return check;
    }
    void theCheck(bool check, bool isEnable)
    {
        
        if(check && isEnable)
        {
            rock.SetActive(false);
        }
        else if(check && !isEnable)
        {
            rock.SetActive(true);
        }
        else
        Debug.Log("Nothing");
    }
}
