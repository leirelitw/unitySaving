using UnityEngine;
using System.Collections;

public class Demo : MonoBehaviour {

    private readonly string[] m_animations = { "Pickup","Wave" };
    private Animator[] m_animators;
    [SerializeField] private CameraLogic m_cameraLogic;

    private void Start()
    {
        m_animators = FindObjectsOfType<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            m_cameraLogic.PreviousTarget();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_cameraLogic.NextTarget();
        }
    }

    private void OnGUI()
    {
		GUILayout.BeginVertical(GUILayout.Width(150));

        GUILayout.Space(20);

        for(int i = 0; i < m_animations.Length; i++)
        {
            if(i == 0){
				GUILayout.BeginHorizontal();
				GUILayout.Space(20);
			}

            if(GUILayout.Button(m_animations[i]))
            {
                for(int j = 0; j < m_animators.Length; j++)
                {
                    m_animators[j].SetTrigger(m_animations[i]);
                }
            }

            if(i == m_animations.Length - 1) { 
				GUILayout.EndHorizontal(); 
			}
            else if (i == (m_animations.Length / 2)) {
				GUILayout.EndHorizontal(); 
				GUILayout.BeginHorizontal(); 
			}
        }

        Color oldColor = GUI.color;
        GUI.color = Color.black;
        GUI.color = oldColor;

        GUILayout.EndVertical();
    }
}
