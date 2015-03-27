using UnityEngine;
using System.Collections;

public class ChangeSkyBox : MonoBehaviour
{

    // Light
    public Light[] m_LightList;

    // Skybox
    public Material[] m_SkyboxList;

    // Fog
    Color[] FogColorList;

    // Ambient
    Color[] AmbientLightList;

    // Index to current Skybox
    int m_CurrentSkyBox = 0;

    private GlobalScript globalScript;

    // Use this for initialization
    void Start()
    {

        this.globalScript = GameObject.Find("GlobalScript").GetComponent<GlobalScript>();

        // Init Fog colors array
        FogColorList = new Color[4];

        // Fog Sunny
        FogColorList[0] = new Color(0.431372549f, 0.705882353f, 1f, 1f);
        FogColorList[1] = new Color(0.352941176f, 0.823529412f, 1f, 1f);

        // Fog Night
        FogColorList[2] = new Color(0.1176470588235294f, 0.196078431372549f, 0.392156862745098f, 1f);
        FogColorList[3] = new Color(0.0784313725490196f, 0.1568627450980392f, 0.392156862745098f, 1f);

        // Init Ambient light colors array
        AmbientLightList = new Color[4];

        // Ambient Sunny
        AmbientLightList[0] = new Color(0.62745098f, 0.705882353f, 0.705882353f, 1f);
        AmbientLightList[1] = new Color(0.705882353f, 0.705882353f, 0.705882353f, 1f);

        // Ambient Night
        AmbientLightList[2] = new Color(0.1372549019607843f, 0.1372549019607843f, 0.1372549019607843f, 1f);
        AmbientLightList[3] = new Color(0.1372549019607843f, 0.1372549019607843f, 0.1372549019607843f, 1f);

        this.SwitchSkyBox(this.globalScript.tipoDiaEscolhido - 1);
    }

    void SwitchSkyBox(int skyBoxNum)
    {
        // update m_CurrentSkyBox
        m_CurrentSkyBox += skyBoxNum;

        // switch skybox
        RenderSettings.skybox = m_SkyboxList[m_CurrentSkyBox];

        // Set active/deactive lights
        for (int i = 0; i < m_LightList.Length; i++)
        {
            if (i == m_CurrentSkyBox)
            {
                m_LightList[i].gameObject.SetActive(true);
            }
            else
            {
                m_LightList[i].gameObject.SetActive(false);
            }
        }

        // Enable fog
        RenderSettings.fog = true;

        // Set the fog color
        if (m_CurrentSkyBox >= 0 && m_CurrentSkyBox < FogColorList.Length)
        {
            RenderSettings.fogColor = FogColorList[m_CurrentSkyBox];
        }
        else
        {
            RenderSettings.fogColor = Color.white;
        }

        // Set the ambient lighting
        if (m_CurrentSkyBox >= 0 && m_CurrentSkyBox < AmbientLightList.Length)
        {
            RenderSettings.ambientLight = AmbientLightList[m_CurrentSkyBox];
        }
        else
        {
            RenderSettings.ambientLight = Color.white;
        }
    }
}
