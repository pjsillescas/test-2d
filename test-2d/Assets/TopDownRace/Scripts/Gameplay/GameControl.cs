using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TopDownRace
{
	public class GameControl : MonoBehaviour
	{

		public int m_levelRounds;
		[HideInInspector]
		public int m_FinishedLaps;

		public static GameControl m_Current;

		public GameObject m_PlayerCarPrefab;
		public GameObject m_RivalCarPrefab;

		[HideInInspector]
		public int m_PlayerPosition;

		[HideInInspector]
		public GameObject[] m_Cars;

		[HideInInspector]
		public bool m_LostRace;
		[HideInInspector]
		public bool m_WonRace;

		[HideInInspector]
		public int m_StartTimer;

		[HideInInspector]
		public bool m_StartRace;

		public bool isStillPlaying;
		
		private void Awake()
		{
			m_LostRace = false;
			m_WonRace = false;
			m_StartRace = false;
			m_FinishedLaps = 0;
			m_Current = this;

			isStillPlaying = true;
		}
		// Start is called before the first frame update
		void Start()
		{
			StartCoroutine(PlayBackgroundMusic());

			m_Cars = new GameObject[4];

			GameObject playerCar = Instantiate(m_PlayerCarPrefab);
			playerCar.transform.position = RaceTrackControl.m_Main.m_StartPositions[0].position;
			playerCar.transform.rotation = RaceTrackControl.m_Main.m_StartPositions[0].rotation;
			m_Cars[0] = playerCar;

			for (int i = 1; i < 4; i++)
			{
				GameObject rivalCar = Instantiate(m_RivalCarPrefab);
				rivalCar.transform.position = RaceTrackControl.m_Main.m_StartPositions[i].position;
				rivalCar.transform.rotation = RaceTrackControl.m_Main.m_StartPositions[i].rotation;
				m_Cars[i] = rivalCar;
			}

			m_PlayerPosition = 0;

			StartCoroutine(Co_StartRace());

		}

		private IEnumerator PlayBackgroundMusic()
		{
			yield return new WaitForSeconds(2);
			AudioManager.Instance.PlayBackground();
			yield return null;
		}

		private void OnDestroy()
		{
			isStillPlaying = false;

			if (AudioManager.Instance != null)
			{
				AudioManager.Instance.StopBackground();
			}
		}

		// Update is called once per frame
		void Update()
		{
			if (!isStillPlaying)
			{
				return;
			}

			int position = 0;
			int playerPoint = m_FinishedLaps * RaceTrackControl.m_Main.m_Checkpoints.Length + PlayerCar.m_Current.m_CurrentCheckpoint;
			for (int i = 1; i < 4; i++)
			{
				if (m_Cars[i] != null)
				{
					int rivalPoint = m_Cars[i].GetComponent<Rivals>().m_FinishedLaps * RaceTrackControl.m_Main.m_Checkpoints.Length + m_Cars[i].GetComponent<Rivals>().m_WaypointsCounter;
					if (playerPoint < rivalPoint)
					{
						position++;
					}
				}
			}

			m_PlayerPosition = position;
		}

		public bool PlayerLapEndCheck()
		{
			if (m_FinishedLaps == m_levelRounds)
			{
				if (!m_LostRace)
				{
					PlayerCar.m_Current.m_Control = false;
					UISystem.ShowUI("win-ui");
					m_WonRace = true;

				}
				else
				{
					PlayerCar.m_Current.m_Control = false;
					UISystem.ShowUI("lose-ui");
				}
				return true;
			}

			return false;
		}

		public void RivalsLapEndCheck(Rivals rival)
		{
			if (rival.m_FinishedLaps == m_levelRounds)
			{
				if (!m_WonRace)
				{
					m_LostRace = true;
				}
			}
		}


		IEnumerator Co_StartRace()
		{
			m_StartTimer = 3;
			yield return new WaitForSeconds(1.5f);
			m_StartTimer--;
			yield return new WaitForSeconds(1);
			m_StartTimer--;
			yield return new WaitForSeconds(1);
			m_StartTimer--;
			m_StartRace = true;
		}

	}
}