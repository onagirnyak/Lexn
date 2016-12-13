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
using Lexn.Syntax;
using Lexn.Syntax.Model;
using Lexn.UI.ViewModel;

namespace Lexn.UI
{
    public partial class LexnForm : Form
    {
        private readonly IAnalyzer _lexicalAnalyzer;
        private readonly IAnalyzer _syntaxAnalyzer;
        private readonly IKeyWordsProvider _keyWordsProvider;
        private readonly Style _blueStyle;

        private readonly List<LexemViewModel> _lexemViewModels;
        private readonly List<IdentifierViewModel> _identifierViewModels;
        private readonly List<ConstantViewModel> _constantViewModels;
        private readonly List<AnalyzeErrorViewModel> _errorViewModels;


        public LexnForm()
        {
            InitializeComponent();
            _lexicalAnalyzer = LexisFactory.CreateLexicalAnalyzer();
            _syntaxAnalyzer = SyntaxFactory.CreateSyntaxAnalyzer();
            _keyWordsProvider = CommonFactory.CreateKeyWordsProvider();
            _lexemViewModels = new List<LexemViewModel>();
            _identifierViewModels = new List<IdentifierViewModel>();
            _constantViewModels = new List<ConstantViewModel>();
            _errorViewModels = new List<AnalyzeErrorViewModel>();
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
            ClearLists();
            var lexicalAnalyzeResult = _lexicalAnalyzer.Analyze(txtCode.Text) as LexicalAnalyzeResult;
            if (lexicalAnalyzeResult != null)
            {
                if (lexicalAnalyzeResult.IsValid)
                {
                    var lexemViewModels = lexicalAnalyzeResult.Lexems.Select(item => new LexemViewModel
                    {
                        LexemID = item.LexemID,
                        Line = item.Line,
                        Name = item.Name + (item.Identifier != null && item.Identifier.Type != null
                            ? "(" + item.Identifier.Type + ")"
                            : String.Empty),
                        Type = item.Type.ToString()
                    }).ToList();
                    _lexemViewModels.AddRange(lexemViewModels);

                    var identifiersViewModels = lexicalAnalyzeResult.Identifiers.Select(item => new IdentifierViewModel
                    {
                        IdentifierID = item.IdentifierID,
                        Name = item.Name,
                        Type = item.Type
                    });
                    _identifierViewModels.AddRange(identifiersViewModels);

                    var constantViewModels = lexicalAnalyzeResult.Constants.Select(item => new ConstantViewModel
                    {
                        ConstantID = item.ConstantID,
                        Value = item.Value
                    });
                    _constantViewModels.AddRange(constantViewModels);
                    HideErrors();
                }
                else
                {
                    var lexicalErrorViewModel = lexicalAnalyzeResult.Errors.Select(item => new AnalyzeErrorViewModel
                    {
                        Code = item.Code.ToString(),
                        Line = item.Line,
                        Message = item.Message
                    }).ToList();
                    _errorViewModels.AddRange(lexicalErrorViewModel);
                    ShowErrors();
                }
                var semanticalAnalyzeResult = _syntaxAnalyzer.Analyze(lexicalAnalyzeResult.Lexems) as SyntaxisAnalyzeResult;
                if (semanticalAnalyzeResult != null)
                {
                    if (!semanticalAnalyzeResult.IsValid)
                    {
                        var semanticalErrorViewModels = semanticalAnalyzeResult.Errors
                            .Select(item => new AnalyzeErrorViewModel
                        {
                            Code = item.Code.ToString(),
                            Line = item.Line,
                            Message = item.Message
                        }).ToList();
                        _errorViewModels.AddRange(semanticalErrorViewModels);
                        ShowErrors();
                    }
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
            var form = new PopupForm();
            form.Show(this);
            form.InitIdentifiersGrid(_identifierViewModels);
        }

        private void btnViewConstants_Click(object sender, EventArgs e)
        {
            var form = new PopupForm();
            form.Show(this);
            form.InitConstantGrid(_constantViewModels);
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
            HideAllButtons();
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

        private void ClearLists()
        {
            _lexemViewModels.Clear();
            _errorViewModels.Clear();
            _identifierViewModels.Clear();
            _constantViewModels.Clear();
        }

        private void HideAllButtons()
        {
            btnViewLexems.Visible = false;
            btnViewLexems.Visible = false;
            btnViewIdentifiers.Visible = false;
            btnViewConstants.Visible = false;
            btnViewErrors.Visible = false;
        }

        private void ShowErrors()
        {
            btnViewLexems.Visible = false;
            btnViewLexems.Visible = false;
            btnViewIdentifiers.Visible = false;
            btnViewConstants.Visible = false;
            btnViewErrors.Visible = true;
        }

        private void HideErrors()
        {
            btnViewLexems.Visible = true;
            btnViewIdentifiers.Visible = true;
            btnViewConstants.Visible = true;
            btnViewErrors.Visible = false;
        }
    }
}
