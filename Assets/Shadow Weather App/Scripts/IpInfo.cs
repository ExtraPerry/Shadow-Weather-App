using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

/** Notes :
 * 
 * Newtonsoft.Json has a few issues with unity :/
 * https://stackoverflow.com/questions/71664312/using-unity-plastic-newtonsoft-json-not-found-in-rider
 * https://discussions.unity.com/t/json-newtonsoft-the-type-or-namespace-name-plastic-does-not-exist-in-the-namespace-unity/256898/2
 *
*/

[CreateAssetMenu()]
public class IpInfo : ApiInfo
{
    public IpData data { get; set; } = null;

    private void Awake()
    {
        if (data is null) Reset();
    }

    public override void Reset()
    {
        this.data = new IpData(
            "success",
            "France",
            "FR",
            "IDF",
            "Île-de-France",
            "Villecresnes",
            "94440",
            48.7184,
            2.5406,
            "Europe/Paris",
            "Societe Francaise Du Radiotelephone - SFR SA",
            "SFR Infra",
            "AS15557 Societe Francaise Du Radiotelephone - SFR SA",
            "37.65.140.117"
        );
    }
}
