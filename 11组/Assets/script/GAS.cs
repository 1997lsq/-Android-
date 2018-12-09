using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 可燃气浓度显示
/// </summary>
public class GAS : MonoBehaviour {
	public static int gas = 0;
    #region 定义的字段属性
    /// <summary>
    /// 可燃气浓度的显示文本组件
    /// </summary>
    private Text text;

    /// <summary>
    /// 计时器
    /// </summary>
    float timer = 0f;

    /// <summary>
    /// 无连接时显示的内容
    /// </summary>
    
    #endregion

    #region Unity回调方法
    private void Start()
    {
        // 初始化文本组件
        text = this.GetComponent<Text>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
		/*if(gas == 1)
			text.text="on";
		else
			text.text="off";*/
		text.text = gas.ToString();
    }
    #endregion

    #region 方法
    /// <summary>
    /// 无连接的时候显示虚拟数据
    /// </summary>
    void SetValues()
    {
        gas = Random.Range(0, 20);
        text.text = gas.ToString();
    }
    #endregion
}
