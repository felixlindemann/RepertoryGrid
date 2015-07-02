using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepertoryGrid.Model;

namespace RepertoryGridGUI.EventHandler
{
    
    #region Construct

    public delegate void ConstructDeleteEventHandler(ConstructDeletedEventArgs e);
    public delegate void ReOrderedConstructEventHandler(ReOrderedConstructEventArgs e);

    public class ConstructDeletedEventArgs : EventArgs
    {

        public Construct DeletedConstruct { get; set; }
         
        public ConstructDeletedEventArgs(Construct construct)
        {
            this.DeletedConstruct = construct;
        }


    }
    public class ReOrderedConstructEventArgs : EventArgs
    {

        public Construct ReOrderedConstruct { get; set; }
         
        public ReOrderedConstructEventArgs(Construct construct)
        {
            this.ReOrderedConstruct = construct;
        }


    }
 
    #endregion

    #region Element

    public delegate void ElementDeleteEventHandler(ElementDeletedEventArgs e);
    public delegate void ReOrderedElementEventHandler(ReOrderedConstructEventArgs e);

    public class ElementDeletedEventArgs : EventArgs
    {

        public Element DeletedElement { get; set; }

        public ElementDeletedEventArgs(Element element)
        {
            this.DeletedElement = element;
        }


    }
    public class ReOrderedElementEventArgs : EventArgs
    {

        public Element ReOrderedElement { get; set; }
         
        public ReOrderedElementEventArgs(Element element)
        {
            this.ReOrderedElement = element;
        }


    }
   
    #endregion
    
 
#region PositionChanged 
    
    public delegate void ScoringScrollingPositionChangedEventHandler(ScoringScrollingPositionChangedEventArgs e);

    public class ScoringScrollingPositionChangedEventArgs : EventArgs
    {
         
        public int Position { get; set; }
        public ScoringScrollingPositionChangedEventArgs( int position)
        {
            this.Position = position;
        }


    }

    public delegate void ScoringPositionChangedEventHandler(ScoringPositionChangedEventArgs e);

    public class ScoringPositionChangedEventArgs : EventArgs
    {

        public Construct parentConstruct { get; set; }
        public Element parentElement { get; set; }
        public int Index { get; set; }
        public ScoringPositionChangedEventArgs(Element element, Construct construct, int index)
        {
            this.parentConstruct = construct;
            this.parentElement = element;
            this.Index = index;
        }


    }

#endregion

}
