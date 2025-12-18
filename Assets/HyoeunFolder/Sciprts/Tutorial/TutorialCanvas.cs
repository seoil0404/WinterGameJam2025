using UnityEngine;
using UnityEngine.UI;

public class TutorialCanvas : MonoBehaviour
{
    [SerializeField] private TutorialScript m_script;
	[SerializeField] private Image m_questImage;
    [SerializeField] private Image m_scriptImage;
	private Text m_questText;
	private Text m_scriptText;

	private int m_leftScriptCount;

	public void SetTutorial(TutorialScript pScript)
    {
		m_questImage.gameObject.SetActive(false);
		m_scriptImage.gameObject.SetActive(true);
        m_script = pScript;
		m_leftScriptCount = 0;
		m_scriptText = m_scriptImage.GetComponentInChildren<Text>();
		m_questText = m_questImage.GetComponentInChildren<Text>();
		NextPage();
    }

	public void NextPage()
	{
		if (m_leftScriptCount < m_script.Scripts.Length)
		{
			m_scriptText.text = m_script.Scripts[m_leftScriptCount];
			m_leftScriptCount++;
		}
		else
		{
			if(m_script.Quest != null)
			{
				m_questText.text = m_script.Quest;
				m_questImage.gameObject.SetActive(true);
			}
			this.gameObject.SetActive(false);

			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = true;
			Time.timeScale = 1;
		}
	}
}
