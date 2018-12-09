using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 光照强度显示
/// </summary>
public class LIGHT : MonoBehaviour {
	public static int m_light = 0;
    #region 定义的字段属性
    /// <summary>
    /// 定义显示光照强度的文本组件
    /// </summary>
    private Text text;

    /// <summary>
    /// 计时器
    /// </summary>
    private float timer = 0f;

    /// <summary>
    /// 无连接是显示的内容
    /// </summary>

    #endregion

    #region Unity回调方法
    private void Start()
    {
        text = this.GetComponent<Text>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
		text.text = m_light.ToString();

    }
    #endregion

    #region 方法
    /// <summary>
    /// 无连接的时候显示虚拟数据
    /// </summary>
    void SetValues()
    {
        m_light = Random.Range(0, 30);
        text.text = m_light.ToString();
    }
    #endregion
}
