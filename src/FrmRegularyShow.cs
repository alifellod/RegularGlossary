using System;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace RegularGlossary
{
    public partial class FrmRegularyShow : Form
    {
        private FrmAddRecord _formAddRecord;
        private FrmAbout _formAbout;
        readonly Dbcontrol _dbc01 = new Dbcontrol();

        public FrmRegularyShow()
        {
            InitializeComponent();
        }

        private void lsbSearchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = lsbSearchName.Text.Trim();
            if (name == "System.Data.DataRowView")
                return;
            if (string.IsNullOrEmpty(name))
            {
                txtExplain.Text = "错误：选择的字符值为空白";
                return;
            }
            string excelSqlStr = "select 解释,名称 from [sheet1$] where 名称 ='" + name + "'";
            DataTable dtb = _dbc01.ReSelectdtb(excelSqlStr);
            if (dtb.Rows.Count > 0)
            {
                txtExplain.Text = dtb.Rows[0][0].ToString();
            }
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            string excelSqlStr;
            if (ckbSearchType.Checked)
            {
                excelSqlStr = "select 解释,名称 from [sheet1$] where 名称 like'%" + txtSearchName.Text + "%'";
            }
            else
            {
                excelSqlStr = "select 解释,名称 from [sheet1$] where 解释 like'%" + txtSearchName.Text + "%'";
            }

            DataTable dtb = _dbc01.ReSelectdtb(excelSqlStr);
            if (dtb.Rows.Count == 1)
            {
                txtExplain.Text = dtb.Rows[0][0].ToString();
                lsbSearchName.Text = dtb.Rows[0][1].ToString();
            }
            else
            {
                if (dtb.Rows.Count > 1)
                {
                    lsbSearchName.DataSource = dtb;
                    lsbSearchName.DisplayMember = "名称";
                    txtExplain.Text = dtb.Rows[0][0].ToString();
                    lsbSearchName.Text = dtb.Rows[0][1].ToString();
                }
            }
        }

        private void RegularyShow_Load(object sender, EventArgs e)
        {
            LoadDefault();

        }
        protected void LoadDefault()
        {
            DataTable dtb = _dbc01.ReSelectdtb("select 名称 from [sheet1$] where 名称 <>'' and 名称 is not null");
            lsbSearchName.DisplayMember = "名称";
            lsbSearchName.DataSource = dtb;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_formAddRecord == null || _formAddRecord.IsDisposed)
                _formAddRecord = new FrmAddRecord();
            _formAddRecord.ShowDialog();
            LoadDefault();
        }

        private void btnBind_Click(object sender, EventArgs e)
        {
            LoadDefault();
        }

        private void ckbSetWindowPos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSetWindowPos.Checked)
            {
                int hwnd = FindWindow(null, "RegularGlossary");
                SetWindowPos(hwnd, -1, 0, 0, 0, 0, 0x001 | 0x002 | 0x040);
            }
            else
            {
                int hwnd = FindWindow(null, "RegularGlossary");
                SetWindowPos(hwnd, -2, 0, 0, 0, 0, 0x001 | 0x002 | 0x040);
            }
        }
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern int SetWindowPos(
        int hwnd,
        int hWndInsertAfter,
        int x,
        int y,
        int cx,
        int cy,
        int wFlags
        );
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(
        string lpClassName,
        string lpWindowName
        );

        private void lblAbout_Click(object sender, EventArgs e)
        {
            if (_formAbout == null || _formAbout.IsDisposed)
                _formAbout = new FrmAbout();
            _formAbout.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = lsbSearchName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("选择的字符值为空白");
                return;
            }
            //UPDATE sheet1$ SET NAME = NULL, DeptName= NULL WHERE DeptId = 1;
            string excelSqlStr = "UPDATE [sheet1$] set 名称='',解释='' where 名称 ='" + name + "'";
            if (_dbc01.ReExNum(excelSqlStr) > 0)
            {
                LoadDefault();
            }
            else
            {
                MessageBox.Show("删除失败");
                UpdateStatusMessage("删除失败");
            }
        }

        private void UpdateStatusMessage(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => UpdateStatusMessage(msg)));
            }
            else
            {
                tsslblMessage.Text = msg;
            }
        }
    }

}