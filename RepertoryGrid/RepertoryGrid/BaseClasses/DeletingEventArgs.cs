using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepertoryGrid
{
    public delegate void DeletingEventHandler(DeletingEventArgs e);

   public class DeletingEventArgs:EventArgs
    {
        private Guid id; 
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public DeletingEventArgs(Guid guid)
        {
            this.Id = guid;
        }
        
       
    }
}
