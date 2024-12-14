'Justin Bell
'RCET0265
'Stans Grocery
'https://github.com/ju8t1n203/StansGrocery

Option Explicit On
Option Strict On

Public Class MainForm

    Private inventory() As String
    Private filteredInventory As New List(Of String)
    Private aisleFilter As String() = {"0", "1", "2", "3", "4", "5",
        "6", "7", "8", "9", "10", "11", "12", "13", "14", "15"}
    Private catagoryFilter As String() = {"Fresh Vegetables", "Fresh Fruit",
        "Vegetarian College Student", "Frozen", "Condiments / Sauces",
        "Various groceries", "Canned foods", "Spices & herbs", "Dairy",
        "Cheese", "Meat", "Seafood", "Beverages", "Baked goods", "Baking",
        "Snacks", "Themed Meals", "Baby stuff", "Pets", "Personal care",
        "Pharmacy", "Kitchen", "Cleaning products", "Office supplies",
        "Other stuff"}

    'loading---------------------------
    Private Sub SplashTimer_Tick(sender As Object, e As EventArgs) Handles SplashTimer.Tick
        Me.Show()
        SplashTimer.Enabled = False
        SplashForm.Close()

    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadDataFromFile()
        UpdateComboBox(aisleFilter)
    End Sub

    Private Sub LoadDataFromFile()
        Dim filePath As String = IO.Path.Combine(Application.StartupPath, "..\..\..\StansGrocery\My Project\Grocery.txt")
        If IO.File.Exists(filePath) Then
            inventory = IO.File.ReadAllLines(filePath)
        Else
            MessageBox.Show("Data file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    'filtering---------------------------
    Private Sub UpdateComboBox(options As String())
        FilterComboBox.Items.Clear()
        FilterComboBox.Items.AddRange(options.ToArray())
    End Sub

    Private Sub FilterbyAisleRadioButton_Click(sender As Object, e As EventArgs) Handles FilterbyAisleRadioButton.Click
        UpdateComboBox(aisleFilter)
    End Sub

    Private Sub FilterbyCategoryRadioButton_Click(sender As Object, e As EventArgs) Handles FilterbyCategoryRadioButton.Click
        UpdateComboBox(catagoryFilter)
    End Sub

    'menus--------------------------------
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutForm.Show()
    End Sub

    Private Sub MainForm_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        ContextMenuStrip.Show()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub


End Class
