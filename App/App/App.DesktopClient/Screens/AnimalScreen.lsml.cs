using Microsoft.LightSwitch.Presentation.Extensions;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.IO;
using System.Linq;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Microsoft.LightSwitch.Presentation.Implementation.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace LightSwitchApplication
{
    public partial class AnimalScreen
    {
        partial void AnimalScreen_Created()
        {


            this.FindControl("AnimalGrid").ControlAvailable += AnimalScreen_ControlAvailable;

        }

        private void AnimalScreen_ControlAvailable(object sender, ControlAvailableEventArgs e)
        {
            var dataGrid = e.Control as BaseDataGridControl;
            if (dataGrid == null) return;

            //create the new column for the header
            var col = new DataGridTemplateColumn();

            //get the header of the exising header, 
            //the datagrid uses  Microsoft.LightSwitch.Presentation.Implementation.Controls.DataGridContentItemColumn
            //and the cosmopolitan them is coupled with this class, furthermore this DataGridContentItemColumn is protected
            //making it un-available outside the lightswitch
            //so what we going to do as a hack and simplicity here is get the existing column
            col.Header = dataGrid.Columns[0].Header;

            //and set it's displa name
            (((ContentItemWrapperForColumnHeader)(col.Header)).ContentItem).DisplayName = "Is Selected";

            //this is your normal template for adding checkbox and inserting it to grid
            const string xaml =
                   @"<DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
                    <CheckBox />
                    </DataTemplate>";
            

            var dataTemplate = XamlReader.Load(xaml) as DataTemplate;
            col.CellTemplate = dataTemplate;
           

            dataGrid.Columns.Insert(0, col);
            

        }
    }
}