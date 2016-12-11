using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Lexn.UI.ViewModel;

namespace Lexn.UI
{
    public partial class PopupForm : Form
    {
        public PopupForm()
        {
            InitializeComponent();
        }


        public void InitLexemsGrid(List<LexemViewModel> lexems)
        {

            gridLexems.AutoGenerateColumns = false;

            //create the column programatically
            var cell = new DataGridViewTextBoxCell();
            gridLexems.Columns.Add(new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                Name = "LexemID",
                HeaderText = "Lexem ID",
                Width = 210,
                DataPropertyName = "LexemID",
            });

            gridLexems.Columns.Add(new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                Name = "Line",
                HeaderText = "Line",
                DataPropertyName = "Line" // Tell the column which property of FileName it should use
            });

            gridLexems.Columns.Add(new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                Name = "Name",
                HeaderText = "Name",
                DataPropertyName = "Name" // Tell the column which property of FileName it should use
            });

            gridLexems.Columns.Add(new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                Name = "Type",
                HeaderText = "Type",
                DataPropertyName = "Type" // Tell the column which property of FileName it should use
            });

            var filenamesList = new BindingList<LexemViewModel>(lexems); // <-- BindingList

            //Bind BindingList directly to the DataGrid, no need of BindingSource
            gridLexems.DataSource = filenamesList;
        }

        public void InitErrorGrid(List<AnalyzeErrorViewModel> errors)
        {
            gridLexems.AutoGenerateColumns = false;

            //create the column programatically
            var cell = new DataGridViewTextBoxCell();
            gridLexems.Columns.Add(new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                Name = "Code",
                HeaderText = "Code",
                Width = 210,
                DataPropertyName = "Code",
            });

            gridLexems.Columns.Add(new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                Name = "Line",
                HeaderText = "Line",
                DataPropertyName = "Line" // Tell the column which property of FileName it should use
            });

            gridLexems.Columns.Add(new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                Name = "Message",
                HeaderText = "Message",
                Width = 210,
                DataPropertyName = "Message" // Tell the column which property of FileName it should use
            });

            var filenamesList = new BindingList<AnalyzeErrorViewModel>(errors); // <-- BindingList

            //Bind BindingList directly to the DataGrid, no need of BindingSource
            gridLexems.DataSource = filenamesList;
        }
    }
}
