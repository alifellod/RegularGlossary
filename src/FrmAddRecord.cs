using System;
using System.Text;
using System.Windows.Forms;

namespace RegularGlossary
{
    public partial class FrmAddRecord : Form
    {
        public FrmAddRecord()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtExplain.Text == "")
            {
                MessageBox.Show("请输入内容");
            }
            else
            {
                Dbcontrol dbHelper = new Dbcontrol();
                if (rdoSingle.Checked)
                {
                    string strEx = "insert into [sheet1$] (名称,解释) VALUES('" + txtName.Text.Trim() + "','" + txtExplain.Text.Trim() + "')";
                    MessageBox.Show(dbHelper.ReExNum(strEx) > 0 ? "添加成功！" : "添加失败！");
                }
                else
                {
                    string[] charSplit = { "\n" };
                    char entrySeparator = txtName.Text[0];
                    string[] entries = txtExplain.Text.Trim().Replace("\r", "").Split(charSplit, StringSplitOptions.None);
                    int succeedCount = 0;
                    foreach (var item in entries)
                    {
                        string[] data = item.Split(entrySeparator);
                        if (data.Length < 2)
                            continue;
                        succeedCount += dbHelper.ReExNum(string.Format("insert into [sheet1$] (名称,解释) VALUES('{0}','{1}');", data[0], data[1]));
                    }
                    MessageBox.Show("成功添加了【" + succeedCount + "】条记录。", "成功提示");
                }
                ClearForm();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        protected void ClearForm()
        {
            txtExplain.Text = "";
            txtName.Text = "";
        }

        private void rdoSingle_CheckedChanged(object sender, EventArgs e)
        {
            RdoChange();
        }
        protected void RdoChange()
        {
            if (rdoSingle.Checked)
            {
                lblName.Text = "名称：";
                lblName.Left += 10;
                lblExplain.Text = "解释：";
                ttMain.SetToolTip(txtName, "");
                ttMain.SetToolTip(txtExplain, "");
            }
            else
            {
                lblName.Text = "分割符：";
                lblExplain.Text = "记录：";
                lblName.Left -= 10;
                ttMain.SetToolTip(txtName, "名称与解释之间的分割符，比如\\d 数字，那么分割符是空格[ ]\n分割符仅提取输入的第一个字符。");
                ttMain.SetToolTip(txtExplain, "一行一条记录");
            }
        }
    }
}