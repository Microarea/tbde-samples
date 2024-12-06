using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.AvalonEdit.Utils;
using ICSharpCode.AvalonEdit.Folding;
using System.Windows.Threading;
using System.Web.UI.WebControls;
using TbApiTester.Libraries;



namespace TbApiTester.OtherControls
{
    //===================================================================================
    public partial class XmlEditor : UserControl
    {
        private int _lastSearchIndex = 0;
        private readonly XmlEditorWpf _textEditorControl = new XmlEditorWpf();
        private FoldingManager _foldingManager = null;
        private object _foldingStrategy;
        private string _textContent = "";

        readonly DispatcherTimer foldingUpdateTimer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromSeconds(2)
        };

        //--------------------------------------------------------------------------			
        public XmlEditor()
        {
            InitializeComponent();
            InitializeEditor();
        }

        //--------------------------------------------------------------------------			
        private void InitializeEditor()
        {
            elementHost1.Child = _textEditorControl;

            _textEditorControl.textEditor.ShowLineNumbers = false;
            _textEditorControl.textEditor.TextArea.KeyDown += TextArea_KeyDown;

            _foldingStrategy = new XmlFoldingStrategy();
            _textEditorControl.textEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.DefaultIndentationStrategy();

            InitializeFoldingManager();

            _textEditorControl.textEditor.FontFamily = new System.Windows.Media.FontFamily(Globals.CurrentFont.FontFamily.Name);
            _textEditorControl.textEditor.FontSize = Globals.CurrentFont.Size;

            Globals.FontChanged += Globals_FontChanged;
            _textEditorControl.textEditor.VerticalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto;
            _textEditorControl.textEditor.HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto;

            _textEditorControl.textEditor.Document.TextChanged += Document_TextChanged;
            //toolStrip1.Visible = false;
        }

        //--------------------------------------------------------------------------			
        internal void SetFocus()
        {
            _textEditorControl.textEditor.Focus();
        }

        //--------------------------------------------------------------------------			
        private void Document_TextChanged(object sender, EventArgs e)
        {
            _textContent = _textEditorControl.textEditor.Document.Text;
        }

        //--------------------------------------------------------------------------			
        private void Globals_FontChanged(object sender, MonthChangedEventArgs e)
        {
            //_textEditorControl.textEditor.FontFamily = new System.Windows.Media.FontFamily(e.FontFamily);
            //_textEditorControl.textEditor.FontSize = e.FontSize;
        }

        //--------------------------------------------------------------------------			
        void InitializeFoldingManager()
        {
            _foldingManager = FoldingManager.Install(_textEditorControl.textEditor.TextArea);
            UpdateFoldings();

            foldingUpdateTimer.Tick += delegate { UpdateFoldings(); };
            foldingUpdateTimer.Start();
        }

        //--------------------------------------------------------------------------			
        void UpdateFoldings()
        {
            if (_foldingStrategy is XmlFoldingStrategy strategy && !string.IsNullOrWhiteSpace(_textEditorControl.textEditor.Text))
            {
                strategy.UpdateFoldings(_foldingManager, _textEditorControl.textEditor.Document);
            }
        }

        //--------------------------------------------------------------------------			
        public string TextContent
        {
            get
            {
                return _textContent;
            }
            set
            {
                _textEditorControl.textEditor.Document.Text = XmlFormattingStrategy.FormatStringInXml(value);
                _textContent = value;
            }
        }

        //--------------------------------------------------------------------------			
        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog()
            {
                DefaultExt = "xml",
                Filter = "Xml files (*.xml)|*.xml",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            DialogResult res = fd.ShowDialog(this);
            if (res != DialogResult.OK)
                return;

            try
            {
                File.WriteAllText(fd.FileName, TextContent);
            }
            catch (Exception)
            {
            }
        }

        //--------------------------------------------------------------------------			
        void TextArea_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            DoKeyDown(KeyEventExts.ToWinforms(e));
        }

        //--------------------------------------------------------------------------			
        private void TsText_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            DoKeyDown(e);
        }

        //--------------------------------------------------------------------------			
        private void TsNextFind_Click(object sender, EventArgs e)
        {
            SearchNext();
        }

        //--------------------------------------------------------------------------			
        private void TsPreviousFind_Click(object sender, EventArgs e)
        {
            SearchPrevious();
        }

        //--------------------------------------------------------------------------			
        private void TsClose_Click(object sender, EventArgs e)
        {
            //toolStrip1.Visible = false;
        }

        //--------------------------------------------------------------------------			
        private void TsText_TextChanged(object sender, EventArgs e)
        {
            _lastSearchIndex = 0;
        }

        //--------------------------------------------------------------------------			
        private void OptionsContextMenu_Opening(object sender, CancelEventArgs e)
        {
            toolStripSelectAll.Enabled = true;
            toolStripCopy.Enabled = !string.IsNullOrEmpty(_textEditorControl.textEditor.Document.Text);
            toolStripPaste.Enabled = Clipboard.ContainsData(DataFormats.Text);
        }

        //--------------------------------------------------------------------------			
        private void ToolStripSelectAll_Click(object sender, EventArgs e)
        {
            _textEditorControl.textEditor.SelectAll();
        }

        //--------------------------------------------------------------------------			
        private void ToolStripCopy_Click(object sender, EventArgs e)
        {
            string text = _textEditorControl.textEditor.SelectedText;
            if (string.IsNullOrEmpty(text))
                return;

            Clipboard.SetText(text);
        }

        //--------------------------------------------------------------------------			
        private void ToolStripPaste_Click(object sender, EventArgs e)
        {
            _textEditorControl.textEditor.Document.Text = Clipboard.GetText();
        }

        //--------------------------------------------------------------------------			
        private void DoKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == (int)Keys.F) //Ctrl+F
            {
                //toolStrip1.Visible = true;
                tsText.Text = string.Empty;
                tsText.Focus();
            }
            if (e.KeyValue == 13) //Enter
                SearchNext();
            if (e.Control && e.KeyValue == (int)Keys.F3) //Ctrl+F3
                tsText.Text = _textEditorControl.textEditor.SelectedText;
            if (!e.Control && !e.Shift && e.KeyValue == (int)Keys.F3) //F3 Search Forward
                SearchNext();
            if (e.Shift && e.KeyValue == (int)Keys.F3) //Shift+F3 Search Backward
                SearchPrevious();
        }

        //--------------------------------------------------------------------------			
        private void SearchNext()
        {
            _lastSearchIndex = GetForwardIndex();
            HighlightSelectedText();
        }

        //--------------------------------------------------------------------------			
        private void SearchPrevious()
        {
            _lastSearchIndex = GetBackwardIndex();

            HighlightSelectedText();
        }

        //--------------------------------------------------------------------------			
        private void HighlightSelectedText()
        {
            if (_lastSearchIndex < 0)
            {
                //tslblMatched.Text = Strings.NoMatches;
                return;
            }
            tslblMatched.Text = string.Empty;
            _textEditorControl.textEditor.TextArea.Selection = Selection.Create(_textEditorControl.textEditor.TextArea, _lastSearchIndex, _lastSearchIndex + tsText.Text.Length);
        }

        //--------------------------------------------------------------------------			
        private int GetBackwardIndex()
        {
            string text = _textEditorControl.textEditor.Document.Text;
            int tempIndex = text.ToLower().LastIndexOf(tsText.Text.ToLower(), _lastSearchIndex);
            //Se è minore di zero o ho fatto il giro completo o non ho trovato niente o sto ricominciando il giro
            if (tempIndex < 0)
            {
                tempIndex = text.Length;
                tempIndex = text.ToLower().LastIndexOf(tsText.Text.ToLower(), tempIndex);
            }
            return tempIndex;
        }

        //--------------------------------------------------------------------------			
        private int GetForwardIndex()
        {
            string text = _textEditorControl.textEditor.Document.Text;
            int tempIndex = text.ToLower().IndexOf(tsText.Text.ToLower(), _lastSearchIndex + tsText.Text.Length);
            //Se è minore di zero o ho fatto il giro completo o non ho trovato niente o sto ricominciando il giro
            if (tempIndex < 0)
            {
                tempIndex = 0;
                tempIndex = text.ToLower().IndexOf(tsText.Text.ToLower(), tempIndex + tsText.Text.Length);
            }
            return tempIndex;
        }

        private void InitializeComponent2()
        {
            this.SuspendLayout();
            // 
            // XmlEditor
            // 
            this.Name = "XmlEditor";
            this.ResumeLayout(false);

        }
    }

    public static class KeyEventExts
    {
        public static System.Windows.Forms.KeyEventArgs ToWinforms(this System.Windows.Input.KeyEventArgs keyEventArgs)
        {
            // So far this ternary remained pointless, might be useful in some very specific cases though
            var wpfKey = keyEventArgs.Key == System.Windows.Input.Key.System ? keyEventArgs.SystemKey : keyEventArgs.Key;
            var winformModifiers = keyEventArgs.KeyboardDevice.Modifiers.ToWinforms();
            var winformKeys = (System.Windows.Forms.Keys)System.Windows.Input.KeyInterop.VirtualKeyFromKey(wpfKey);
            return new System.Windows.Forms.KeyEventArgs(winformKeys | winformModifiers);
        }

        public static System.Windows.Forms.Keys ToWinforms(this System.Windows.Input.ModifierKeys modifier)
        {
            var retVal = System.Windows.Forms.Keys.None;
            if (modifier.HasFlag(System.Windows.Input.ModifierKeys.Alt))
            {
                retVal |= System.Windows.Forms.Keys.Alt;
            }
            if (modifier.HasFlag(System.Windows.Input.ModifierKeys.Control))
            {
                retVal |= System.Windows.Forms.Keys.Control;
            }
            if (modifier.HasFlag(System.Windows.Input.ModifierKeys.None))
            {
                // Pointless I know
                retVal |= System.Windows.Forms.Keys.None;
            }
            if (modifier.HasFlag(System.Windows.Input.ModifierKeys.Shift))
            {
                retVal |= System.Windows.Forms.Keys.Shift;
            }
            if (modifier.HasFlag(System.Windows.Input.ModifierKeys.Windows))
            {
                // Not supported lel
            }
            return retVal;
        }
    }
}
