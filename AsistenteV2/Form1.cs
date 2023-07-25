using System.Diagnostics;
using System.Windows.Forms;

namespace AsistenteV2
{
    public partial class Form1 : Form
    {
        private List<ExecutableData> allExecutables = new List<ExecutableData>();
        private string infoUrl = Application.StartupPath + @"Executables_info.txt";
        private const int XVALUE = 20;
        private const int YVALUE = 100;
        private const int NOBJECTS = 4;
        private const int LIMIT = 250 * NOBJECTS;
        private int xValue = XVALUE;
        private int yValue = YVALUE;
        private ExecutableMode mode = ExecutableMode.EXECUTE;
        private string btnCancelName = "btnCancel";

        delegate void myFileDialogs(string title, string fileType, ExecutableData? executable);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            readFileWithList();
            createAllObjects();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            newExcutable();
        }

        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            changeMode(ExecutableMode.CHANGEIMAGE);
        }

        private void btnChangeAplication_Click(object sender, EventArgs e)
        {
            changeMode(ExecutableMode.CHANGEEXECUTABLE);
        }

        private void btnIncludeApp_Click(object sender, EventArgs e)
        {
            changeMode(ExecutableMode.INSERT);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            changeMode(ExecutableMode.ERASE);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            changeMode(ExecutableMode.EXECUTE);
        }

        private void writeFileWithList()
        {
            using (StreamWriter file = new StreamWriter(infoUrl))
            {
                foreach (ExecutableData executableData in allExecutables)
                {
                    file.WriteLine(executableData.toString());
                }
                file.Close();
            }
        }

        private void readFileWithList()
        {
            if (File.Exists(infoUrl))
            {
                StreamReader file = new StreamReader(infoUrl);
                using (file)
                {
                    while (!file.EndOfStream)
                    {
                        ExecutableData? executable = ExecutableData.fromText(file.ReadLine());
                        if (executable == null) continue;
                        allExecutables.Add(executable);

                    }
                    file.Close();
                }
            }
            else
            {
                File.Create(infoUrl).Close();
            }
        }

        public void changeMode(ExecutableMode mode)
        {
            this.mode = mode;
            switch (mode)
            {
                case ExecutableMode.EXECUTE:
                    foreach (Control control in Controls)
                    {
                        if (control is Button)
                        {
                            if (control.Name == btnCancelName)
                            {
                                control.Enabled = false;
                                continue;
                            }
                            control.Enabled = true;
                        }
                    }
                    return;
                default:
                    break;
            }
            enableButtons();
        }

        public void enableButtons()
        {
            foreach (Control control in Controls)
            {
                if (control is Button)
                {
                    if (control.Name == btnCancelName)
                    {
                        control.Enabled = true;
                        continue;
                    }
                    control.Enabled = false;
                }
            }
        }

        private void createAllObjects()
        {
            foreach (ExecutableData executableData in allExecutables)
            {
                createDinamicalyControls(executableData);
            }
        }

        private void createSingleObject(ExecutableData executableData)
        {
            createDinamicalyControls(executableData);
        }

        private void createDinamicalyControls(ExecutableData executableData)
        {
            PictureBox pictureBox = new PictureBox();
            Label label = new Label();

            if (!string.IsNullOrEmpty(executableData.ImagePath))
            {
                pictureBox.Image = Image.FromFile(executableData.ImagePath);
            }
            pictureBox.Name = executableData.Name;
            pictureBox.Size = new Size(240, 300);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Click += new EventHandler(pictureBoxBehavior);
            pictureBox.Location = new Point(xValue, yValue);

            label.Name = executableData.Name;
            label.Size = new Size(160, 70);
            label.ForeColor = Color.FromArgb(255, 205, 0);
            label.Font = new Font("Microsoft Tai Le", 12f, FontStyle.Bold);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Text = executableData.Name;
            label.Parent = this;
            label.BackColor = Color.Transparent;
            label.Location = new Point(xValue + 40, yValue + 290);

            executableData.PictureBox = pictureBox;
            executableData.Label = label;
            Controls.Add(pictureBox);
            Controls.Add(label);

            newPosition();
        }

        private void newPosition()
        {
            if (xValue >= LIMIT)
            {
                xValue = XVALUE;
                yValue += 360;
            }
            else
            {
                xValue += 270;
            }
        }

        private void moveObjects()
        {
            xValue = XVALUE;
            yValue = YVALUE;
            foreach (ExecutableData executable in allExecutables)
            {
                if (executable.PictureBox == null || executable.Label == null) return;
                executable.PictureBox.Location = new Point(xValue, yValue);
                executable.Label.Location = new Point(xValue + 40, yValue + 290);
                newPosition();
            }
        }

        private int? findExecutable(string name)
        {
            for (int i = 0; i < allExecutables.Count; i++)
            {
                if (allExecutables[i].Name == name)
                {
                    return i;
                }
            }
            return null;
        }

        private Label? findLabel(string name)
        {
            foreach (Control control in Controls.Find(name, true))
            {
                if (control is Label)
                {
                    Label label = (Label)control;
                    return label;
                }
            }
            return null;
        }

        private void pictureBoxBehavior(object? sender, EventArgs e)
        {
            if (sender == null) return;
            PictureBox pictureBox = (PictureBox)sender;
            int? index = findExecutable(pictureBox.Name);
            if (index == null) return;
            ExecutableData executable = allExecutables[index.Value];
            switch (mode)
            {
                case ExecutableMode.ERASE:
                    if (allExecutables.Remove(executable))
                    {
                        changeMode(ExecutableMode.EXECUTE);
                        writeFileWithList();

                        Controls.Remove(pictureBox);
                        Label? label = findLabel(executable.Name);
                        if (label != null)
                        {
                            Controls.Remove(label);
                            label.Dispose();
                        }
                        pictureBox.Dispose();
                        moveObjects();
                    }
                    break;
                case ExecutableMode.INSERT:
                    newExcutable(index);
                    break;
                case ExecutableMode.EXECUTE:
                    ProcessStartInfo psi = new ProcessStartInfo(executable.Path);
                    psi.UseShellExecute = true;
                    Process.Start(psi);
                    break;
                case ExecutableMode.CHANGEIMAGE:
                    changeMode(ExecutableMode.EXECUTE);
                    locateNewImage(
                        "Cambiar Imagen",
                        "Archivos Ico (*.Ico*.ico)|*.Ico; *ico|Archivos Png (*.Png*.png)|*.Png; *png|Todos los archivos (*.*)|*.*",
                        executable
                     );
                    writeFileWithList();
                    break;
                case ExecutableMode.CHANGEEXECUTABLE:
                    changeMode(ExecutableMode.EXECUTE);
                    locateNewExecutable(
                        "Cambiar Aplicacion",
                        "Archivos Text (*.Lnk*.lnk)|*.Lnk; *lnk|Todos los archivos (*.*)|*.*",
                        executable
                     );
                    writeFileWithList();
                    break;
                default:
                    break;
            }
        }

        private void newExcutable(int? index = null)
        {
            ExecutableData? newExecutable = locateNewExecutable(
               "Aplicacion",
               "Archivos Text (*.Lnk*.lnk)|*.Lnk; *lnk|Todos los archivos (*.*)|*.*"
               );
            if (newExecutable == null) return;
            ExecutableData completeExecutable = locateNewImage(
                "Subir Imagen",
                "Archivos Ico (*.Ico*.ico)|*.Ico; *ico|Archivos Png (*.Png*.png)|*.Png; *png|Todos los archivos (*.*)|*.*",
                newExecutable
                );
            if (completeExecutable == null) return;
            if (index == null)
            {
                addToList(completeExecutable);
                return;
            }
            insertToList(completeExecutable, index.Value);
        }

        private void addToList(ExecutableData executableData)
        {
            allExecutables.Add(executableData);
            createSingleObject(executableData);
            writeFileWithList();
            GC.Collect();
        }

        private void insertToList(ExecutableData executableData, int index)
        {
            allExecutables.Insert(index, executableData);
            createSingleObject(executableData);
            writeFileWithList();
            moveObjects();
            changeMode(ExecutableMode.EXECUTE);
            GC.Collect();
        }

        private ExecutableData? locateNewExecutable(string title, string fileType, ExecutableData? executable = null)
        {
            ExecutableData? newExecutable = executable;
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (OpenFileDialog locationFD = new OpenFileDialog())
            {
                string newtitle = title;
                string newfiletype = fileType;
                locationFD.Title = newtitle;
                locationFD.Filter = newfiletype;
                locationFD.Multiselect = false;
                locationFD.InitialDirectory = desktop;
                if (locationFD.ShowDialog() == DialogResult.OK)
                {
                    if (newExecutable == null)
                    {
                        newExecutable = new ExecutableData(locationFD.SafeFileName, locationFD.FileName);
                    }
                    else
                    {
                        newExecutable.Name = locationFD.SafeFileName;
                        newExecutable.Path = locationFD.FileName;
                        if (newExecutable.Label != null && newExecutable.PictureBox != null)
                        {
                            newExecutable.PictureBox.Name = newExecutable.Name;
                            newExecutable.Label.Name = newExecutable.Name;
                            newExecutable.Label.Text = newExecutable.Name;
                        }
                    }
                }
                locationFD.Dispose();
            }
            return newExecutable;
        }

        private ExecutableData locateNewImage(string title, string fileType, ExecutableData executable)
        {
            ExecutableData newExecutable = executable;
            Guid uniqueId = Guid.NewGuid();

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (OpenFileDialog imageFD = new OpenFileDialog())
            {
                imageFD.Title = title;
                imageFD.Filter = fileType;
                imageFD.Multiselect = false;
                imageFD.InitialDirectory = desktop;
                if (imageFD.ShowDialog() == DialogResult.OK)
                {
                    string destination = Application.StartupPath + @"Imagenes\" + uniqueId.ToString() + "_" + imageFD.SafeFileName;
                    Directory.CreateDirectory(Application.StartupPath + @"Imagenes\");
                    File.Delete(destination);
                    File.Copy(imageFD.FileName, destination);
                    if (newExecutable.PictureBox != null && newExecutable.ImagePath != null)
                    {
                        newExecutable.ImagePath = destination;
                        newExecutable.PictureBox.Image = Image.FromFile(newExecutable.ImagePath);
                    }
                    else
                    {
                        newExecutable.ImagePath = destination;
                    }
                }
                imageFD.Dispose();
            }
            return newExecutable;
        }
    }
}