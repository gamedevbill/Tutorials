using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class BurnController : MonoBehaviour
{
    private MeshRenderer m_mesh;
    private bool m_active = false;
    private float m_percent = 0.0f;
    public float TimeScale = 1;
    private int m_counter = 100;
	
	public Vector2 NoiseData;
	public Vector2 NoiseScaling;
	private Vector2 m_noiseData;
	private List<List<float>> m_data;
	private int m_dataCount = 0;

	public bool UseData;


	void Start()
    {
        m_mesh = gameObject.GetComponent<MeshRenderer>();

        m_data = new List<List<float>>();
        m_data.Add(new List<float>
        {
	        0.91f, 0.99f, //burn point 
	        0.62f,0.26f, //noise Data
	        0.005f, 0.0005f, //noise scaling
	        8.5f //unburn curl
        });
        m_data.Add(new List<float>
        {
	        0.42f, 0.9f, //burn point 
	        0,0, //noise Data
	        0.005f, 0.0005f, //noise scaling
	        15 //unburn curl
        });
        m_data.Add(new List<float>
        {
	        0.8f, 0.4f, //burn point 
	        1,2, //noise Data
	        0.005f, 0.0005f, //noise scaling
	        10 //unburn curl
        });
        m_data.Add(new List<float>  ///settings for title burn
        {
	        0.35f, 0.67f, //burn point 
	        0.17f,0.26f, //noise Data
	        0.005f, 0.0005f, //noise scaling
	        8.58f //unburn curl
        });
        m_data.Add(new List<float>
        {
	        0.35f, 0.67f, //burn point 
	        11,9, //noise Data
	        0.005f, 0.0005f, //noise scaling
	        6 //unburn curl
        });
    }

	void Update()
	{
		m_counter++;
		if(!m_active && m_counter > 100)
		{
			m_counter = 0;
			m_active = true;
			m_percent = 0;

			if (UseData)
			{
				m_percent = 0;
				
				var data = m_data[m_dataCount];
				m_dataCount++;
				if (m_dataCount >= m_data.Count)
					m_dataCount = 0;


				var burnPoint = new Vector2(data[0], data[1]);
				m_mesh.material.SetVector("_BurnPoint", burnPoint);
				m_noiseData = new Vector2(data[2], data[3]);
				NoiseScaling.x = data[4];
				NoiseScaling.y = data[5];
				m_mesh.material.SetFloat("_UnburnCurl", data[6]);
			}
			else
			{
				m_noiseData = NoiseData;
			}
		}

		if (m_active)
		{
			//if(m_reverse)
			//{
			//	m_percent -= Time.deltaTime * TimeScale;
			//	if(m_percent <= 0)
			//	{
			//		m_reverse = false;
			//		
			//		
			//		
			//		var data = m_data[m_dataCount];
			//		m_dataCount++;
			//		if (m_dataCount >= m_data.Count)
			//			m_dataCount = 0;
			//
			//
			//		var burnPoint = new Vector2(data[0], data[1]);
			//		m_mesh.material.SetVector("_BurnPoint", burnPoint);
			//		m_noiseData = new Vector2(data[2], data[3]);
			//		NoiseScaling.x = data[4];
			//		NoiseScaling.y = data[5];
			//		m_mesh.material.SetFloat("_UnburnCurl", data[6]);
			//		
			//	}
			//}
			//else{
			
				m_percent += Time.deltaTime * TimeScale;
				if (m_percent >= 1)
				{
					m_percent = 1;
					m_active = false;
				}
			//}
			
			m_noiseData.x += NoiseScaling.x * TimeScale;
			m_noiseData.y += NoiseScaling.y * TimeScale;
			
			m_mesh.material.SetFloat("_PercentComplete", m_percent);
			m_mesh.material.SetVector("_NoiseData", m_noiseData);
			
		}
	}
}
