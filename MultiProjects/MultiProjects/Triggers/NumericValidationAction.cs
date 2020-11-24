using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MultiProjects.Triggers
{
    //Anything you can do with a trigger you can also do with a behavior.
    //but behavior involves more code and flexibility
    public class NumericValidationAction : TriggerAction<Entry> 
    {
        protected override void Invoke(Entry entry)
        {
            double result;
            bool isValid = Double.TryParse(entry.Text, out result);
            entry.TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
