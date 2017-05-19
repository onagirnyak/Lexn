using FastColoredTextBoxNS;

namespace Lexn.UI
{
    partial class LexnForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LexnForm));
            this.txtCode = new FastColoredTextBoxNS.FastColoredTextBox();
            this.btnLexicalAnalyze = new System.Windows.Forms.Button();
            this.btnViewLexems = new System.Windows.Forms.Button();
            this.btnViewIdentifiers = new System.Windows.Forms.Button();
            this.btnViewConstants = new System.Windows.Forms.Button();
            this.btnViewErrors = new System.Windows.Forms.Button();
            this.btnViewReversePolish = new System.Windows.Forms.Button();
            this.btnViewOutput = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtCode.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.txtCode.BackBrush = null;
            this.txtCode.CharHeight = 14;
            this.txtCode.CharWidth = 8;
            this.txtCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCode.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtCode.IsReplaceMode = false;
            this.txtCode.Location = new System.Drawing.Point(16, 15);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCode.Name = "txtCode";
            this.txtCode.Paddings = new System.Windows.Forms.Padding(0);
            this.txtCode.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtCode.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtCode.ServiceColors")));
            this.txtCode.Size = new System.Drawing.Size(840, 474);
            this.txtCode.TabIndex = 0;
            this.txtCode.Zoom = 100;
            this.txtCode.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.txtCode_TextChanged);
            // 
            // btnLexicalAnalyze
            // 
            this.btnLexicalAnalyze.Location = new System.Drawing.Point(13, 507);
            this.btnLexicalAnalyze.Margin = new System.Windows.Forms.Padding(4);
            this.btnLexicalAnalyze.Name = "btnLexicalAnalyze";
            this.btnLexicalAnalyze.Size = new System.Drawing.Size(100, 60);
            this.btnLexicalAnalyze.TabIndex = 1;
            this.btnLexicalAnalyze.Text = "Run";
            this.btnLexicalAnalyze.UseVisualStyleBackColor = true;
            this.btnLexicalAnalyze.Click += new System.EventHandler(this.btnLexicalAnalyze_Click);
            // 
            // btnViewLexems
            // 
            this.btnViewLexems.Location = new System.Drawing.Point(118, 507);
            this.btnViewLexems.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewLexems.Name = "btnViewLexems";
            this.btnViewLexems.Size = new System.Drawing.Size(100, 60);
            this.btnViewLexems.TabIndex = 2;
            this.btnViewLexems.Text = "View lexems";
            this.btnViewLexems.UseVisualStyleBackColor = true;
            this.btnViewLexems.Click += new System.EventHandler(this.btnViewLexems_Click);
            // 
            // btnViewIdentifiers
            // 
            this.btnViewIdentifiers.Location = new System.Drawing.Point(226, 507);
            this.btnViewIdentifiers.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewIdentifiers.Name = "btnViewIdentifiers";
            this.btnViewIdentifiers.Size = new System.Drawing.Size(100, 60);
            this.btnViewIdentifiers.TabIndex = 3;
            this.btnViewIdentifiers.Text = "View identifiers";
            this.btnViewIdentifiers.UseVisualStyleBackColor = true;
            this.btnViewIdentifiers.Click += new System.EventHandler(this.btnViewIdentifiers_Click);
            // 
            // btnViewConstants
            // 
            this.btnViewConstants.Location = new System.Drawing.Point(334, 507);
            this.btnViewConstants.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewConstants.Name = "btnViewConstants";
            this.btnViewConstants.Size = new System.Drawing.Size(100, 60);
            this.btnViewConstants.TabIndex = 4;
            this.btnViewConstants.Text = "View constants";
            this.btnViewConstants.UseVisualStyleBackColor = true;
            this.btnViewConstants.Click += new System.EventHandler(this.btnViewConstants_Click);
            // 
            // btnViewErrors
            // 
            this.btnViewErrors.Location = new System.Drawing.Point(658, 507);
            this.btnViewErrors.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewErrors.Name = "btnViewErrors";
            this.btnViewErrors.Size = new System.Drawing.Size(100, 60);
            this.btnViewErrors.TabIndex = 5;
            this.btnViewErrors.Text = "View errors";
            this.btnViewErrors.UseVisualStyleBackColor = true;
            this.btnViewErrors.Click += new System.EventHandler(this.btnViewErrors_Click);
            // 
            // btnViewReversePolish
            // 
            this.btnViewReversePolish.Location = new System.Drawing.Point(442, 507);
            this.btnViewReversePolish.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewReversePolish.Name = "btnViewReversePolish";
            this.btnViewReversePolish.Size = new System.Drawing.Size(100, 60);
            this.btnViewReversePolish.TabIndex = 6;
            this.btnViewReversePolish.Text = "View reverse Polish";
            this.btnViewReversePolish.UseVisualStyleBackColor = true;
            this.btnViewReversePolish.Click += new System.EventHandler(this.btnViewReversePolish_Click);
            // 
            // btnViewOutput
            // 
            this.btnViewOutput.Location = new System.Drawing.Point(550, 507);
            this.btnViewOutput.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewOutput.Name = "btnViewOutput";
            this.btnViewOutput.Size = new System.Drawing.Size(100, 60);
            this.btnViewOutput.TabIndex = 7;
            this.btnViewOutput.Text = "View output";
            this.btnViewOutput.UseVisualStyleBackColor = true;
            this.btnViewOutput.Click += new System.EventHandler(this.btnViewOutput_Click);
            // 
            // LexnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 580);
            this.Controls.Add(this.btnViewOutput);
            this.Controls.Add(this.btnViewReversePolish);
            this.Controls.Add(this.btnViewErrors);
            this.Controls.Add(this.btnViewConstants);
            this.Controls.Add(this.btnViewIdentifiers);
            this.Controls.Add(this.btnViewLexems);
            this.Controls.Add(this.btnLexicalAnalyze);
            this.Controls.Add(this.txtCode);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LexnForm";
            this.Text = "Lexn";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LexnForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBox txtCode;
        private System.Windows.Forms.Button btnLexicalAnalyze;
        private System.Windows.Forms.Button btnViewLexems;
        private System.Windows.Forms.Button btnViewIdentifiers;
        private System.Windows.Forms.Button btnViewConstants;
        private System.Windows.Forms.Button btnViewErrors;
        private System.Windows.Forms.Button btnViewReversePolish;
        private System.Windows.Forms.Button btnViewOutput;
    }
}

