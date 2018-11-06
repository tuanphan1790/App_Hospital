using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BVPS.DB;
using BVPS.Model.UserPermissionInfor;
using DevComponents.AdvTree;
using DevComponents.DotNetBar.SuperGrid;
using BVPS.App;

namespace Com.Gosol.LIS.App.FORM
{
    public partial class UserPermission : UserControl
    {
        UserInforDB userDB;
        string userNameLogin;

        public UserPermission(UserInforDB userDB, string userNameLogin)
        {
            this.userDB = userDB;
            this.userNameLogin = userNameLogin;

            InitializeComponent();
            FillDataToForm();
        }

        NguoiSuDung nsd;

        private void FillDataToForm()
        {
            advTreeNSD.Nodes.Clear();

            nsd = userDB.GetUserInfor(userNameLogin);
            if (nsd.IsAdmin) // UserAdmin
            {
                List<NguoiSuDung> listNSDs = userDB.GetListUserInfors();
                foreach (var u in listNSDs)
                {
                    Node parrent = CreateUser(u);
                    advTreeNSD.Nodes.Add(parrent);
                    advTreeNSD.ExpandAll();
                }
            }
            else // User normal
            {
                Node parrent = CreateUser(nsd);
                advTreeNSD.Nodes.Add(parrent);
                advTreeNSD.ExpandAll();
            }
        }

        private Node CreateUser(NguoiSuDung info)
        {
            Node node = new Node(info.UserName);
            node.Cells.Add(new Cell(info.FullName));
            node.Tag = info;
            return node;
        }

        public void InitPermission(string userName)
        {
            GridPanel panel = sgdmPermission.PrimaryGrid;
            panel.Rows.Clear();
            sgdmPermission.BeginUpdate();

            List<PhanQuyen> listPermissions = userDB.GetPermissionByUser(userName);

            foreach (var fun in userDB.GetListFunctions())
            {
                bool isPermission = true;
                foreach (var per in listPermissions)
                {
                    if (per.FunctionID == fun.Id)
                    {
                        bool x = per.Delete();
                        object[] ob1 = new object[]
                            {
                                fun.Id, fun.FunctionName, per.View(), per.Add(),  per.Edit(), per.Delete()
                            };

                        panel.Rows.Add(new GridRow(ob1));
                        isPermission = false;
                        break;
                    }
                }

                if (isPermission)
                {
                    object[] ob1 = new object[]
                            {
                                fun.Id, fun.FunctionName, false, false, false, false
                            };

                    panel.Rows.Add(new GridRow(ob1));
                }
            }

            sgdmPermission.EndUpdate();
        }

        NguoiSuDung infoUserNow;
        private void advTreeNSD_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                infoUserNow = (NguoiSuDung)e.Node.Tag;
                InitPermission(infoUserNow.UserName);
            }
        }

        private void sgdmPermission_CellClick(object sender, GridCellClickEventArgs e)
        {
            if (nsd.IsAdmin)
            {
                int numberPermis = 0x0000;

                if (e.GridCell.GridRow["ID"].Value.ToString() != null)
                {
                    if (e.GridCell.GridRow["Xem"].Value.Equals(true))
                    {
                        numberPermis |= 0x0001;
                    }
                    if (e.GridCell.GridRow["ThemMoi"].Value.Equals(true))
                    {
                        numberPermis |= 0x0002;
                    }
                    if (e.GridCell.GridRow["Sua"].Value.Equals(true))
                    {
                        numberPermis |= 0x0004;
                    }
                    if (e.GridCell.GridRow["Xoa"].Value.Equals(true))
                    {
                        numberPermis |= 0x0008;
                    }
                }
                PhanQuyen pquyen = new PhanQuyen();
                int idFun = Convert.ToInt32(e.GridCell.GridRow["ID"].Value.ToString());
                userDB.EditPermissionForUser(infoUserNow.UserName, idFun, numberPermis);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền trong chức năng phân quyền!");
            }
        }

        private void ThemMoi_Click(object sender, EventArgs e)
        {
            UserInfo newUser = new UserInfo();
            if(newUser.ShowDialog() == DialogResult.OK)
            {
                NguoiSuDung nsd = new NguoiSuDung();
                nsd.FullName = newUser.FullName();
                nsd.UserName = newUser.UserLogon();
                nsd.Password = newUser.Password();
                nsd.Email = newUser.Email();
                nsd.SoDienThoai = newUser.Phone();
                nsd.NgaySinh = newUser.NgaySinh();
                nsd.GioiTinh = newUser.GioiTinh();
                nsd.DiaChi = newUser.DiaChi();
                nsd.ChucVu = newUser.ChucVu();

                string mes = "";
                bool check = userDB.AddNewUser(nsd, ref mes);
                if(!check)
                {
                    MessageBox.Show(mes);
                }

                Node parrent = CreateUser(nsd);
                advTreeNSD.Nodes.Add(parrent);
            }
        }

        private void XemChiTiet_Click(object sender, EventArgs e)
        {
            string nodeName = advTreeNSD.SelectedNode.FullPath;
            NguoiSuDung nsd = userDB.GetUserInfor(nodeName);
            UserInfo oldUser = new UserInfo(nsd);
            oldUser.ShowDialog();
        }
    }
}
