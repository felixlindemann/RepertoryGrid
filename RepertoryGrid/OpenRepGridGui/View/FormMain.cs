using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenRepGridGui.Service;
using System.IO;
using OpenRepGridGui.View.mdi;

namespace OpenRepGridGui.mdi
{
    public partial class FormMain : Form
    {

        #region variables

        private RHelper.RHelper r;
        private ProjectService service;

        public ProjectService Service
        {
            get { return service; }
            set { service = value; }
        }

        #endregion

        public FormMain()
        {
            InitializeComponent();
            try
            {
                r = new RHelper.RHelper();
                this.r = new RHelper.RHelper();
                this.r.rExec += new RHelper.RExececutedEventHandler(R_rExec);
                this.r.AutoPrint = true;
                this.ucRConsole1.rEngine = this.r;


                service = new ProjectService(r);
                 
                this.projectBindingSource.DataSource = this.Service.CurrentProject;
                ToolStripMenuItem parent = loadDemosFromLiteratureincludedInOpenRepGridToolStripMenuItem;
                foreach (String key in service.DemoData.Keys)
                {
                    ToolStripMenuItem m = new ToolStripMenuItem(key);
                    m.ToolTipText = service.DemoData[key];
                    m.Tag = key;
                    m.Click += new EventHandler(Load_Demo_Button_Click);
                    parent.DropDownItems.Add(m);
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during init R-Instance -- Program terminates now.");
                Application.Exit();
                this.Close();
            }
        }

        #region Event handler


        private void R_rExec(RHelper.RExececutedEventArgs e)
        {
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}", e.RCmd);
            if (e.Output.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Result:\n{0}", e.Output);
            }

            Console.ForegroundColor = c;
        }


        void Load_Demo_Button_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem m = (ToolStripMenuItem)sender;
                this.service.AddInterview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while adding an interview");
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.projectBindingSource.EndEdit();

                if (this.service.HasChanges)
                {
                    DialogResult dlg = MessageBox.Show("The current project has unsaved changes. Should they be saved now?", "Confirm Saving", MessageBoxButtons.YesNoCancel);
                    if (dlg == System.Windows.Forms.DialogResult.OK)
                    {

                        throw new Exception("Please choose 'Save' from the menu.");
                    }
                    else if (dlg == System.Windows.Forms.DialogResult.Cancel)
                    {
                        throw new Exception("Aborted by user");
                    }
                }
                this.projectBindingSource.SuspendBinding();

                this.service = new ProjectService(r);
                this.projectBindingSource.ResumeBinding();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while creating new project");
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.projectBindingSource.EndEdit();

                if (this.service.HasChanges)
                {
                    DialogResult dlg = MessageBox.Show("The current project has unsaved changes. Should they be saved now?", "Confirm Saving", MessageBoxButtons.YesNoCancel);
                    if (dlg == System.Windows.Forms.DialogResult.OK)
                    {

                        throw new Exception("Please choose 'Save' from the menu.");
                    }
                    else if (dlg == System.Windows.Forms.DialogResult.Cancel)
                    {
                        throw new Exception("Aborted by user");
                    }
                }
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "XML-file (*.xml)|*.xml";
                opf.Title = "Please choose project file to be loaded";
                opf.Multiselect = false;
                if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.projectBindingSource.SuspendBinding();
                    ;
                    this.service = new ProjectService(r);
                    this.service.ImportFelixLindemann(new FileInfo(opf.FileName));
                    this.projectBindingSource.ResumeBinding();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while loading a project");
            }
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.projectBindingSource.EndEdit();

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XML-file (*.xml)|*.xml";
                sfd.Title = "Please choose project file to be loaded";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.service.Save(new FileInfo(sfd.FileName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while saving a project");
            }

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {

                this.projectBindingSource.EndEdit();

                if (this.MdiChildren.Any(x => x.GetType() == typeof(FormProperties)))
                {
                    Form frm = this.MdiChildren.Single(x => x.GetType() == typeof(FormProperties));
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                }
                else
                {
                    FormProperties frm = new FormProperties();
                    frm.Service = this.Service;
                    frm.MdiParent = this;
                    frm.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while modifing preferences");
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.projectBindingSource.EndEdit();

                if (this.service.HasChanges)
                {
                    DialogResult dlg = MessageBox.Show("The current project has unsaved changes. Should they be saved now?", "Confirm Saving", MessageBoxButtons.YesNoCancel);
                    if (dlg == System.Windows.Forms.DialogResult.OK)
                    {

                        throw new Exception("Please choose 'Save' from the menu.");
                    }
                    else if (dlg == System.Windows.Forms.DialogResult.Cancel)
                    {
                        throw new Exception("Aborted by user");
                    }
                }
                this.service.Dispose();
                r.Dispose();
                GC.Collect();
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while quitting the application");
            }

        }

        private void addInterviewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                this.service.AddInterview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while adding an interview");
            }
        }

        private void importGridStatToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "dat-file (*.dat)|*.dat";
                opf.Title = "Please choose a GridStat file to be imported";
                opf.Multiselect = false;
                if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.projectBindingSource.SuspendBinding();
                    ;

                    this.service.ImportGridStat(new FileInfo(opf.FileName), "GridStat");
                    this.projectBindingSource.ResumeBinding();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while importing an interview of type GridStat");
            }
        }

        private void importGridCorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "dat-file (*.dat)|*.dat";
                opf.Title = "Please choose a GridCor file to be imported";
                opf.Multiselect = false;
                if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.projectBindingSource.SuspendBinding();
                    ;

                    this.service.ImportGridStat(new FileInfo(opf.FileName), "GridCor");
                    this.projectBindingSource.ResumeBinding();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while importing an interview of type GridCor");
            }
        }

        private void importGridSuiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "xml-file (*.xml)|*.xml";
                opf.Title = "Please choose a GridCor file to be imported";
                opf.Multiselect = false;
                if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.projectBindingSource.SuspendBinding();
                    ;

                    this.service.ImportGridStat(new FileInfo(opf.FileName), "GridSuite");
                    this.projectBindingSource.ResumeBinding();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while importing an interview of type GridSuite");
            }

        }

        private void importScivescoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "scires-file (*.scires)|*.scires";
                opf.Title = "Please choose a sci:vesco file to be imported";
                opf.Multiselect = false;
                if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.projectBindingSource.SuspendBinding();
                    ;

                    this.service.ImportGridStat(new FileInfo(opf.FileName), "SciVesco");
                    this.projectBindingSource.ResumeBinding();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while importing an interview of type Scivesco");
            }
        }

        private void getRandomGridToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                this.service.addRandomGrid("RandomGrid");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while importing a random grid into the project");
            }
        }

        private void showHideRConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem m = (ToolStripMenuItem)sender;
            this.splitter1.Visible = m.Checked;
            this.ucRConsole1.Visible = m.Checked;
        }

        private void casadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form mdi in this.MdiChildren)
                {
                    //  mdi.
                    mdi.WindowState = FormWindowState.Minimized;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error while minimizing all MDI-windows.");

            }
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form mdi in this.MdiChildren)
                {
                    mdi.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error while closing all MDI-windows.");
            }
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);

        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
        }

        private void ProjectDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.service.HasChanges)
                {
                    DialogResult dlg = MessageBox.Show("The current project has unsaved changes. Should they be saved now?", "Confirm Saving", MessageBoxButtons.YesNoCancel);
                    if (dlg == System.Windows.Forms.DialogResult.OK)
                    {
                        throw new Exception("Please choose 'Save' from the menu.");
                    }
                    else if (dlg == System.Windows.Forms.DialogResult.Cancel)
                    {
                        throw new Exception("Aborted by user");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error while closing application.");
                e.Cancel = true;
            }
        }



        private void editDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.MdiChildren.Any(x => x.GetType() == typeof(ProjectSetup)))
                {
                    Form frm = this.MdiChildren.Single(x => x.GetType() == typeof(ProjectSetup));
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                }
                else
                {
                    ProjectSetup frm = new ProjectSetup();
                    frm.Service = this.Service;
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error while Opening Edit Window.");

            }
        }

        #endregion

    }
}
