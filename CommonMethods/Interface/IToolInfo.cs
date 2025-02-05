using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonMethods
{
    [Serializable]
    public class IToolInfo
    {
        /// <summary>
        /// 工具是否启用
        /// </summary>
        public bool enable { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string toolName { get; set; }
        /// <summary>
        /// 工具类型
        /// </summary>
        public ToolType toolType { get; set; }
        /// <summary>
        /// 工具对象
        /// </summary>
        public object tool { get; set; }
        /// <summary>
        /// 工具窗体,由于无法对Form进行序列化，所以作为静态变量
        /// </summary>
        [NonSerialized]
        public Form FormTool = new Form();
        /// <summary>
        /// 工具窗体名
        /// </summary>
        public string FormToolName { get; set; }
        /// <summary>
        /// 工具描述信息
        /// </summary>
        public string toolTipInfo { get; set; }
        /// <summary>
        /// 工具输入字典集合
        /// </summary>
        public List<ToolIO> toolInput { get; set; }
        /// <summary>
        /// 工具输出字典集合
        /// </summary>
        public List<ToolIO> toolOutput { get; set; }
        /// <summary>
        /// 工具作用描述
        /// </summary>
        public string toolDescription { get; set; }
        /// <summary>
        /// 工具运行结果
        /// </summary>
        public ToolRunStatu toolRunStatu { get; set; }
        /// <summary>
        /// 绑定的JOB名称
        /// </summary>
        public string bingingJobName { get; set; }
        public IToolInfo()
        {
            enable = true;
            toolType = ToolType.None;
            toolName = string.Empty;
            bingingJobName = string.Empty;
            tool = new object();
            toolInput = new List<ToolIO>();
            toolOutput = new List<ToolIO>();
        }

        /// <summary>
        /// 以IO名获取IO对象
        /// </summary>
        /// <param name="IOName"></param>
        /// <returns></returns>
        public ToolIO GetInput(string IOName)
        {
            for (int i = 0; i < toolInput.Count; i++)
            {
                if (toolInput[i].IOName == IOName)
                    return toolInput[i];
            }
            return new ToolIO();
        }
        /// <summary>
        /// 以IO名获取IO对象
        /// </summary>
        /// <param name="IOName"></param>
        /// <returns></returns>
        public ToolIO GetOutput(string IOName)
        {
            for (int i = 0; i < toolOutput.Count; i++)
            {
                if (toolOutput[i].IOName == IOName)
                    return toolOutput[i];
            }
            return new ToolIO();
        }

        /// <summary>
        /// 移除工具输入项
        /// </summary>
        /// <param name="IOName"></param>
        public void RemoveInputIO(string IOName)
        {
            for (int i = 0; i < toolInput.Count; i++)
            {
                if (toolInput[i].IOName == toolName)
                    toolInput.RemoveAt(i);
            }
        }
        /// <summary>
        /// 移除工具输出项
        /// </summary>
        /// <param name="IOName"></param>
        public void RemoveOutputIO(string IOName)
        {
            for (int i = 0; i < toolOutput.Count; i++)
            {
                if (toolOutput[i].IOName == toolName)
                    toolOutput.RemoveAt(i);
            }
        }
        

        public Form GetFormTool()
        {
            return FormTool;
        }

        public void SetFormTool(Form myForm)
        {
            FormTool = myForm;
        }
    }

    /// <summary>
    /// 工具的输入输出类
    /// </summary>
    [Serializable]
    public class ToolIO
    {

        public string IOName;
        public object value;
        public DataType ioType;

        public ToolIO() { }
        public ToolIO(string IOName1, object value1, DataType ioType1)
        {
            this.IOName = IOName1;
            this.value = value1;
            this.ioType = ioType1;
        }

    }
}
