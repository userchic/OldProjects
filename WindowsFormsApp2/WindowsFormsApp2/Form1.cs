using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        string cs =
            @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Students; Integrated Security=true;";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            using (var cn = new SqlConnection(cs))
            {
                cn.Open();
                var sql = @"select * from Faculteti";
                var cmd = new SqlCommand(sql,cn);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TreeNode n = new TreeNode(dr["Name"].ToString(),0,0);
                    n.Tag = dr["id"];
                    treeView1.Nodes.Add(n);
                    LoadGroups((int)dr["id"],n);
                }
            }
        }

        void LoadGroups(int groupId, TreeNode parent)
        {
            using (var cn = new SqlConnection(cs))
            {
                cn.Open();
                var sql = @"select G.Name as Name,id
                                from Groups G
                                where G.FacultyId=@FacultyId";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@FacultyId", groupId);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TreeNode n = new TreeNode(dr["Name"].ToString(), 0, 0);
                    n.Tag = dr["id"];
                    parent.Nodes.Add(n);
                    LoadStudents((int)dr["id"], n);
                }
            }
        }
        void LoadStudents(int groupId, TreeNode parent)
        {
            using (var cn = new SqlConnection(cs))
            {
                cn.Open();
                var sql = @"select S.Name as Name,S.Surname as Surname ,id
                                from Students S
                                where S.GroupId=@GroupId";
                var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@GroupId", groupId);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TreeNode n = new TreeNode(dr["Name"].ToString()+" "+dr["Surname"].ToString(), 1, 1);
                    n.Tag = dr["id"];
                    parent.Nodes.Add(n);
                }
                
            }
        }
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Level == 2)
            {
                using (var cn = new SqlConnection(cs))
                {
                    cn.Open();
                    var sql = @"delete from Students where id=@Id";
                    var cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@Id", treeView1.SelectedNode.Tag);
                    cmd.ExecuteNonQuery();
                    treeView1.SelectedNode.Remove();
                }
            }
            else
            if (treeView1.SelectedNode!=null && treeView1.SelectedNode.Level==1)
            {
                using (var cn = new SqlConnection(cs))
                {
                    cn.Open();
                    var sql = @"delete from Groups where id=@Id";
                    var cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@Id", treeView1.SelectedNode.Tag);
                    cmd.ExecuteNonQuery();
                    treeView1.SelectedNode.Remove();
                }
            }
            else
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Level == 0)
            {
                using (var cn = new SqlConnection(cs))
                {
                    cn.Open();
                    var sql = @"delete from Faculteti where id=@Id";
                    var cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@Id", treeView1.SelectedNode.Tag);
                    cmd.ExecuteNonQuery();
                    treeView1.SelectedNode.Remove();
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                удалитьToolStripMenuItem.Enabled = true;
                изменитьToolStripMenuItem.Enabled = true;
                if (treeView1.SelectedNode.Level < 2)
                    добавитьToolStripMenuItem1.Enabled = true;
                else
                    добавитьToolStripMenuItem1.Enabled = false;
                if (treeView1.SelectedNode.Level == 0)
                    добавитьToolStripMenuItem1.Text = "Добавить в факультет";
                if (treeView1.SelectedNode.Level == 1)
                    добавитьToolStripMenuItem1.Text = "Добавить в группу";
            }
            else
            {
                удалитьToolStripMenuItem.Enabled = false;
                добавитьToolStripMenuItem1.Enabled = false;
                изменитьToolStripMenuItem.Enabled = false;
            }
        }
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            using (var cn = new SqlConnection(cs))
            {
                cn.Open();
                FormAdd1 form = new FormAdd1();
                form.Name = "Добавление факультета";
                form.Label = "Название факультета";
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    string name = form.Label;
                    var sql = $@"Insert Into Faculteti 
                                    (Name) 
                            Values 
                                    ('{name}')
                            SELECT id from Faculteti
                                where id=SCOPE_IDENTITY()";
                    var cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    var cmd1 = new SqlCommand(sql, cn);
                    var dr = cmd1.ExecuteReader();
                    TreeNode n = new TreeNode(name, 0, 0);
                    dr.Read();
                    n.Tag = dr["id"];
                    treeView1.Nodes.Add(n);
                }
            }
        }
            catch {
                MessageBox.Show("Вы что-то не то наделали", "Варнинг",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode != null && treeView1.SelectedNode.Level == 0)
            {
                using (var cn = new SqlConnection(cs))
                {
                    cn.Open();
                    FormAdd1 form = new FormAdd1();
                    form.Name = "Добавление в факультет";
                    form.Label = "Название группы";
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        string name = form.Label;
                        var sql = $@"Insert Into Groups
                                    (Name,FacultyId) 
                            Values 
                                    ('{name}',{treeView1.SelectedNode.Tag})
                            SELECT id from Groups
                                where id=SCOPE_IDENTITY()";
                        var cmd = new SqlCommand(sql, cn);
                        cmd.Parameters.AddWithValue("@Name", name);
                        var cmd1 = new SqlCommand(sql, cn);
                        var dr = cmd1.ExecuteReader();
                        TreeNode n = new TreeNode(name, 0, 0);
                        dr.Read();
                        n.Tag = dr["id"];
                        treeView1.SelectedNode.Nodes.Add(n);
                    }
                }
            }
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Level == 1)
            {
                using (var cn = new SqlConnection(cs))
                {
                    cn.Open();
                    FormAdd2 form = new FormAdd2();
                    form.Name = "Добавление в Группу";
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        string name = form.Studnam + " " + form.Surname;
                        var sql = $@"Insert Into Students
                                    (Name,Surname,GroupId) 
                            Values 
                                    ('{form.Studnam}','{form.Surname}',{treeView1.SelectedNode.Tag})
                            SELECT id from Students
                                where id=SCOPE_IDENTITY()";
                        var cmd = new SqlCommand(sql, cn);
                        cmd.Parameters.AddWithValue("@Name", form.Studnam);
                        cmd.Parameters.AddWithValue("@Surname", form.Surname);
                        var cmd1 = new SqlCommand(sql, cn);
                        var dr = cmd1.ExecuteReader();
                        TreeNode n = new TreeNode(name, 0, 0);
                        dr.Read();
                        n.Tag = dr["id"];
                        treeView1.SelectedNode.Nodes.Add(n);
                    }
                }
            }
            }
            catch {
                MessageBox.Show("Вы что-то не то наделали", "Варнинг",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode != null && treeView1.SelectedNode.Level == 0)
                {
                    using (var cn = new SqlConnection(cs))
                    {
                        FormChange1 form = new FormChange1();
                        form.Label = "Изменение факультета";
                        form.Name = treeView1.SelectedNode.Text;
                        form.ShowDialog();
                        if (form.DialogResult == DialogResult.OK)
                        {
                            string name = form.Label;
                            cn.Open();
                            var sql = $@"update Faculteti
                                set Name='{name}' where id={treeView1.SelectedNode.Tag}";
                            var cmd = new SqlCommand(sql, cn);
                            cmd.Parameters.AddWithValue("@Name", treeView1.SelectedNode.Text);
                            cmd.ExecuteNonQuery();
                            treeView1.SelectedNode.Text = name;
                        }
                    }
                }
                if (treeView1.SelectedNode != null && treeView1.SelectedNode.Level == 1)
                {
                    using (var cn = new SqlConnection(cs))
                    {
                        FormChange2 form = new FormChange2();
                        form.Label = "Изменение группы";
                        form.Name = treeView1.SelectedNode.Text;
                        form.ShowDialog();
                        if (form.DialogResult == DialogResult.OK)
                        {
                            string name = form.Label;
                            cn.Open();
                            var sql = $@"update Groups
                                set Name='{name}' where id={treeView1.SelectedNode.Tag}";
                            var cmd = new SqlCommand(sql, cn);
                            cmd.Parameters.AddWithValue("@Name", treeView1.SelectedNode.Text);
                            cmd.ExecuteNonQuery();
                            treeView1.SelectedNode.Text = name;
                        }
                    }
                }
                if (treeView1.SelectedNode != null && treeView1.SelectedNode.Level == 2)
                {
                    using (var cn = new SqlConnection(cs))
                    {
                        FormChange3 form = new FormChange3();
                        form.Label = treeView1.SelectedNode.Text;
                        form.Name = "Изменение Студента";
                        form.ShowDialog();
                        if (form.DialogResult == DialogResult.OK)
                        {
                            string name = form.Studnam + " " + form.Surname;
                            cn.Open();
                            var sql = $@"update Students
                                set Name='{form.Studnam}',Surname='{form.Surname}' where id={treeView1.SelectedNode.Tag}";
                            var cmd = new SqlCommand(sql, cn);
                            cmd.Parameters.AddWithValue("@Name", treeView1.SelectedNode.Text);
                            cmd.ExecuteNonQuery();
                            treeView1.SelectedNode.Text = name;
                        }
                    }
                }
            }
            catch {
                MessageBox.Show("Вы что-то не то наделали", "Варнинг",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
        }

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {

        }
    }
}

