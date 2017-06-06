using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using Lexn.CodeExecutor;
using Lexn.CodeExecutor.Interfaces;
using Lexn.Common;
using Lexn.Common.Interfaces;
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
        private readonly IPostfixNotationBuilder _postfixNotationBuilder;
        private readonly IPostfixNotationExecutor _postfixNotationExecutor;
        private readonly Style _blueStyle;

        private readonly List<LexemViewModel> _lexemViewModels;
        private readonly List<IdentifierViewModel> _identifierViewModels;
        private readonly List<ConstantViewModel> _constantViewModels;
        private readonly List<AnalyzeErrorViewModel> _errorViewModels;
        private readonly List<ReversePolishViewModel> _reversePolishViewModels;

        private readonly List<string> _output;


        public LexnForm()
        {
            _lexicalAnalyzer = LexisFactory.CreateLexicalAnalyzer();
            _syntaxAnalyzer = SyntaxFactory.CreateSyntaxAnalyzer();
            _keyWordsProvider = CommonFactory.CreateKeyWordsProvider();

            _postfixNotationBuilder = CodeExecutorFactory.CreatePostfixNotationBuilder();
            _postfixNotationExecutor = CodeExecutorFactory.CreateIPostfixNotationExecutor();

            _lexemViewModels = new List<LexemViewModel>();
            _identifierViewModels = new List<IdentifierViewModel>();
            _constantViewModels = new List<ConstantViewModel>();
            _errorViewModels = new List<AnalyzeErrorViewModel>();
            _reversePolishViewModels = new List<ReversePolishViewModel>();
            _output = new List<string>();
            _blueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Italic);
            InitializeComponent();
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

                    var syntaxisAnalyzeResult = _syntaxAnalyzer.Analyze(lexicalAnalyzeResult.Lexems) as SyntaxisAnalyzeResult;
                    if (syntaxisAnalyzeResult != null)
                    {
                        if (syntaxisAnalyzeResult.IsValid)
                        {
                            try
                            {
                                var list = lexicalAnalyzeResult.Lexems.ToList();
                                var from = list.FindIndex(item => item.Name == "begin");
                                list.RemoveRange(0, from + 1);

                                var to = list.FindLastIndex(item => item.Name == "end");
                                list.RemoveRange(to, list.Count - to);

                                var lexems = _postfixNotationBuilder.Build(list);
                                var reversePolishViewModels = lexems.Select(item => new ReversePolishViewModel
                                {
                                    Value = item.Name
                                }).ToList();
                                _reversePolishViewModels.AddRange(reversePolishViewModels);

                                var output = _postfixNotationExecutor.Execute(lexems, (name) =>
                                {
                                    return "10";
                                });
                                _output.AddRange(output);
                            }
                            catch (Exception exc)
                            {
                                //TODO: need write logger
                            }
                        }
                        else
                        {
                            var syntaxisErrorViewModels = syntaxisAnalyzeResult.Errors
                              .Select(item => new AnalyzeErrorViewModel
                              {
                                  Code = item.Code.ToString(),
                                  Line = item.Line,
                                  Message = item.Message
                              }).ToList();
                            _errorViewModels.AddRange(syntaxisErrorViewModels);
                            btnViewErrors.Visible = true;
                        }
                    }
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

        private void btnViewReversePolish_Click(object sender, EventArgs e)
        {
            var form = new PopupForm();
            form.Show(this);
            form.InitReversePolishGrid(_reversePolishViewModels);
        }

        private void btnViewOutput_Click(object sender, EventArgs e)
        {
            var form = new OutputForm();
            form.Show(this);
            form.InitOutputTextbox(_output);
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
            return @"program MyProgram var i,j:decimal
begin
    j := 3
    if j = 5 then
        j := j + 15.15
    else 
        i := i + 2
    end
    i := (10 * 10 * 50) + 10 + 15
    writeln j
    writeln i
end
";
        }

        private void ClearLists()
        {
            _lexemViewModels.Clear();
            _errorViewModels.Clear();
            _identifierViewModels.Clear();
            _constantViewModels.Clear();
            _reversePolishViewModels.Clear();
            _output.Clear();
        }

        private void HideAllButtons()
        {
            btnViewLexems.Visible = false;
            btnViewLexems.Visible = false;
            btnViewIdentifiers.Visible = false;
            btnViewConstants.Visible = false;
            btnViewErrors.Visible = false;
            btnViewReversePolish.Visible = false;
            btnViewOutput.Visible = false;
        }

        private void ShowErrors()
        {
            btnViewLexems.Visible = false;
            btnViewLexems.Visible = false;
            btnViewIdentifiers.Visible = false;
            btnViewConstants.Visible = false;
            btnViewErrors.Visible = true;
            btnViewReversePolish.Visible = false;
            btnViewOutput.Visible = false;
        }

        private void HideErrors()
        {
            btnViewLexems.Visible = true;
            btnViewIdentifiers.Visible = true;
            btnViewConstants.Visible = true;
            btnViewReversePolish.Visible = true;
            btnViewOutput.Visible = true;
            btnViewErrors.Visible = false;
        }
    }
}
