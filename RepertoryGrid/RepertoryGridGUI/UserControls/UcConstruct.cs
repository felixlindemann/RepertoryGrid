using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics; 
using RepertoryGrid.Service;
using RepertoryGrid.Model;
using RepertoryGridGUI.EventHandler;

namespace RepertoryGridGUI.UserControls
{
    public partial class UcConstruct : UserControl
    {

        #region Variables
         
        private InterviewService interviewService;
        private Construct construct;

        #endregion

        #region Properties

        public InterviewService CurrentInterviewService
        {
            get { return interviewService; }
            set
            {
                interviewService = value;
                if (value == null)
                {
                    return;
                } 
            }
        }

        public Construct CurrentConstruct
        {
            get { return construct; }
            set
            {
                construct = value;
                if (value == null)
                {
                    return;
                }
                this.constructBindingSource.DataSource = this.CurrentConstruct;
                this.buttonMoveUp.Enabled =  this.ShowMoveUpButton;
                this.buttonMoveDown.Enabled = this.ShowMoveDownButton;
            }
        }

        public int Index
        {
            get
            {
              return  this.CurrentInterviewService
                          .CurrentInterview.Constructs.IndexOf(this.CurrentConstruct);
                
            }

        }

        public Boolean ShowMoveUpButton
        {
            get
            {
                return (this.Index > 0); 
            }
        }
        public Boolean ShowMoveDownButton
        {
            get
            {
                return (this.Index < this.CurrentInterviewService.CurrentInterview.Constructs.Count - 1);
            }
        }

        #endregion

        #region Constructor

        public UcConstruct()
        {
            InitializeComponent();
        }

        #endregion
          
        #region Event Handler

        /// <summary>
        /// Event for communicating results of executed commands
        /// </summary>

        public event ReOrderedConstructEventHandler reOrderedConstructEventHandler;
        protected virtual void ReOrderedConstruct(ReOrderedConstructEventArgs e)
        {
            ReOrderedConstructEventHandler handler = reOrderedConstructEventHandler;
            if (handler != null)
            {
                handler(e);
            }
        }

        public event ConstructDeleteEventHandler constructDeleteEventHandler;
        protected virtual void ConstructDeleted(ConstructDeletedEventArgs e)
        {
            ConstructDeleteEventHandler handler = constructDeleteEventHandler;
            if (handler != null)
            {
                handler(e);
            }
        }
          
        private void buttonDeleteConstruct_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (MessageBox.Show("Do you REALLY want to DELETE this construct?", "Confirm Deleting", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    throw new OperationCanceledException();
                this.CurrentInterviewService.DeleteConstruct(this.CurrentConstruct);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during deleting a Construct");
            }
        }
         
        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            try
            {
                int index = this.Index;
                this.CurrentInterviewService.MoveUp(index);
                this.ReOrderedConstruct(new ReOrderedConstructEventArgs(this.CurrentConstruct));
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(ex.Message, "Error during Moving a Construct Up");
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            try
            {

                int index = this.CurrentInterviewService
                    .CurrentInterview.Constructs.IndexOf(this.CurrentConstruct);
                this.CurrentInterviewService.MoveDown(index);
                this.ReOrderedConstruct(new ReOrderedConstructEventArgs(this.CurrentConstruct));
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
                MessageBox.Show(ex.Message, "Error during Moving a Construct Down");
            }
        }

        #endregion
         
    }
}
