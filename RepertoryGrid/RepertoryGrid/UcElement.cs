using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace RepertoryGrid
{
    public partial class UcElement : UserControl
    {
        public event DeletingEventHandler deletingEventHandler; 
        protected virtual void OnThresholdReached(DeletingEventArgs e)
        {
            DeletingEventHandler handler = deletingEventHandler;
            if (handler != null)
            {
                handler(e);
            }
        }

        public UcElement()
        {
            InitializeComponent();
        }

        private void buttonDeleteElement_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                Guid id = (Guid)btn.Tag;
                OnThresholdReached(new DeletingEventArgs(id)); 
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }
    
    }
}
