using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using Lexn.Common;
using Lexn.Lexis;
using Lexn.Lexis.Model;
using Lexn.UI.ViewModel;

namespace Lexn.UI
{
    public partial class LexnForm : Form
    {
        private readonly IAnalyzer _lexisAnalyzer;
        private readonly IKeyWordsProvider _keyWordsProvider;
        private readonly Style _blueStyle;

        private List<LexemViewModel> _lexemViewModels;
        private List<AnalyzeErrorViewModel> _errorViewModels;

        public LexnForm()
        {
            InitializeComponent();
            _lexisAnalyzer = LexisFactory.CreateLexicalAnalyzer();
            _keyWordsProvider = LexisFactory.CreateKeyWordsProvider();
            _blueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Italic);
        }

        private void LexnForm_Load(object sender, EventArgs e)
        {
            txtCode.Text = BuildInitialProgram();
            btnViewIdentifiers.Visible = false;
            btnViewLexems.Visible = false;
            btnViewConstants.Visible = false;
            btnViewErrors.Visible = false;
        }

        private void btnLexicalAnalyze_Click(object sender, EventArgs e)
        {
            var analyzeResult = _lexisAnalyzer.Analyze(txtCode.Text) as LexicalAnalyzeResult;
            if (analyzeResult != null)
            {
                if (analyzeResult.IsValid)
                {
                    _lexemViewModels = analyzeResult.Lexems.Select(item => new LexemViewModel
                    {
                        LexemID = item.LexemID,
                        Line = item.Line,
                        Name = item.Name,
                        Type = item.Type.ToString()
                    }).ToList();
                    btnViewLexems.Visible = true;
                    btnViewErrors.Visible = false;
                }
                else
                {
                    _errorViewModels = analyzeResult.Errors.Select(item => new AnalyzeErrorViewModel
                    {
                        Code = item.Code.ToString(),
                        Line = item.Line,
                        Message = item.Message
                    }).ToList();
                    btnViewLexems.Visible = false;
                    btnViewErrors.Visible = true;
                }
            }

        }

        private void btnViewLexems_Click(object sender, EventArgs e)
        {
            var form = new PopupForm();
            form.Show(this);
            form.InitLexemsGrid(_lexemViewModels);
        }

        private void btnViewIdentifiers_Click(object sender, EventArgs e)
        {

        }

        private void btnViewConstants_Click(object sender, EventArgs e)
        {

        }

        private void btnViewErrors_Click(object sender, EventArgs e)
        {
            var form = new PopupForm();
            form.Show(this);
            form.InitErrorGrid(_errorViewModels);
        }
 
        private void txtCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(_blueStyle);
            foreach (var keyWord in _keyWordsProvider.GetKeyWords())
            {
                e.ChangedRange.SetStyle(_blueStyle, keyWord, RegexOptions.Singleline);
            }
        }

        private string BuildInitialProgram()
        {
            var builder = new StringBuilder();
            builder.AppendLine("program MyProgram");
            builder.AppendLine("begin");
            builder.AppendLine("\twriteln \"Hello world\"");
            builder.AppendLine("end");
            return builder.ToString();
        }
    }
}
