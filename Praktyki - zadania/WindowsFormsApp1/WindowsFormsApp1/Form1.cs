using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public bool Multiselect { get; set; }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeOpenFileDialogPlik();
        }
        private void InitializeOpenFileDialogPlik()
        {
            this.openFileDialogPlik.Filter =
            "Docx Files (*docx)|*docx| All Files (*.*)|*.*";
            
            this.openFileDialogPlik.Multiselect = true;
            
            this.openFileDialogPlik.Title = "Wybierz pliki";
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Multiselect = false, Filter = "Word Doucment|*.docx|Word 97 - 2003 Document|*.doc" })
            {
                OpenFileDialog open = new OpenFileDialog
                {
                    Title = "Otwórz plik",
                    Filter = "Docx Files (*docx)|*docx| All Files (*.*)|*.*"
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        object readOnly = true;
                        object visible = true;
                        object save = false;
                        object fileName = ofd.FileName;
                        object missing = Type.Missing;
                        object newTemplate = false;
                        object docType = 0;
                        Microsoft.Office.Interop.Word._Document oDoc = null;
                        Microsoft.Office.Interop.Word._Application oWord = new Microsoft.Office.Interop.Word.Application() { Visible = false };
                        oDoc = oWord.Documents.Open(
                            ref fileName, ref missing, ref readOnly, ref missing,
                            ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref visible,
                            ref missing, ref missing, ref missing, ref missing);
                        oDoc.ActiveWindow.Selection.WholeStory();
                        oDoc.ActiveWindow.Selection.Copy();
                        IDataObject data = Clipboard.GetDataObject();
                        richTextBoxFile.Rtf = data.GetData(DataFormats.Rtf).ToString();
                        oWord.Quit(ref missing, ref missing, ref missing);
                    }
                    catch (COMException)
                    {
                        MessageBox.Show("Błąd podczas otwierania pliku, sprawdź czy plik nie jest uszkodzony.", "Błąd Otwarcia Pliku", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void ButtonSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Zapisz jako";
                sfd.Filter = "Word Document (*.docx)|*.docx|All Files (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Skopiuj zawartość RichTextBox do schowka
                        Clipboard.SetText(richTextBoxFile.Rtf, TextDataFormat.Rtf);

                        // Utwórz nowy dokument Word
                        Microsoft.Office.Interop.Word._Application wordApp = new Microsoft.Office.Interop.Word.Application();
                        Microsoft.Office.Interop.Word._Document wordDoc = wordApp.Documents.Add();

                        // Wklej zawartość schowka do nowego dokumentu Word
                        wordDoc.ActiveWindow.Selection.Paste();

                        // Zapisz dokument Word
                        wordDoc.SaveAs(sfd.FileName);
                        wordDoc.Close();
                        wordApp.Quit();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Błąd zapisu pliku. Sprawdź, czy plik nie jest już otwarty lub czy nie brakuje Ci uprawnień do zapisu pliku.", "Błąd Zapisu Pliku", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }





        private void ButtonOpenManyFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Multiselect = true, Filter = "Word Doucment|*.docx|Word 97 - 2003 Document|*.doc" })
            {
                if (ofd.ShowDialog() == DialogResult.OK) // Wyświetlenie okna dialogowego wyboru pliku, jeśli OK to kontynuuj
                {
                    try
                    {
                        richTextBoxFile.Clear(); // Wyczyszczenie zawartości RichTextBox
                        object readOnly = true; // Ustawienie wartości dla opcji tylko do odczytu dla otwartego dokumentu
                        object visible = true; // Ustawienie wartości dla opcji widoczności otwartego dokumentu
                        object save = false; // Ustawienie wartości dla opcji zapisu otwartego dokumentu
                        object missing = Type.Missing; // Ustawienie wartości dla brakujących parametrów
                        object newTemplate = false; // Ustawienie wartości dla opcji nowego szablonu dla otwartego dokumentu
                        object docType = 0; // Ustawienie wartości dla typu otwartego dokumentu
                        Microsoft.Office.Interop.Word._Document oDoc = null; // Inicjalizacja obiektu dokumentu Word
                        Microsoft.Office.Interop.Word._Application oWord = new Microsoft.Office.Interop.Word.Application() { Visible = false }; // Inicjalizacja obiektu aplikacji Word

                        foreach (string fileName in ofd.FileNames) // Pętla po nazwach plików wybranych w oknie dialogowym
                        {
                            try
                            {
                                string docFileName = fileName; // Przypisanie nazwy pliku do zmiennej docFileName
                                object objFileName = (object)docFileName; // Konwersja nazwy pliku do obiektu
                                oDoc = oWord.Documents.Open(
                                    ref objFileName, ref missing, ref readOnly, ref missing,
                                    ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref visible,
                                    ref missing, ref missing, ref missing, ref missing); // Otwarcie dokumentu w aplikacji Word
                                oDoc.ActiveWindow.Selection.WholeStory(); // Zaznaczenie całej zawartości dokumentu
                                oDoc.ActiveWindow.Selection.Copy(); // Skopiowanie zaznaczonej zawartości do schowka
                                IDataObject data = Clipboard.GetDataObject(); // Pobranie danych ze schowka
                                richTextBoxFile.Select(richTextBoxFile.TextLength, 0); // Zaznaczenie całej zawartości RichTextBox
                                richTextBoxFile.SelectionStart = richTextBoxFile.TextLength; // Ustawienie kursora na końcu zawartości
                                richTextBoxFile.SelectedRtf = data.GetData(DataFormats.Rtf).ToString(); // Dodanie RTF z dokumentu do zawartości RichTextBox
                                oDoc.Close(ref save, ref missing, ref missing); // Zamknięcie dokumentu
                            }
                            catch (COMException)
                            {
                                MessageBox.Show("Błąd podczas otwierania pliku " + fileName + ", sprawdź czy plik nie jest uszkodzony.", "Błąd Otwarcia Pliku", MessageBoxButtons.OK, MessageBoxIcon.Error); // Wyświetlenie okna dialogowego z informacją o błędzie
                            }
                        }

                        oWord.Quit(ref missing, ref missing, ref missing);
                    }
                    catch (COMException)
                    {
                        MessageBox.Show("Błąd podczas otwierania plików, sprawdź czy pliki nie są uszkodzone.", "Błąd Otwarcia Plików", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void saveFileDialogWord_FileOk(object sender, CancelEventArgs e)
        {
            const string V = "Word Document (*docx)|*docx| All Files (*.*)|*.*";
            this.saveFileDialogWord.Filter = V;
            
            this.saveFileDialogWord.Title = "Zapisz pliki";
        }
    }
}

