using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RepertoryGrid.Model;
using RepertoryGrid.Service;

namespace RepertoryGridGUI.UserControls
{
    public partial class UcElement : UserControl
    {


        #region Variables
        private Element element;
        private InterviewService interviewService;

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

        public Element CurrentElement
        {
            get { return element; }
            set
            {
                element = value;
                this.elementBindingSource.DataSource = this.CurrentElement;
                this.buttonMoveLeft.Enabled = this.ShowMoveUpButton;
                this.buttonMoveRight.Enabled = this.ShowMoveDownButton;
            }
        }

        public int Index
        {
            get
            {
                return this.CurrentInterviewService
                            .CurrentInterview.Elements.IndexOf(this.CurrentElement);

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
                return (this.Index < this.CurrentInterviewService.CurrentInterview.Elements.Count - 1);
            }
        }

        #endregion


        public UcElement()
        {
            InitializeComponent();
        }

        private void buttonDeleteElement_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (MessageBox.Show("Do you REALLY want to DELETE this element?", 
                    "Confirm Deleting", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        throw new OperationCanceledException();
                this.CurrentInterviewService.DeleteElement(this.CurrentElement);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during Deleting an Element");
            }
        }

        private void buttonMoveRight_Click(object sender, EventArgs e)
        {
            try
            {

                int index = this.CurrentInterviewService
                    .CurrentInterview.Elements.IndexOf(this.CurrentElement);

                this.CurrentInterviewService.MoveRight(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during Moving an Element to the right");
            }
        }

        private void buttonMoveLeft_Click(object sender, EventArgs e)
        {
            try
            {

                int index = this.CurrentInterviewService
                    .CurrentInterview.Elements.IndexOf(this.CurrentElement);

                this.CurrentInterviewService.MoveLeft(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error during Moving an Element to the left.");
            }
        }
    }
}
