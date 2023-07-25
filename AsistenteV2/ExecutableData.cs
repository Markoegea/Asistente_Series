using System;

public class ExecutableData
{
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string path;
    public string Path
    {
        get { return path; }
        set { path = value; }
    }

    private string? imagePath;
    public string? ImagePath
    {
        get { return imagePath; }
        set { imagePath = value; }
    }

    private PictureBox? pictureBox;
    public PictureBox? PictureBox
    {
        get { return pictureBox; }
        set { pictureBox = value; }
    }

    private Label? label;
    public Label? Label
    {
        get { return label; }
        set { label = value; }
    }

    public static ExecutableData? fromText(string? data)
    {
        if (data == null) return null;
        ExecutableData? executable = null;
        string[] dataList = data.Split(", ");
        if (dataList.Length == 3)
        {
            executable = new ExecutableData(dataList[0], dataList[1], dataList[2]);
        }
        return executable;
    }

    public ExecutableData(string name, string path, string? imagePath = null)
    {
        this.name = name;
        this.path = path;
        this.imagePath = imagePath;
    }

    public string toString()
    {
        return name + ", " + path + ", " + imagePath;
    }
}

