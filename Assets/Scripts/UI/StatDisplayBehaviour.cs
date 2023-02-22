using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// static bool TryGetAttribute<T>(MemberInfo memberInfo, out T customAttribute) where T: Attribute 
// {
//                  var attributes = memberInfo.GetCustomAttributes(typeof(T), false).FirstOrDefault();
//                 if (attributes == null) {
//                     customAttribute = null;
//                     return false;
//                 }
//                 customAttribute = (T)attributes;
//                 return true;
//             }



public class StatDisplayBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> displayed_fields;
    public virtual List<Text> get_display_texts() 
    {
        List<Text> retval = new List<Text>();
        foreach (Transform child in transform)
        {
            retval.Add(child.GetComponent<Text>());
        }
        return retval;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
